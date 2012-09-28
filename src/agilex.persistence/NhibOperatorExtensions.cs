namespace agilex.persistence
{
    public static class NhibOperatorExtensions
    {
        public static int ParseInt(this string s)
        {
            return int.Parse(s);
        }
    }
}