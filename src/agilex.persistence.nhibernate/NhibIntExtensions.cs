namespace agilex.persistence.nhibernate
{
    public static class NhibIntExtensions
    {
        public static bool GreaterThan(this string s, int d)
        {
            return int.Parse(s) > d;
        }
        public static bool GreaterThanEqualTo(this string s, int d)
        {
            return int.Parse(s) >= d;
        }
        public static bool LessThan(this string s, int d)
        {
            return int.Parse(s) < d;
        }
        public static bool LessThanEqualTo(this string s, int d)
        {
            return int.Parse(s) <= d;
        }
        public static bool EqualTo(this string s, int d)
        {
            return int.Parse(s) == d;
        }
        public static bool NoEqualTo(this string s, int d)
        {
            return int.Parse(s) != d;
        }
    }
}