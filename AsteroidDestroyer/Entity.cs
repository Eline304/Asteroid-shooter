using System;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Interactivity;
using Avalonia.Threading;
using Avalonia;


namespace AsteroidDestroyer;

public abstract class Entity
{
    public Game game {get; protected set;}
    public int Speed {get; protected set;}
    public int X {get; protected set;}
    public int Y {get; protected set;}
    public int Width { get; private set;}
    public int Height { get; private set;}
    public Control Visual { get; set; }
    public bool IsActive { get; private set; }
    public int Angle { get; protected set; }

    public Game Game;

    public Entity(Game game, int width, int height, bool True, int angle, int x, int y)
    {   X = x;
        Y = y;
        Game = game;
        Width = width;
        Height = height;
        IsActive = True;
        Angle = angle;
    }
    public Rect GetBounds()
    {
        return new Rect(X + 10, Y + 10, Width - 10, Height);
    }
    public abstract void Update();
    public void SetInactive()
    {
        IsActive = false;
    }

    public bool OutOfBounds()
    {
        return X > 800 || Y > 450 || X < 0 - Width || Y < 0 - Height;
    }
}