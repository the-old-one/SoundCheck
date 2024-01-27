extends Node2D

@export var event: EventAsset
var instance: EventInstance
var callable: Callable = Callable(self, "beat_callback")

# Called when the node enters the scene tree for the first time.
func _ready():
	instance = FMODRuntime.create_instance(event)
	instance.set_callback(callable, FMODStudioModule.FMOD_STUDIO_EVENT_CALLBACK_TIMELINE_BEAT)

	instance.start()
	
# 	instance.set_parameter_by_name_with_label("bird_1", "On", false)

func _on_track_toggle(track_name, is_on):
	
	# set is_on to "On" if true and "Off" if false
	var state = "On" if is_on else "Off"
	print(track_name, " ", state)
	instance.set_parameter_by_name_with_label(track_name, state, false)
	
func beat_callback(args):
	if args.properties.beat:
		print("beat!")

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass
