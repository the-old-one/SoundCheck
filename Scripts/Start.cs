using Godot;
using System;

public partial class Start : Node2D
{
	private SceneTransition sceneTransition;

	private Node currentScene;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		sceneTransition = GetNode<SceneTransition>("/root/SceneTransition");
		sceneTransition.SceneLoaded += OnSceneLoaded;
		var scenePath = "res://Scenes/StartMenuCanvas.tscn";
		LoadStartingLevel(scenePath, "");

	}
	private void LoadStartingLevel(string scenePath, string locationName = "") {
		sceneTransition.ChangeScene(scenePath, locationName: locationName, spawnPoint: null);
	}
	
	private void OnSceneLoaded(Node scene, NodePath spawnPointPath = null) {
		currentScene = scene;
	}
}
