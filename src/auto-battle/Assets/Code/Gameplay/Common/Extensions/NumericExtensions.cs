namespace Code.Gameplay.Common.Extensions
{
    public static class NumericExtensions
    {
        public static float ZeroIfNegative(this float value) => value >= 0f ? value : 0f;
        public static float ZeroIfNegative(this int value) => value >= 0 ? value : 0;
    }
}
