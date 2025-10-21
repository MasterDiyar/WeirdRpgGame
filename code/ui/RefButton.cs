using Godot;
using System;

public partial class RefButton : Button
{
	[Export] private PackedScene _refScene;
	
	public override void _Ready()
	{
		Pressed += Press;
	}

	private void Press()
	{
		var loadScene = _refScene.Instantiate();
		
		GetParent()
			.GetParent()
			.AddChild(loadScene);
		
		GetParent()
			.QueueFree();
	}
}
