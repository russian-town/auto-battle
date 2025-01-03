namespace Code.Gameplay.Common.Random
{
    public class RandomService : IRandomService
    {
        public float Range(float min, float max) =>
            UnityEngine.Random.Range(min, max);

        public int Range(int min, int max) =>
            UnityEngine.Random.Range(min, max);
    }
}
