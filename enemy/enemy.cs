using Godot;
using System;

public class enemy : KinematicBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    enum EVENT {
        VISIBLE,
        NOT_VISIBLE
    };

    Area2D player2;
    Area2D collision_p2;
    EVENT state;
    AnimationPlayer deathAnim;
    Sprite enemySprite;
    AnimatedSprite sprite;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        player2 = this.GetParent().GetNode<Area2D>("Player2");
        sprite = this.GetNode<AnimatedSprite>("Sprite");
        enemySprite = this.GetNode<Sprite>("EnemySprite");
        player2.Connect("body_entered", this, "_on_Collision_body_entered");
        player2.Connect("body_exited", this, "_on_Collision_body_exited");
        deathAnim = this.GetNode<AnimationPlayer>("AnimationPlayer");
        state = EVENT.NOT_VISIBLE;
        sprite.Visible = true;
        enemySprite.Visible = false;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        switch(state) 
        {
            case EVENT.VISIBLE:
                Modulate = new Color(1, 1, 1, (255-(Position.DistanceTo(player2.Position)))/255);
                break;
            case EVENT.NOT_VISIBLE:
                Modulate = new Color(1, 1, 1, 0);
                break;
        }
    }

    private void _on_Collision_body_entered(Node body)
    {
        this.state = EVENT.VISIBLE;
    }

    public void _on_Collision_body_exited(Node body)
    {
        this.state = EVENT.NOT_VISIBLE;
    }

    public void destroy()
    {
        if(Modulate > new Color(1, 1, 1, 0))
            deathAnim.Play("DeathAnimation");
    }

    private void _on_AnimationPlayer_animation_finished(String animName)
    {
        QueueFree();
    }
}
