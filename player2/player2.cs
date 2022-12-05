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
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        collisionSprite = GetNode<Sprite>("Sprite_collision");
        TextBox = GetNode<MarginContainer>("TextBox");
        textBox = TextBox.GetNode<Label>("Label");
        Monitoring = false;
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
                collisionSprite.Visible = false;
                Position = GetGlobalMousePosition();
                if(Input.IsMouseButtonPressed((int)ButtonList.Left))
                {
                    state = EVENT.LOOKING;          
                }
                else
                {
                    state = EVENT.MOVING;
                }
                break;
            case EVENT.LOOKING:
                Monitoring = true;
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
}
