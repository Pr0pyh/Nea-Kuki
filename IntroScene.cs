using Godot;
using System;

public class IntroScene : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    AnimationPlayer animPlayer;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        animPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        animPlayer.Play("Intro");
    }

    private void _on_AnimationPlayer_animation_finished(String animName)
    {
        GetTree().ChangeScene("res://Tokyo-Old/Level1_0.tscn");
    }
}
