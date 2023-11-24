extends Node2D

@onready var cards: Array[Node] = get_children()

func _process(_delta):
	cards = get_children()
	
	var index = 0
	for card in cards:
		card.position.x = index * 80 - len(cards) * 40
		card.rotation_degrees = (len(cards) / 2 - index) * -20
		
		index += 1
