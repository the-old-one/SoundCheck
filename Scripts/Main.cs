using Godot;
using System;

public partial class Main : Node2D
{
	private SceneTransition sceneTransition;

	public override void _Ready()
	{
		sceneTransition = GetNode<SceneTransition>("/root/SceneTransition");
	}
	
		
	private void LoadMainMenu() {
		var scenePath = "res://Scenes/StartMenuCanvas.tscn";
		sceneTransition.ChangeScene(scenePath, locationName: "", spawnPoint: null);
	}
}
