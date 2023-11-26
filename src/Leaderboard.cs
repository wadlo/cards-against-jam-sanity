using Godot;

public partial class Leaderboard : VBoxContainer
{
	public override void _Process(double delta)
	{
		foreach (PlayerState playerState in RoundController.instance.GetAllPlayers())
		{
			var points = CalculatePoints.Calculate(playerState.cardsLaidDown);
			GetNode<Label>(playerState.name).Text = $"{playerState.name}: {points}";
		}
	}
}
