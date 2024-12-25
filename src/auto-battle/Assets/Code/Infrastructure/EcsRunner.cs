using System;
using Code.Gameplay;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure
{
    public class EcsRunner : MonoBehaviour
    {
        private BattleFeature _battleFeature;
        private GameContext _game;

        [Inject]
        public void Construct(GameContext game) =>
            _game = game;
        
        private void Start()
        {
            _battleFeature = new BattleFeature(_game);
            _battleFeature.Initialize();
        }

        private void Update()
        {
            _battleFeature.Execute();
            _battleFeature.Cleanup();
        }

        private void OnDestroy()
        {
            _battleFeature.TearDown();
        }
    }
}
