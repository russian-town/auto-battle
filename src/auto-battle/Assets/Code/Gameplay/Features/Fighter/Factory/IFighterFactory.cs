using UnityEngine;

namespace Code.Gameplay.Features.Fighter.Factory
{
    public interface IFighterFactory
    {
        GameEntity CreateFighter(Vector3 at, Quaternion rotation, FighterTypeId fighterTypeId);
    }
}
