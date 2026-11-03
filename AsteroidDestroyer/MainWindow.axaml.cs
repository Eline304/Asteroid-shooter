using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using System;
using Avalonia.Input;
using Avalonia.Media;
using System.Runtime.CompilerServices;
using Avalonia.Win32;
using Avalonia.Markup.Xaml.MarkupExtensions;
using Avalonia.Platform;
using System.Threading;

namespace AsteroidDestroyer;

public partial class MainWindow : Window
{
    private Game game;
    private DispatcherTimer _timer;
    public MainWindow()
    {
        InitializeComponent();

        game = new Game();
        StartButton.Click += StartClicked;
    }

    private void StartClicked(object? sender, RoutedEventArgs e)
    {
        game.Entities.Clear();
        Canvas.Children.Clear();
        game.StartNewGame();
        StartButton.IsVisible = false;

        _timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(1000 / 30)
        };

        _timer.Tick += (_, _) =>
        {
            game.Update();

            if (game.GameOver)
            {
                EndGame();
            }

            foreach (Entity e in game.Entities)
            {
                if (e.IsActive)
                {
                    if (!Canvas.Children.Contains(e.Visual))
                    {
                        Canvas.Children.Add(e.Visual);
                    }
                    Canvas.SetLeft(e.Visual, e.X);
                    Canvas.SetTop(e.Visual, e.Y);
                }
                else
                {
                    if (Canvas.Children.Contains(e.Visual))
                    {
                        Canvas.Children.Remove(e.Visual);
                    }
                }
            }


        };

        _timer.Start();
    }

    private void EndGame()
    {
        VictoryText victoryText = new VictoryText(game);
        Canvas.Children.Add(victoryText.Visual);
        Canvas.SetLeft(victoryText.Visual, victoryText.X);
        Canvas.SetTop(victoryText.Visual, victoryText.Y);
        _timer.Stop();
        StartButton.IsVisible = true;
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        base.OnKeyDown(e);
        game.HandleInput(e.Key);
    }
}
