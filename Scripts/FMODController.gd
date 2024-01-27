extends Node2D

@export var event: EventAsset

var instance: EventInstance
var marker_callable: Callable = Callable(self, "marker_callback")

signal marker_called(marker_name)

const BIRD_1 = "bird_1"
const BIRD_2 = "bird_2"
const BIRD_3 = "bird_3"
const BIRD_BASS = "bird_bass"

func _ready():
	instance = FMODRuntime.create_instance(event)
	instance.start()
	instance.set_callback(marker_callable, FMODStudioModule.FMOD_STUDIO_EVENT_CALLBACK_TIMELINE_MARKER)

# 	instance.set_parameter_by_name_with_label("bird_1", "On", false)

func _on_track_toggle(track_name, is_on):
	var state = "On" if is_on else "Off"
	print(track_name, " ", state)
	instance.set_parameter_by_name_with_label(track_name, state, false)


func marker_callback(args):
# 	print("Marker: " + args.properties.name + " at position: " + str(args.properties.position))
	var marker_name = args.properties.name
# 	marker_called.emit(marker_name)
	call_deferred("emit_signal","marker_called", marker_name)
# 	if args.properties.tempo:
# 		print("bar!", args.properties.tempo)
