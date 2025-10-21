using Godot;
using System;

public partial class Gorfena : Node2D
{

	[Export] private AnimatedSprite2D Animation;
	
	public override void _Ready()
	{
		Animation.Play();
		
	}

	public override void _Process(double delta)
	{
	}
}
