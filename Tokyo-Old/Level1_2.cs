using Godot;
using System;

public class Level1_2 : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.

	Player player;
	SumoNPC sumoNPC;
	Door door;
	AnimationPlayer introExit;
	MusicController musicController;
	int needed_score = 1;
	
	public override void _Ready()
	{
		player = GetNode<YSort>("YSort").GetNode<Player>("Player");
		sumoNPC = GetNode<SumoNPC>("SumoNPC");
		door = GetNode<Door>("Door");
		musicController = (MusicController)GetNode("/root/MusicController");
		introExit = GetNode<AnimationPlayer>("IntroExit");
		introExit.Play("Entry");
		// Input.MouseMode = Input.MouseModeEnum.Hidden;
		musicController.playMusic("res://Music and Sounds/Kyototest.mp3");
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		if(player.score >= needed_score)
		{
			sumoNPC.condition = true;
			door.light.Visible = true;
		}
	}
}
