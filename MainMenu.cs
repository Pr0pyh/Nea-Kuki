using Godot;
using System;

public class MainMenu : Control
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	MusicController musicController;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		musicController = (MusicController)GetNode("/root/MusicController");
		musicController.playMusic("res://Music and Sounds/Credits2.mp3");
	}

	private void _on_Button_pressed()
	{
		GetTree().ChangeScene("res://IntroScene.tscn");
	}
}
