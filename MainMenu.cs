using Godot;
using System;

public class MainMenu : Control
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

<<<<<<< HEAD
	private void _on_Button_pressed()
	{
		GetTree().ChangeScene("res://Tokyo-Old/Level1_0.tscn");
	}
=======
	private void _on_Button_pressed()
	{
		GetTree().ChangeScene("res://IntroScene.tscn");
	}
>>>>>>> 5fbf1b7107cb47b2d94b5c2d4cb748861dc63ea1
}
