using System;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Media;
namespace AsteroidDestroyer;

public abstract class SpriteEntity : Entity
{

    public SpriteEntity(Game game, int width, int height, string Asset, bool True, int angle, int x, int y) : base(game, width, height, true, angle, x, y)
    {
        Visual = new Image()
        {
            Source = new Bitmap(AssetLoader.Open(new Uri($"avares://AsteroidDestroyer/Assets/{Asset}.png"))),
            Width = width,
            Height = height
            };
    }
}