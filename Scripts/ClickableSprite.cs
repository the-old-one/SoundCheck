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
		SetTint(IsActive);
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

	private void SetTint(bool tintOn)
	{
		if (tintOn)
		{
			this.Modulate = new Color(1, 1, 1, 1);
		}
		else
		{
			this.Modulate = new Color(1, 1, 1, 0.5f);
		}
	}
}
