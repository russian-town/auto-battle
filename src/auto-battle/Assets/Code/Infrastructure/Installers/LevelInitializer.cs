using System.Collections.Generic;
using Code.Gameplay.Levels;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class LevelInitializer : MonoBehaviour, IInitializable
    {
        [SerializeField] private List<PositionSetup> _positionSetups = new();
        [SerializeField] private Transform _uiRoot;
        
        private ILevelDataProvider _levelDataProvider;

        [Inject]
        public void Construct(ILevelDataProvider levelDataProvider) =>
            _levelDataProvider = levelDataProvider;

        public void Initialize()
        {
            _levelDataProvider.SetUIRoot(_uiRoot);
            
            foreach (var positionSetup in _positionSetups)
                _levelDataProvider.RegisterPositionSetup(positionSetup);
        }
    }
}
