using Godot;
using System;

public partial class MainMenu : Control
{
	private void _on_play_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://GameScene.tscn");
	}


	private void _on_sound_button_pressed()
	{
		GetNode<VSlider>("CenterContainer/HBoxContainer/SoundSlider").Visible = !GetNode<VSlider>("CenterContainer/HBoxContainer/SoundSlider").Visible;
	}

	private void _on_sound_slider_value_changed(double value)
	{
		GetNode<AudioStreamPlayer2D>("CenterContainer/HBoxContainer/SampleSound").Play();
		AudioServer.SetBusVolumeDb(AudioServer.GetBusIndex("Master"), Mathf.LinearToDb((float)value/100));
	}



	private void _on_exit_button_pressed()
	{
		GetTree().Quit();
	}

}



