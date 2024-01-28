using Godot;
using System;

public partial class ViewControl : Control
{
	[Export] public RichTextLabel LineText;
	[Export] public Button ContinueButton;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}
}
