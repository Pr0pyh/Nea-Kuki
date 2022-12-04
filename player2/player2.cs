using Godot;
using System;

public class player2 : Area2D
{

    public enum EVENT{
        MOVING,
        LOOKING
    };

    Vector2 velocity;
    Area2D collision;
    Sprite collisionSprite;
    EVENT state;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        collisionSprite = GetNode<Sprite>("Sprite_collision");
        Monitoring = false;
        collisionSprite.Visible = false;
        state = EVENT.MOVING;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        switch(state)
        {
            case EVENT.MOVING:
                Monitoring = false;
                collisionSprite.Visible = false;
                Position = GetGlobalMousePosition();
                break;
            case EVENT.LOOKING:
                Monitoring = true;
                collisionSprite.Visible = true;
                break;
        }

        if(Input.IsMouseButtonPressed((int)ButtonList.Left))
         {
            state = EVENT.LOOKING;          
         }
        else
        {
            state = EVENT.MOVING;
        }
    }
}
