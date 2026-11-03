using System;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Media;
using Avalonia.Input;

namespace AsteroidDestroyer;

public class Spaceship : SpriteEntity
{
    public Spaceship(Game game, string Asset) : base(game, 32, 32, "spaceship", true, 0, 400, 225)
    {
    }

    public override void Update()
    {
    }
    
    public void Move(Key key)
    { 
        if (key == Key.Up)
        {
            MoveUp();
        }

        else if (key == Key.Down)
        {
            MoveDown();
        }

        else if (key == Key.Left)
        {
            MoveLeft();
        }

        else if (key == Key.Right)
        {
            MoveRight();
        }
    }

    private void MoveUp()
    {
        Angle = 0;
        Y -= 5; 
        if (Y < 0)
        {
            Y = 0;
        }
    }

    private void MoveDown()
    {
        Angle = 180;
        Y += 5;
        if (Y > 450 - Height)
        {
            Y = 450 - Height;
        }
    }

    private void MoveLeft()
    {
        Angle = 270;
        X -= 5;
        if (X < 0)
        {
            X = 0;
        }
    }

    private void MoveRight()
    {
        Angle = 90;
        X += 5;
        if (X > 800 - Width)
        {
            X = 800 - Width;
        }
    }


    public void Shoot()
    {
        Bullet bullet = new(Game, this);
        Game.AddEntity(bullet);
        bullet.Visual.RenderTransform = new RotateTransform(Game.Spaceship.Angle);
    }
}


