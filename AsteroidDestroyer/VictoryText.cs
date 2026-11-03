using Avalonia.Controls;
using Avalonia.Media;

namespace AsteroidDestroyer;

public class VictoryText : Entity
{
    private TextBlock _textBlock;

    public VictoryText(Game game) : base(game, 0, 0, true, 0, 150, 150)
    {
        _textBlock = new TextBlock
        {
            FontSize = 20,
        };

        Visual = _textBlock;

        if (game.Score < 100)
        {
            _textBlock.Text = "You survived, but more courage next time!";
        }
        else if (game.Score >= 100 && game.Score <= 500)
        {
            _textBlock.Text = "Solid performance! You handled those asteroids well!";
        }

        else if (game.Score >= 500 && game.Score <= 1000)
        {
            _textBlock.Text = "You're a space ace! Few can handle asteroids like you!";
        }

        else
        {
            _textBlock.Text = "You're a true space hero! A legend in the galaxy!";
        }
    }

    public override void Update()
    {
    }
}