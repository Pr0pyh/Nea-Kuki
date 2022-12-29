using Godot;
using System;

public class Joystick : Area2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	Sprite bigCircle;
	Sprite smallCircle;
	CollisionShape2D collisionCircle;
	Vector2 move_vector;
	bool touched;
	float maxDistance;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		bigCircle = GetNode<Sprite>("Sprite");
		smallCircle = GetNode<Sprite>("Sprite2");
		collisionCircle = GetNode<CollisionShape2D>("CollisionShape2D");
		touched = false;
		maxDistance = ((CircleShape2D)collisionCircle.Shape).Radius;
	}

	public override void _Input(InputEvent @event)
	{
		if(@event is InputEventScreenTouch buttonEvent)
		{
			float distance = buttonEvent.Position.DistanceTo(bigCircle.GlobalPosition);
			if(!touched && distance<maxDistance)
			{
				touched = true;
			}
			else
			{
				touched = false;
			}
		}
		GD.Print(move_vector);
	}

 // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		if(touched)
		{
			smallCircle.GlobalPosition = GetGlobalMousePosition();
		}
		else
		{
			smallCircle.Position = new Vector2(0.0f, 0.0f);
		}
	}

	public Vector2 get_velocity()
	{
		move_vector = new Vector2(0.0f, 0.0f);
		move_vector.x = smallCircle.Position.x / maxDistance;
		move_vector.y = smallCircle.Position.y / maxDistance;

		return move_vector;
	}
}
