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
		int minvol = 40;
		AudioServer.SetBusVolumeDb(AudioServer.GetBusIndex("Master"), -minvol + ((float)value / (100/minvol)));
	}



	private void _on_exit_button_pressed()
	{
		GetTree().Quit();
	}

}



