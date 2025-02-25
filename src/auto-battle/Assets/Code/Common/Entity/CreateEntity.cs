namespace Code.Common.Entity
{
    public static class CreateEntity
    {
        public static GameEntity Empty(string name) =>
            Contexts.sharedInstance.game
                .CreateEntity()
                .AddName(name);
    }
}
