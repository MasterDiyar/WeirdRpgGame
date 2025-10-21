using Godot;
using System;

public partial class WorldGen : TileMapLayer
{
    [Export] private int mapWidth = 100;
    [Export] private int mapHeight = 100;
    [Export] private float noiseScale = 0.01f;
    [Export] private int seed = (int) GD.Randi();

    [Export] private Vector2 noiseOffset = new Vector2(100, 200);

    private FastNoiseLite noise, tempNoise;

    public override void _Ready()
    {
        base._Ready();
        GD.Print("WorldGen v1.0, placed seed: "+seed);
        GenerateMap();
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("w"))
        {
            noiseScale += 0.01f;
            GenerateMap();
        }
    }

    private void GenerateMap()
    {
        Clear();
        noise = new FastNoiseLite(); 
        tempNoise = new FastNoiseLite();
        
        noise.SetSeed(seed); 
        tempNoise.SetSeed(seed+1);
        
        noise.NoiseType = FastNoiseLite.NoiseTypeEnum.Perlin;
        tempNoise.NoiseType = FastNoiseLite.NoiseTypeEnum.Perlin;
        
        noise.Frequency = noiseScale;
        tempNoise.Frequency = noiseScale;

        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                float temperature = noise.GetNoise2D(x + noiseOffset.X, y + noiseOffset.Y) +
                                    tempNoise.GetNoise2D(x + noiseOffset.X, y + noiseOffset.Y);
                //temperature *= 0.5f;
                Vector2I tileId = GetTileByTemperature(temperature);
                SetCell(new Vector2I(x, y), 1, tileId); 
            }
        }

        GD.Print(GetCellAtlasCoords(Vector2I.One));
    }

    private Vector2I GetTileByTemperature(float t)
    {
        return t switch
        {
            < -0.5f => new Vector2I(0, 0),
            < 0f => new Vector2I(1, 0),
            < 0.5f => new Vector2I(1, 1),
            _ => new Vector2I(0, 1)
        };
    }
}