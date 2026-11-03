using Avalonia.Controls;
using Avalonia.Media;

namespace AsteroidDestroyer;

public class GameTimer : Entity
{
    private TextBlock _textBlock;

    private int Seconds;

    private int Tick;

    public GameTimer(Game game) : base(game, 0, 0, true, 0, 0, 10)
    {
        _textBlock = new TextBlock
        {
            FontSize = 20,
        };

        Game = game;
        Visual = _textBlock;
        Seconds = 60;
        Tick = 0;
    } 

    public override void Update()
    {
        Tick += 1;
        if (Tick == 30)
        {
            Seconds -= 1;
            Tick = 0;
        }

        if (Seconds == 0)
        {
            Game.SetGameOver();
        }

        _textBlock.Text = $"Time: {Seconds} seconds";
    }
}