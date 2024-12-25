using Entitas;
using UnityEngine;

namespace Code.Gameplay.Input.Systems
{
    public class EmitInputSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _inputs;

        public EmitInputSystem(GameContext game)
        {
            _inputs = game.GetGroup(GameMatcher.Input);
        }

        public void Execute()
        {
            foreach (var input in _inputs)
            {
                if (GetAxis().sqrMagnitude > 0)
                    input.ReplaceAxisInput(GetAxis());
                else if (input.hasAxisInput)
                    input.RemoveAxisInput();
            }
        }

        private static Vector2 GetAxis() =>
            new(UnityEngine.Input.GetAxis("Horizontal"),
                UnityEngine.Input.GetAxis("Vertical"));
    }
}
