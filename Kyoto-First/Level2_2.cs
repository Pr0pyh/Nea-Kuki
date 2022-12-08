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
    int needed_score = 3;
    String[] animations = {"ACT1", "ACT2"};
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        player = GetNode<Player>("Player");
        teaMaster = GetNode<NPC>("TeaMaster");
        _player = GetNode<player2>("Player2");
        _player.objective = needed_score;
        teaMaster.animations = animations;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if(player.score >= needed_score)
        {
            teaMaster.condition = true;
        }
    }
}
