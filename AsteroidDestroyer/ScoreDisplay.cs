using Avalonia.Controls;
using Avalonia.Media;

namespace AsteroidDestroyer;

public class ScoreDisplay : Entity
{
    private TextBlock _textBlock;

    public ScoreDisplay(Game game) : base(game, 0, 0, true, 0, 650, 10)
    {
        _textBlock = new TextBlock
        {
            FontSize = 20,
        };

        Visual = _textBlock;
    }

    public override void Update()
    {
        _textBlock.Text = $"Score: {Game.Score}";

    }
}