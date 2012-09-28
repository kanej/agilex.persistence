using System;

namespace agilex.persistence.nhibernate
{
    public static class NhibOperatorExtensions
    {
        public static bool CompareInt(this string s, string @operator, int d)
        {            switch (@operator)
        {
            case ">":
                return int.Parse(s) > d;
            case ">=":
                return int.Parse(s) >= d;
            case "<":
                return int.Parse(s) < d;
            case "<=":
                return int.Parse(s) <= d;
            case "=":
                return int.Parse(s) == d;
            case "==":
                return int.Parse(s) == d;
            case "!=":
                return int.Parse(s) != d;
            case "<>":
                return int.Parse(s) != d;
            default: throw new Exception(string.Format("Do not understand operator {0} when calling NhibOperatorExtensions.CompareInt", @operator));
        }
        }
    }
}