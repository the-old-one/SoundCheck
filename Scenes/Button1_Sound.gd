extends StudioEventEmitter2D


# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.

func _on_button_pressed():
	print("play random sfx")
	FMODRuntime.play_one_shot(event)

