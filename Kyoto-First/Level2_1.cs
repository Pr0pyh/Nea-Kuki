using Godot;
using System;

public class Level2_1 : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    Player player;
    NPC teaMaster;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        player = GetNode<Player>("Player");
        teaMaster = GetNode<NPC>("TeaMaster");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if(player.score > 0)
            teaMaster.condition = true;
    }
}
