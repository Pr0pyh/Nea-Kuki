using Godot;
using System;

public class Level4_2 : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	Player player;
	player2 _player;
	Door door;
	AnimationPlayer introExit;
	MusicController musicController;
	int needed_score = 0;
	String[] animations = {"ACT1"};
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = GetNode<YSort>("YSort").GetNode<Player>("Player");
		_player = GetNode<player2>("Player2");
		door = GetNode<Door>("Door");
		introExit = GetNode<AnimationPlayer>("IntroExit");
		musicController = (MusicController)GetNode("/root/MusicController");
		_player.objective = needed_score;
		introExit.Play("Entry");
		if(musicController.audioPlayer.Playing == false)
			musicController.playMusic("res://Music and Sounds/Tokyo.mp3");
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		if(player.score >= needed_score)
		{
			door.light.Visible = true;
		}
	}
}
