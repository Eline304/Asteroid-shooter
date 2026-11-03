using System;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Automation.Peers;
namespace AsteroidDestroyer;

public class Asteroid : SpriteEntity
{
    public Asteroid(Game game) :base(game, 32, 32, "asteroid", true, 0, 0, 0)
    {
        Random rnd = new Random();
        int SpawnSide = rnd.Next(1, 5);
        int rndY = rnd.Next(1, 451);
        int rndX = rnd.Next(1, 801);
        if (SpawnSide == 1)
        {
            X = rndX;
            Y = 0 - Height;
            Angle =  180;
        }

        else if (SpawnSide == 2)
        {
            X = rndX;
            Y = 450;
            Angle = 0;
        }
        else if (SpawnSide == 3)
        {
            X = 0 - Width;
            Y = rndY;
            Angle = 90;
        }
        else
        {
            X = 850 - Height;
            Y = rndY;
            Angle = 270;
        }
        Speed = rnd.Next(1, 7);
    }

    public override void Update()
    {
        if (Angle == 0)
        {
            Y -= Speed;
        }

        else if (Angle == 180)
        {
            Y += Speed;
        }

        else if (Angle == 270)
        {
            X -= Speed;
        }

        else
        {
            X += Speed;
        }

        if (OutOfBounds())
            {
                SetInactive();
            }
    }
}
