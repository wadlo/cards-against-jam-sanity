using System;
using System.Collections.Generic;
using Godot;

[Tool]
public partial class CardConfig : Resource
{
    public enum CardType : int
    {
        Jelly,
        Bread,
        PeanutButtor
    }

    [Export]
    public CardType cardType;

    [Export]
    public string cardName;

    [Export]
    public string cardDescription;

    [Export]
    public Image cardImage;
}
