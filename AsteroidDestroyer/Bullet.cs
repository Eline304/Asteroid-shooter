using System;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Media;

namespace AsteroidDestroyer
{
    public class Bullet : SpriteEntity
    {
        public Bullet(Game game, Spaceship spaceship) : base(game, 32, 32, "bullet", true, spaceship.Angle, spaceship.X, spaceship.Y)
        {
            Speed = 15;
        }

        public override void Update()
        {
            switch (Angle)
            {
                case 0:
                    Y -= Speed;
                    break;

                case 180:
                    Y += Speed;
                    break;

                case 270:
                    X -= Speed;
                    break;

                case 90:
                    X += Speed;
                    break;
            }

            if (OutOfBounds())
            {
                SetInactive();
            }
        }
    }
}
