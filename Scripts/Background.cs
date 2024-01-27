using Godot;
using System;

public partial class Background : Node2D
{
	public override void _Ready()
	{
		Callable callable = new Callable(this, MethodName.OnActiveTracksChangedSignal);
		var fmodController = GetNode<Node2D>("/root/Main/FMODController");
		fmodController.Connect("active_tracks_number_changed", callable);
		OnActiveTracksChangedSignal(0);
	}

	private void OnActiveTracksChangedSignal(int numberOfTracks)
	{
		Tween tween = GetTree().CreateTween().SetParallel(true);
		var colorMult = Mathf.Min(numberOfTracks / 10f, 1.0f) + 0.1f;
		tween.TweenProperty(this, "modulate", new Color(Mathf.Min(0.5f * colorMult, 1), Mathf.Min(1 * colorMult, 1), Mathf.Min(2 * colorMult, 1), 1), 0.5f).SetTrans(Tween.TransitionType.Sine);
	}
}
