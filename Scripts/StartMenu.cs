using Godot;
using System;

public partial class StartMenu : Control
{
	private SceneTransition sceneTransition;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		sceneTransition = GetNode<SceneTransition>("/root/SceneTransition");
	}
	
	public void OnLoadDawnChorus() {
		var scenePath = "res://Scenes/Main.tscn";
		sceneTransition.ChangeScene(scenePath, locationName: "Dawn Chorus", spawnPoint: null);
	}
	
	public void OnLoadGuessChord() {
		var scenePath = "res://Scenes/GuessChord.tscn";
		sceneTransition.ChangeScene(scenePath, locationName: "Guess Chord", spawnPoint: null);
	}
}
