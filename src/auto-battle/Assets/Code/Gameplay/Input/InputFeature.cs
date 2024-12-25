using Code.Gameplay.Input.Systems;

namespace Code.Gameplay.Input
{
    public class InputFeature : Feature
    {
        public InputFeature(GameContext game)
        {
            Add(new InitializeInputSystem());
            Add(new EmitInputSystem(game));
        }
    }
}
