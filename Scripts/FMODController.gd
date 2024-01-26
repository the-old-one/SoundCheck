extends Node2D

@export var event: EventAsset
var instance: EventInstance

# Called when the node enters the scene tree for the first time.
func _ready():
    instance = FMODRuntime.create_instance(event)
    instance.start()
    instance.set_parameter_by_name_with_label("bird_1", "On", false)


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
    pass
