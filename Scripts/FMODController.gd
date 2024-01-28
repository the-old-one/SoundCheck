extends Node2D

@export var event: EventAsset
@export var minigame_event: EventAsset

var instance: EventInstance
var minigame_instance: EventInstance

var marker_callable: Callable = Callable(self, "marker_callback")

var active_tracks = 0

signal marker_called(marker_name)
signal active_tracks_number_changed(active_tracks_number)

const BIRD_1 = "bird_1"
const BIRD_2 = "bird_2"
const BIRD_3 = "bird_3"
const BIRD_BASS = "bird_bass"

func _ready():
	instance = FMODRuntime.create_instance(event)
	instance.start()
	instance.set_callback(marker_callable, FMODStudioModule.FMOD_STUDIO_EVENT_CALLBACK_TIMELINE_MARKER)
	
	minigame_instance = FMODRuntime.create_instance(minigame_event)
# 	minigame_instance.start()

func _on_track_toggle(track_name, is_on):
	if is_on == true:
		active_tracks += 1
	else:
		active_tracks -= 1
	print(active_tracks)
	var state = "On" if is_on else "Off"
	print(track_name, " ", state)
	instance.set_parameter_by_name_with_label(track_name, state, false)
	emit_signal("active_tracks_number_changed", active_tracks)

func _on_note_play(track_name, note):
	instance.set_parameter_by_name_with_label(track_name, note, false)


func marker_callback(args):
	var marker_name = args.properties.name
	call_deferred("emit_signal","marker_called", marker_name)

var chord_c = ["C", "E", "G"]
var chord_c_min = ["C", "G"]

# var chords = [chord_c, chord_c_min]

func _on_play_button_pressed():
	play_current_chord()

func play_current_chord():
	print("play current chord")
	var chord = chord_c # chords[0]
	play_chord(chord)

func play_chord(chord):
	for note in chord:
		instance.set_parameter_by_name_with_label("bird_1_note", "C", false)
		instance.set_parameter_by_name_with_label("bird_2_note", "D", false)
		minigame_instance.start()
