using Godot;
using System;

public partial class ClickableSprite : Area2D
{
	[Signal]
	public delegate void ToggleTrackEventHandler(string trackName, bool isActive);
	[Export]
	public string TrackName;
	public bool IsActive;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.InputEvent += OnClick;
		SetTint(IsActive, 0f);
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnClick(Node viewPort, InputEvent inputEvent, long shapeIdx)
	{
		if (@inputEvent.IsActionPressed("click"))
		{
			GD.Print("Click");
			toggleActive();
		}
	}

	private void toggleActive()
	{
		IsActive = !IsActive;
		EmitSignal(SignalName.ToggleTrack, TrackName, IsActive);
		SetTint(IsActive);
	}

	private void SetTint(bool tintOn, float duration = 0.5f)
	{
		var transitionDuration = duration;
		if (tintOn)
		{
			Tween tween = GetTree().CreateTween().SetParallel(true);
			tween.TweenProperty(GetNode("Sprite"), "modulate", new Color(1, 1, 1, 1), transitionDuration).SetTrans(Tween.TransitionType.Sine);
			tween.TweenProperty(GetNode("Sprite"), "scale", new Vector2(1.1f, 1.1f), transitionDuration).SetTrans(Tween.TransitionType.Sine);

			// this.Modulate = new Color(1, 1, 1, 1);
		}
		else
		{
			Tween tween = GetTree().CreateTween().SetParallel(true);
			tween.TweenProperty(GetNode("Sprite"), "modulate", new Color(0.2f, 0.4f, 0.4f, 1), transitionDuration).SetTrans(Tween.TransitionType.Sine);
			tween.TweenProperty(GetNode("Sprite"), "scale", new Vector2(1f, 1f), transitionDuration).SetTrans(Tween.TransitionType.Sine);

			// this.Modulate = new Color(1, 1, 1, 0.5f);
		}
	}
}
