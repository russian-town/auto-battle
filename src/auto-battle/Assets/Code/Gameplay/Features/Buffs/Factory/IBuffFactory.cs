namespace Code.Gameplay.Features.Buffs.Factory
{
    public interface IBuffFactory
    {
        GameEntity CreateBuff(BuffTypeId typeId);
    }
}
