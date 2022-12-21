using Godot;
using System;

public class MusicController : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    public AudioStreamPlayer audioPlayer;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        audioPlayer = GetNode<AudioStreamPlayer>("Music");
    }

    public void playMusic(string trackName)
    {
		File file = new File();
		if(file.FileExists(trackName))
		{
			file.Open(trackName, File.ModeFlags.Read);
			byte[] buffer = file.GetBuffer((long)file.GetLen());
			AudioStreamMP3 streamMusic = new AudioStreamMP3();
			streamMusic.Data = buffer;
            streamMusic.Loop = true;
			audioPlayer.Stream = streamMusic;
			audioPlayer.Play();
		}
        audioPlayer.Play();
    }

    public void stop()
    {
        audioPlayer.Stop();
    }
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
