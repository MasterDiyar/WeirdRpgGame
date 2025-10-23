using Godot;
using System;

public partial class MapWorld : Node2D
{
	private PackedScene _chunkScene = GD.Load<PackedScene>("res://scene/worldgen/world_gen.tscn");
	private WorldGen[]  _chunks     = new WorldGen[9];
	public override void _Ready()
	{
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				var k = i * 3 + j;
				_chunks[k] = _chunkScene.Instantiate<WorldGen>();
				_chunks[k].Position = new Vector2(-1600 + 1600 * i, -1600 + 1600 * j);
				_chunks[k].Seed = 12345;
				_chunks[k].noiseOffset = Vector2.Down * 100 * i + Vector2.Right * j * 100;
				AddChild(_chunks[k]);
			}
			
		}
		//К сожалению нынешних моих сил и обстоятелстьв не хватило чтобы делать генеративный мир
		// Так что теперь это свалка кода
	}

}
