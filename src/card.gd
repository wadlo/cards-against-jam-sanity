extends Area2D

@onready var default_y_pos: float = position.y

func _on_mouse_entered():
	z_index = 1
	var tween = get_tree().create_tween()
	tween.tween_property(self, "scale", Vector2(1.3, 1.3), 0.1)
	tween.tween_property(self, "position", Vector2(position.x, default_y_pos - 100), 0.1)


func _on_mouse_exited():
	z_index = 0
	var tween = get_tree().create_tween()
	tween.tween_property(self, "scale", Vector2.ONE, 0.1)
	tween.tween_property(self, "position", Vector2(position.x, default_y_pos), 0.1)
