using System;
using System.Collections.Generic;
using Avalonia.Automation;
using Avalonia.Input;
using Avalonia.Controls;
using Avalonia.Threading;
using Avalonia.Media;
using System.IO;
using System.Linq;

namespace AsteroidDestroyer;

public class Game
{
    public List<Entity> Entities = new();
    public int Score { get; private set; }
    public bool GameOver { get; private set; }
    public Spaceship Spaceship { get; private set; }
    private Random rnd = new();

    public void StartNewGame()
    {
        Entities.Clear();

        Score = 0;
        GameOver = false;

        ScoreDisplay scoreDisplay = new(this);
        AddEntity(scoreDisplay);

        GameTimer gameTimer = new GameTimer(this);
        AddEntity(gameTimer);

        Spaceship = new Spaceship(this, "spaceship");
        AddEntity(Spaceship);
    }

    public void AddEntity(Entity entity)
    {
        Entities.Add(entity);
    }

    public void SetGameOver()
    {
        GameOver = true;
    }

    public void Update()
    {
        SpawnAsteroid();

        foreach (Entity e in Entities)
        {
            if (e.IsActive)
                e.Update();
        }

        HandleCollision();
    }

    private void SpawnAsteroid()
    {
        if (rnd.Next(1, 101) < 4)
        {
            Asteroid asteroid = new(this);
            AddEntity(asteroid);
        }
    }

    public void HandleInput(Key key)
    {
        switch (key)
        {
            case Key.Up:
            case Key.Down:
            case Key.Left:
            case Key.Right:
                Spaceship.Move(key);
                break;
            case Key.Space:
                Score -= 10;
                Spaceship.Shoot();
                break;
        }

        Spaceship.Visual.RenderTransform = new RotateTransform(Spaceship.Angle);
    }

    private void HandleCollision()
    {
        HandleAsteroidBulletCollision();
        HandleAsteroidSpaceshipCollision();
    }

    private void HandleAsteroidBulletCollision()
    {
        foreach (var asteroid in Entities.OfType<Asteroid>())
        {
            if (asteroid.IsActive)

            {
                foreach (var bullet in Entities.OfType<Bullet>())
                {
                    if (bullet.IsActive && asteroid.GetBounds().Intersects(bullet.GetBounds()))
                    {
                        Score += 50;
                        asteroid.SetInactive();
                        bullet.SetInactive();
                    }
                }
            }
        }
    }

    private void HandleAsteroidSpaceshipCollision()
    {
        foreach (var asteroid in Entities.OfType<Asteroid>())
        {
            if (asteroid.IsActive &&
                asteroid.GetBounds().Intersects(Spaceship.GetBounds()))
            {
                GameOver = true;
            }
        }
    }
}