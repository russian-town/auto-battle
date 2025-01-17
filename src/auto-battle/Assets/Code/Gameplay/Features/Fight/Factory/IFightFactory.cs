namespace Code.Gameplay.Features.Fight.Factory
{
    public interface IFightFactory
    {
        GameEntity CreateFight(float cooldown, int targetId, int producerId);
    }
}
