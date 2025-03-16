namespace Code.Gameplay.Common.Time
{
    public class TimeService : ITimeService
    {
        public float DeltaTime => UnityEngine.Time.deltaTime;
        public float Time => UnityEngine.Time.time;
    }
}
