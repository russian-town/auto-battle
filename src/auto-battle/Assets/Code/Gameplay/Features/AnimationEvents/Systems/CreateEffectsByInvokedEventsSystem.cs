using Code.Gameplay.Features.Effect.Factory;
using Entitas;

namespace Code.Gameplay.Features.AnimationEvents.Systems
{
    public class CreateEffectsByInvokedEventsSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IEffectFactory _effectFactory;
        private readonly IGroup<GameEntity> _animationEvents;

        public CreateEffectsByInvokedEventsSystem(GameContext game, IEffectFactory effectFactory)
        {
            _game = game;
            _effectFactory = effectFactory;
            
            _animationEvents = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.AnimationEvent,
                    GameMatcher.ProducerId,
                    GameMatcher.TargetId,
                    GameMatcher.EffectSetups,
                    GameMatcher.Invoked
                    ));
        }

        public void Execute()
        {
            foreach (var animationEvent in _animationEvents)
            foreach (var effectSetup in animationEvent.EffectSetups)
            {
                var producer = _game.GetEntityWithId(animationEvent.ProducerId);

                var totalDamage = producer.Damage
                                  * effectSetup.Percent
                                  * producer.AttackPower;
                
                _effectFactory.CreateEffect(
                    effectSetup,
                    totalDamage,
                    animationEvent.ProducerId,
                    animationEvent.TargetId);
            }
        }
    }
}
