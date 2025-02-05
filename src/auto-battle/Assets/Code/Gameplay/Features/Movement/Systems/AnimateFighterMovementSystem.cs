using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class AnimateFighterMovementSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _fighters;

        public AnimateFighterMovementSystem(GameContext game)
        {
            _fighters = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Fighter,
                    GameMatcher.FighterAnimator,
                    GameMatcher.Direction
                    ));
        }

        public void Execute()
        {
            foreach (var fighter in _fighters)
            {
                if(fighter.isMoving && fighter.Direction.x > 0)
                    fighter.FighterAnimator.PlayMoveForward();
                else if(fighter.isMoving && fighter.Direction.x < 0)
                    fighter.FighterAnimator.PlayMoveBackward();
                else if(!fighter.isMoving)
                    fighter.FighterAnimator.PlayIdle();
            }
        }
    }
}
