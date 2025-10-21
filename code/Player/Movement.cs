using Godot;
using System;

public partial class Movement : Node
{
	float Speed = 300;
	[Export] private Gorfena parent;
	public override void _Ready()
	{
		parent ??= GetParent<Gorfena>();
	}

	public override void _Process(double delta)
	{
		Vector2 Direction = Vector2.Zero;

		if (Input.IsActionPressed("w"))
			Direction += Vector2.Up;
		if (Input.IsActionPressed("s"))
			Direction += Vector2.Down;
		if (Input.IsActionPressed("a"))
			Direction += Vector2.Left;
		if (Input.IsActionPressed("d"))
			Direction += Vector2.Right;
		float speed = Speed * (float)delta;
		if (Input.IsActionPressed("shift"))
			 speed = (40 + Speed) * (float)delta;

		parent.Position +=speed * Direction.Normalized();
	}
}
