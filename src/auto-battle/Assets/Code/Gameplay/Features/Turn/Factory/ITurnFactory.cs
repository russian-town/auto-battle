namespace Code.Gameplay.Features.Turn.Factory
{
    public interface ITurnFactory
    {
        GameEntity CreateTurn(int targetId);
    }
}
