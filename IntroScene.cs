using Godot;
using System;

public class IntroScene : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    AnimationPlayer animPlayer;
    MusicController musicController;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        animPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        musicController = (MusicController)GetNode("/root/MusicController");
        animPlayer.Play("Intro");
        musicController.stop();
    }

    public void startMusic(String trackName)
    {
        musicController.playMusic(trackName);
    }

    private void _on_AnimationPlayer_animation_finished(String animName)
    {
        GetTree().ChangeScene("res://Tokyo-Old/Level1_0.tscn");
    }
}
