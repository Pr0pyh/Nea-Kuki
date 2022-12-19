using Godot;
using System;

public class Kuki : KinematicBody2D
{
    [Export] public bool horizontalInputOnly;
    [Export] public int speed = 5;
    public enum EVENT{
        MOVE,
        FINDING,
    };

    EVENT state;
    Vector2 velocity;
    public override void _Ready()
    {
        state = EVENT.MOVE;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        switch(state)
        {
            case EVENT.MOVE:
                moveState(delta);
                break;
            case EVENT.FINDING:
                findingState();
                break;
        }
    }

    void moveState(float delta)
    {
        Vector2 input_vector = new Vector2();

        if (Input.IsActionPressed("move_right"))
            input_vector.x += 1;

        if (Input.IsActionPressed("move_left"))
            input_vector.x -= 1;

        if (Input.IsActionPressed("down") && !horizontalInputOnly)
            input_vector.y += 1;

        if (Input.IsActionPressed("up") && !horizontalInputOnly)
            input_vector.y -= 1;
            

        input_vector = input_vector.Normalized();

        // if(input_vector != Vector2.Zero)
        // {
        //     animTree.Set("parameters/Idle/blend_position", velocity);
        //     animTree.Set("parameters/Run/blend_position", velocity);
        //     animState.Travel("Run");
        // }
        // else
        // {
        //     animState.Travel("Idle");
        // }
        velocity = input_vector*speed;
        velocity = MoveAndSlide(velocity);
    }

    void findingState()
    {
        
    }
}
