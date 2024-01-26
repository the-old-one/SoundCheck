using Godot;
using System;

public partial class ClickableSprite : Area2D
{
	[Signal]
	public delegate void SpriteClickedEventHandler(ClickableSprite clickableSprite);
	
	public bool IsActive;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.InputEvent += OnClick;
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
		if (IsActive)
		{
			// Call the signal
			EmitSignal(SignalName.SpriteClicked, this);
		}
	}
}
