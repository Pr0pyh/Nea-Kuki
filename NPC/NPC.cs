using Godot;
using System;

public class NPC : KinematicBody2D
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
    int actNumber;
    [Export] public bool condition;

    public String[] animations = {"ACT1", "ACT2"};
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        state = EVENT.NOT_IN_ANIMATION;
        TextBox = GetNode<MarginContainer>("TextBox");
        textBox = TextBox.GetNode<Label>("Label");
        collisionSpace = GetNode<Area2D>("CollisionSpace");
        animPlayer = GetParent().GetNode<AnimationPlayer>("Director");
        collisionSpace.Monitoring = true;
        TextBox.Visible = false;
        condition = false;
        actNumber = 0;
        animName = animations[actNumber];
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
    private void _on_CollisionSpace_body_entered(PhysicsBody2D body)
    {
        if(body.Name != "Player")
            return;
        if(condition == true || actNumber == 0)
        {
            if(condition == true && actNumber != (animations.Length-1))
                actNumber++;
            animPlayer.Play(animations[actNumber]);
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
}
