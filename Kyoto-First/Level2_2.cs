using Godot;
using System;

public class Level2_2 : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	Player player;
	player2 _player;
	NPC teaMaster;
	Door door;
	AnimationPlayer introExit;
	MusicController musicController;
	CameraPlayer cameraPlayer;
	int needed_score = 3;
	String[] animations = {"ACT1", "ACT2"};
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = GetNode<YSort>("YSort").GetNode<Player>("Player");
		teaMaster = GetNode<NPC>("TeaMaster");
		_player = GetNode<player2>("Player2");
		door = GetNode<Door>("Door");
		introExit = GetNode<AnimationPlayer>("IntroExit");
		cameraPlayer = GetNode<CameraPlayer>("CameraPlayer");
		musicController = (MusicController)GetNode("/root/MusicController");
		_player.objective = needed_score;
		teaMaster.animations = animations;
		cameraPlayer.Zoom = new Vector2(1.5f, 1.5f);
		Input.MouseMode = Input.MouseModeEnum.Hidden;
		introExit.Play("Entry");
		if(musicController.audioPlayer.Playing == false)
			musicController.playMusic("res://Music and Sounds/Theme.mp3");
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		if(player.score >= needed_score)
		{
			teaMaster.condition = true;
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
