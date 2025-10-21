using Godot;
using System;
using System.Collections.Generic;

public partial class MapWorld : Node2D
{
    List<Chunk>  Chunks;
    PackedScene ChunkScene = GD.Load<PackedScene>("res://scene/worldgen/map_world.tscn");
    
    [Export] Gorfena player;
    
    private Vector2I center;

    private int distance = 2, chunkCubes = 100;

    public override void _Ready()
    {
        LoadChunks();
    }

    private void LoadChunks()
    {
        center = new Vector2I((int)player.GlobalPosition.X%1600, (int)player.GlobalPosition.Y%1600);
        
    }
}
