using Godot;
using System;
public partial class SceneTransition : CanvasLayer
{
	[Signal]
	public delegate void SceneLoadedEventHandler(Node2D scene, NodePath spawnPoint = null);
	Node worldNode;
	Node currentScene;

	Label sceneNameLabel;

	public override void _Ready()
	{
		worldNode = GetTree().Root.GetNode<Node>("Start");
		sceneNameLabel = GetNode<Label>("DissolveRect/SceneNameLabel");
	}
	public async void ChangeScene(string scenePath, string locationName = "", NodePath spawnPoint = null)
	{
		if (worldNode == null)
		{
			return;
		}
		var animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		sceneNameLabel.Text = locationName;
		animationPlayer.Play("dissolve");
		await ToSignal(animationPlayer, "animation_finished");
		
		UnloadLevel();
		
		LoadLevel(scenePath);
		EmitSignal(SignalName.SceneLoaded, currentScene, spawnPoint);
		animationPlayer.PlayBackwards("dissolve");
	}

	void UnloadLevel() {
		if (worldNode == null)
		{
			return;
		}
		var worldChildren = worldNode.GetChildren();
		if (worldChildren.Count == 0) {
			return;
		}
		currentScene = worldNode.GetChildren()[0];
		GD.Print("Unloading level: " + currentScene);
		if (currentScene != null) {
			currentScene.QueueFree();
		}
	}

	void LoadLevel(string scenePath) {
		if (worldNode == null)
		{
			return;
		}
		var levelResource = ResourceLoader.Load<PackedScene>(scenePath).Instantiate();
		currentScene = levelResource;
		worldNode.AddChild(levelResource);
	}
}
