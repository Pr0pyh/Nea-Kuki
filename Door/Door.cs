using Godot;
using System;

public class Door : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Export] public String level;
    [Export] public int objectiveScore;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    private void _on_Door_body_entered(PhysicsBody2D body)
    {
        if(body.Name != "Player")
            return;
        if(((Player)body).score >= objectiveScore)
            GetTree().ChangeScene(level);
    }
}
