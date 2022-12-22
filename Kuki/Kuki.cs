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

    public EVENT state;
    public AnimationPlayer animPlayer;
    public AnimationTree animTree;
    public AnimationNodeStateMachinePlayback animState;
    public Vector2 velocity;
    public override void _Ready()
    {
        animPlayer = this.GetNode<AnimationPlayer>("AnimationPlayer");
        animTree = this.GetNode<AnimationTree>("AnimationTree");
        animTree.Active = true;
        animState = (AnimationNodeStateMachinePlayback)animTree.Get("parameters/playback");
        GD.Print(velocity);
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
		if(velocity != Vector2.Zero)
		{
			animTree.Set("parameters/Idle/blend_position", velocity);
			animTree.Set("parameters/Run/blend_position", velocity);
			animState.Travel("Run");
		}
		else
		{
			animState.Travel("Idle");
		}
		velocity = input_vector*speed;
		// velocity = MoveAndSlide(velocity);
	}

	private void _on_Director_animation_finished(String animName)
	{
		state = EVENT.MOVE;
	}

    private void _on_Director_animation_started(String animName)
    {
        state = EVENT.FINDING;
    }

    public void inAnimationMove()
    {
        if(state == EVENT.FINDING)
        {
            animTree.Set("parameters/Run/blend_position", velocity);
            animState.Travel("Run");
        }
    }

    public void inAnimationStop()
    {
        if(state == EVENT.FINDING)
        {
            animState.Travel("Idle");
        }
    }
}
