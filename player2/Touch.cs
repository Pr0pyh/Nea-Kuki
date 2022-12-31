using Godot;
using System;

public class Touch : Area2D
{
	CollisionShape2D collisionRectangle;
	Vector2 move_vector;
    Position2D positionPlayer;
	public bool touched;
	float maxDistance;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		collisionRectangle = GetNode<CollisionShape2D>("CollisionShape2D");
        positionPlayer = GetNode<Position2D>("Position2D");
		touched = false;
		maxDistance = ((CircleShape2D)collisionRectangle.Shape).Radius;
	}

	public override void _Input(InputEvent @event)
	{
		if(@event is InputEventScreenTouch buttonEvent)
		{
			float distance = buttonEvent.Position.DistanceTo(collisionRectangle.GlobalPosition);
			if(!touched && distance<maxDistance && buttonEvent.Index == 0)
			{
				touched = true;
			}
			else
			{
				touched = false;
			}
		}
	}

 // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		positionPlayer.GlobalPosition = GetGlobalMousePosition();
	}

	public Vector2 get_velocity()
	{
		move_vector = positionPlayer.GlobalPosition;

		return move_vector;
	}
}
