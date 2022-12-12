using Godot;
using System;

public class Level1_1 : Node2D

{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	Player player;
	NPC npc;
	Door door;
	int needed_score = 0;
	AnimationPlayer introExit;
	String[] animations = {"ACT1"};
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = GetNode<YSort>("YSort").GetNode<Player>("Player");
		npc = GetNode<NPC>("NPC");
		door = GetNode<Door>("Door");
		introExit = GetNode<AnimationPlayer>("IntroExit");
		npc.animations = animations;
		introExit.Play("Entry");
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		if(player.score >= needed_score)
		{
			npc.condition = true;
			door.light.Visible = true;
		}
	}
}
