using System;
using System.Diagnostics;
using System.Net.Mail;
using System.Text;

namespace agilex.persistence.nhibernate
{
    public static class NhibOperatorExtensions
    {
        public static bool CompareInt(this string s, string @operator, int d)
        {
            switch (@operator)
            {
                case ">":
                    Debug.WriteLine(string.Format("!!!!!!!!!!!!! {0} {1} {2} : {3}", s, @operator, d, int.Parse(s) > d));
                    return int.Parse(s) > d;
                case ">=":
                    Debug.WriteLine(string.Format("!!!!!!!!!!!!! {0} {1} {2} : {3}", s, @operator, d, int.Parse(s) >= d));
                    return int.Parse(s) >= d;
                case "<":
                    Debug.WriteLine(string.Format("!!!!!!!!!!!!! {0} {1} {2} : {3}", s, @operator, d, int.Parse(s) < d));
                    return int.Parse(s) < d;
                case "<=":
                    Debug.WriteLine(string.Format("!!!!!!!!!!!!! {0} {1} {2} : {3}", s, @operator, d, int.Parse(s) <= d));
                    return int.Parse(s) <= d;
                case "=":
                    Debug.WriteLine(string.Format("!!!!!!!!!!!!! {0} {1} {2} : {3}", s, @operator, d, int.Parse(s) == d));
                    return int.Parse(s) == d;
                case "==":
                    Debug.WriteLine(string.Format("!!!!!!!!!!!!! {0} {1} {2} : {3}", s, @operator, d, int.Parse(s) == d));
                    return int.Parse(s) == d;
                case "!=":
                    Debug.WriteLine(string.Format("!!!!!!!!!!!!! {0} {1} {2} : {3}", s, @operator, d, int.Parse(s) != d));
                    return int.Parse(s) != d;
                case "<>":
                    Debug.WriteLine(string.Format("!!!!!!!!!!!!! {0} {1} {2} : {3}", s, @operator, d, int.Parse(s) != d));
                    return int.Parse(s) != d;
                default: throw new Exception(string.Format("Do not understand operator {0} when calling NhibOperatorExtensions.CompareInt", @operator));
            }
        }
    }
}