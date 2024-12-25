namespace Code.Infrastructure.Identifiers
{
    public class IdentifiersService : IIdentifiersService
    {
        private int _lastId = 1;

        public int Next() =>
            _lastId++;
    }
}
