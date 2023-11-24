extends VBoxContainer

@export var opponent_name: String
@export var anger: float = 0
@export var relationship: float = 100

func _process(_delta):
	$Name.text = opponent_name
	$Anger/ProgressBar.value = anger
	$Relationship/ProgressBar.value = relationship
