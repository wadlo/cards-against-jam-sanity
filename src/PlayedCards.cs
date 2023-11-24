using Godot;

public partial class PlayedCards : Node2D
{
    public float distanceBetweenCards = 200.0f;

    [Export]
    public PlayerState playerState;

    public override void _Ready()
    {
        RefreshGraphics();
        playerState.visualsRefreshed += () =>
        {
            RefreshGraphics();
        };
    }

    public void RefreshGraphics()
    {
        // Remove all children
        foreach (Node2D child in GetChildren())
        {
            child.QueueFree();
        }
        for (int i = 0; i < playerState.cardsLaidDown.Count; i++)
        {
            CardConfig cardConfig = playerState.cardsLaidDown[i];
            CardComponent instantiated = (CardComponent)playerState.cardPackedScene.Instantiate();
            instantiated.config = cardConfig;
            instantiated.GetChild<Sprite2D>(0).Texture = cardConfig.cardImage;

            AddChild(instantiated);
            instantiated.Position = new Vector2(
                (i - (playerState.cardsLaidDown.Count - 1) / 2.0f) * distanceBetweenCards,
                0.0f
            );
        }
    }
}
