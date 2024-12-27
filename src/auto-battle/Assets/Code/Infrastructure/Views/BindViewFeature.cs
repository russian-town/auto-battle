using Code.Infrastructure.Systems;
using Code.Infrastructure.Views.Systems;

namespace Code.Infrastructure.Views
{
    public class BindViewFeature : Feature
    {
        public BindViewFeature(ISystemFactory systems)
        {
            Add(systems.Create<BindEntityViewFromPathSystem>());
            Add(systems.Create<BindEntityViewFromPrefabSystem>());
        }
    }
}
