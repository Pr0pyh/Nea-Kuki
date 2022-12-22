using Godot;
using System;

public class Level3_3 : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	Player player;
	player2 _player;
	KendoNPC kendoMaster;
	Door door;
	AnimationPlayer introExit;
	MusicController musicController;
	int needed_score = 1;
	String[] animations = {"ACT1", "ACT2"};
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = GetNode<YSort>("YSort").GetNode<Player>("Player");
		kendoMaster = GetNode<KendoNPC>("KendoNPC");
		_player = GetNode<player2>("Player2");
		door = GetNode<Door>("Door");
		introExit = GetNode<AnimationPlayer>("IntroExit");
		musicController = (MusicController)GetNode("/root/MusicController");
		_player.objective = needed_score;
		kendoMaster.animations = animations;
		introExit.Play("Entry");
		if(musicController.audioPlayer.Playing == false)
			musicController.playMusic("res://Music and Sounds/Theme.mp3");
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		if(player.score >= needed_score)
		{
			kendoMaster.condition = true;
			door.light.Visible = true;
		}
	}

	public void stopMusic()
	{
		musicController.stop();
	}

	public void playMusic(String musicName)
	{
		musicController.playMusic(musicName);
	}
}
