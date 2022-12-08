using Godot;
using System;

public class LevelTrain : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    Player player;
    NPC npc;
    Door door;
    int needed_score = 0;
    String[] animations = {"ACT1"};
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        player = GetNode<Player>("Player");
        npc = GetNode<NPC>("NPC");
        door = GetNode<Door>("Door");
        npc.animations = animations;
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
