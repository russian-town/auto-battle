using Code.Gameplay.Levels;
using UnityEngine;
using Zenject;

public class UIInitializer : MonoBehaviour, IInitializable
{
    [SerializeField] private Transform _uiRoot;
    
    private ILevelDataProvider _levelDataProvider;

    [Inject]
    public void Construct(ILevelDataProvider levelDataProvider) =>
        _levelDataProvider = levelDataProvider;

    public void Initialize()
    {
        _levelDataProvider.SetUIRoot(_uiRoot);
    }
}
