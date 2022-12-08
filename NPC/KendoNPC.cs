using Godot;
using System;

public class KendoNPC : KinematicBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    enum EVENT {
        ANIMATION,
        NOT_IN_ANIMATION,
        STOP
    };

    EVENT state;
    MarginContainer TextBox;
    Label textBox;
    Area2D collisionSpace;
    String animName;
    AnimationPlayer animPlayer;
    AnimationPlayer animPlayer2;
    int actNumber;
    public bool condition;

    public String[] animations = {"ACT1"};
    public String[] animations2 = {"ACT1"};
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        state = EVENT.NOT_IN_ANIMATION;
        TextBox = GetNode<MarginContainer>("TextBox");
        textBox = TextBox.GetNode<Label>("Label");
        collisionSpace = GetNode<Area2D>("CollisionSpace");
        animPlayer = GetParent().GetNode<AnimationPlayer>("Director");
        animPlayer2 = GetParent().GetNode<AnimationPlayer>("ShadowDirector");
        collisionSpace.Monitoring = true;
        TextBox.Visible = false;
        actNumber = 0;
        animName = animations[actNumber];
        condition = false;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
    private void _on_CollisionSpace_body_entered(PhysicsBody2D body)
    {
        if(body.Name != "Player")
        {
            GD.Print(body.Name);
            return;
        }
        if(condition == true || actNumber == 0)
        {
            if(condition == true)
                actNumber++;
            animPlayer.Play(animations[actNumber]);
        }
    }

    private void _on_CollisionSpace_area_entered(Area2D area)
    {
        if(area.Name != "Player2")
        {
            return;
        }
        if(condition == true || actNumber == 0)
        {
            if(condition == true)
                actNumber++;
            animPlayer2.Play(animations[actNumber]);
        }
    }

    public void insertText(String text)
    {
        TextBox.Visible = true;
        textBox.Text = text;
    }

    private void _on_Director_animation_finished(String animName)
    {
        if(animations[animations.Length - 1] == animName && condition == true)
        {
            collisionSpace.Monitoring = false;
        }

        TextBox.Visible = false;
    }

    private void _on_ShadowDirector_animation_finished(String animName)
    {
        if(animations2[animations2.Length - 1] == animName && condition == true)
        {
            collisionSpace.Monitoring = false;
        }

        TextBox.Visible = false;
    }
}
