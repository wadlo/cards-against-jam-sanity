extends Area2D

@onready var default_y_pos: float = position.y
var hovered: bool = false;
var config;
var start_scale;

func _ready():
	start_scale = global_scale.x

func _on_mouse_entered():
	hovered = true
	z_index = 2
	var tween = get_tree().create_tween()
	tween.tween_property(self, "global_scale", Vector2((start_scale + 1.0)/2 * 1.3, (start_scale + 1.0)/2 * 1.3), 0.1)
	tween.tween_property(self, "position", Vector2(position.x, default_y_pos - 100), 0.1)


func _on_mouse_exited():
	hovered = false
	z_index = 1
	var tween = get_tree().create_tween()
	tween.tween_property(self, "global_scale", Vector2(start_scale, start_scale), 0.1)
	tween.tween_property(self, "position", Vector2(position.x, default_y_pos), 0.1)

func _input(event: InputEvent) -> void:
	if (
		hovered
		and event is InputEventMouseButton
		and event.button_index == MOUSE_BUTTON_LEFT
		and event.is_pressed()
	):
		get_parent().clicked_card(config)

