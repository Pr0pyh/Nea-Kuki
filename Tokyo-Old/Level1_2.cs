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
    public override void _Ready()
    {
        player = GetNode<Player>("Player");
        sumoNPC = GetNode<SumoNPC>("SumoNPC");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if(player.score > 0)
            sumoNPC.condition = true;
    }
}
