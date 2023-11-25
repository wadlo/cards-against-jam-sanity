extends Node2D

@onready var cards: Array[Node] = get_children()
@export var player_state: Node

func _process(_delta):
	cards = get_children()
	
	var index = 0
	for card in cards:
		card.position.x = index * 130 - len(cards) * 65
		card.rotation_degrees = (len(cards) / 2 - index) * -15
		
		index += 1

func clicked_card(config):
	print(%RoundController.CanPlayerPlay())
	if %RoundController.CanPlayerPlay():
		player_state.PlayCard(config, false)
