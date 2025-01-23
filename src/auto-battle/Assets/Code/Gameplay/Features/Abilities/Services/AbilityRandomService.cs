using Code.Gameplay.Common.Random;

namespace Code.Gameplay.Features.Abilities.Services
{
    public class AbilityRandomService
    {
        private readonly IRandomService _random;

        public AbilityRandomService(IRandomService random)
        {
            _random = random;
        }
    }
}
