using Godot;
using System;

public partial class ClickableSprite : Area2D
{
	[Signal]
	public delegate void ToggleTrackEventHandler(string trackName, bool isActive);
	[Export]
	public string TrackName;
	public bool IsActive;
	
	private Vector2 originalScale;

	private AnimatedSprite2D sprite;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.InputEvent += OnClick;
		sprite = GetNodeOrNull<AnimatedSprite2D>("Sprite");
		if (sprite != null)
		{
			originalScale = sprite.Scale;
			sprite.AnimationFinished += OnActivaAnimationFinished;
		}
		SetActive(IsActive, 0f);
		// find FMODController
		Callable callable = new Callable(this, MethodName.OnMarkerSignal);

		var fmodController = GetNode<Node2D>("/root/Main/FMODController");
		
		fmodController.Connect("marker_called", callable);

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnClick(Node viewPort, InputEvent inputEvent, long shapeIdx)
	{
		if (@inputEvent.IsActionPressed("click"))
		{
			toggleActive();
		}
	}

	private void toggleActive()
	{
		IsActive = !IsActive;
		EmitSignal(SignalName.ToggleTrack, TrackName, IsActive);
		SetActive(IsActive);
	}

	private void SetActive(bool active, float duration = 0.5f)
	{
		var transitionDuration = duration;
		if (active)
		{
			if (sprite == null) return;
			Tween tween = GetTree().CreateTween().SetParallel(true);
			tween.TweenProperty(sprite, "modulate", new Color(1, 1, 1, 1), transitionDuration).SetTrans(Tween.TransitionType.Sine);
			tween.TweenProperty(sprite, "scale", new Vector2(originalScale.X + 0.1f, originalScale.Y + 0.1f), transitionDuration).SetTrans(Tween.TransitionType.Sine);
			
		}
		else
		{
			if (sprite == null) return;
			Tween tween = GetTree().CreateTween().SetParallel(true);
			tween.TweenProperty(sprite, "modulate", new Color(0.2f, 0.4f, 0.4f, 1), transitionDuration).SetTrans(Tween.TransitionType.Sine);
			tween.TweenProperty(sprite, "scale", originalScale, transitionDuration).SetTrans(Tween.TransitionType.Sine);
			sprite.Play("idle");
		}
	}
	
	private void OnMarkerSignal(string markerName)
	{
		// GD.Print("markerName: " + markerName + " TrackName: " + TrackName);
		if (markerName == TrackName + "_sing")
		{
			if (!IsActive) return;
			sprite.Stop();
			sprite.Play("active");
		}
	}
	
	private void OnActivaAnimationFinished()
	{
		sprite.Play("idle");
	}
}
