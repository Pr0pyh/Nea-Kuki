using Godot;
using System;

public class player2 : Area2D
{

    public enum EVENT{
        MOVING,
        LOOKING,
        STOP
    };

    Vector2 velocity;
    Area2D collision;
    Sprite collisionSprite;
    EVENT state;
    MarginContainer TextBox;
    Label textBox;
    Timer objectiveTimer;
    Timer interactiveTimer;
    Position2D touchPosition;
    [Export] public bool android;
    bool touched;
    public int objective;
    public bool talkingState;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        collisionSprite = GetNode<Sprite>("Sprite_collision");
        TextBox = GetNode<MarginContainer>("TextBox");
        textBox = TextBox.GetNode<Label>("Label");
        objectiveTimer = GetNode<Timer>("ObjectiveTimer");
        interactiveTimer = GetNode<Timer>("InteractiveTimer");
        touchPosition = GetNode<CanvasLayer>("CanvasLayer").GetNode<Position2D>("TouchCursor");
        Monitoring = false;
        touched = false;
        collisionSprite.Visible = false;
        TextBox.Visible = false;
        state = EVENT.MOVING;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        switch(state)
        {
            case EVENT.MOVING:
                Monitoring = false;
                Monitorable = false;
                collisionSprite.Visible = false;
                if(android == false)
                {
                    move_state();
                }
                else if(touched)
                {
                    Position = GetGlobalMousePosition();
                    state = EVENT.LOOKING;
                }
                break;
            case EVENT.LOOKING:
                Monitoring = true;
                Monitorable = true;
                collisionSprite.Visible = true;
                if(Input.IsMouseButtonPressed((int)ButtonList.Left))
                {
                    state = EVENT.LOOKING;          
                }
                else
                {
                    state = EVENT.MOVING;
                }
                break;
            case EVENT.STOP:
                break;
        }

        
    }

    public override void _Input(InputEvent @event)
	{
		if(@event is InputEventScreenTouch buttonEvent)
		{
            if(!touched && buttonEvent.Index == 0)
            {
                touched = true;
            }
            else
            {
                touched = false;
            }
            GD.Print(buttonEvent.Index);
		}
	}

    public void move_state()
    {
        Position = GetGlobalMousePosition();
        if(Input.IsMouseButtonPressed((int)ButtonList.Left))
        {
            state = EVENT.LOOKING;          
        }
        else
        {
            state = EVENT.MOVING;
        }
    }

    public void objectiveText(String textSuccess, String textFailure, int score)
    {
        TextBox.Visible = true;
        if(score >= objective)
            textBox.Text = textSuccess;
        else
            textBox.Text = textFailure;
        objectiveTimer.Start();
    }

    public void informationText(String text)
    {
        TextBox.Visible = true;
        textBox.Text = text;
        interactiveTimer.Start();
    }

    public void insertText(String text)
    {
        TextBox.Visible = true;
        textBox.Text = text;
    }

    private void _on_Director_animation_started(String animName)
    {
        state = EVENT.STOP;
    }

    private void _on_Director_animation_finished(String animName)
    {
        TextBox.Visible = false;
        state = EVENT.MOVING;
    }

    private void _on_ObjectiveTimer_timeout()
    {
        TextBox.Visible = false;
    }

    private void _on_InteractiveTimer_timeout()
    {
        TextBox.Visible = false;
        talkingState = false;
    }
}
