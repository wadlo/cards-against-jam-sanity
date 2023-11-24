using System.Collections.Generic;
using Godot;
using Godot.Collections;

[Tool]
public partial class CardListConfig : Resource
{
    [Export]
    public Array<CardConfig> cards;
}
