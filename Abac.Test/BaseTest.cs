using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Abac.Test.Business;

namespace Abac.Test
{
    internal abstract class BaseTest
    {
        private static void Main()
        {
            new TestSerialization().RunAll();
        }

        protected internal abstract bool RunAllInternal();

        internal bool RunAll()
        {
            var suiteName = string.Format("Running test suite {0}", new StackFrame().GetMethod().DeclaringType);
            var delim = new string('-', suiteName.Length);
            Debug.WriteLine(delim);
            Debug.WriteLine(suiteName);
            Debug.WriteLine(delim);

            Debug.Indent();
            var start = DateTime.Now;
            var result = RunAllInternal();
            var duration = DateTime.Now.Subtract(start).TotalMilliseconds;
            Debug.Unindent();
            Debug.WriteLine(delim);
            Debug.WriteLine(string.Format("Total: {0} {1:0}ms", result ? "PASSED" : "FAILED", duration));
            Debug.WriteLine(delim);

            return result;
        }

        protected internal bool RunTest(Test test)
        {
            var start = DateTime.Now;
            Debug.Write(string.Format("Running test {0}... ", test.Method.Name));
            try
            {
                test();
                Debug.WriteLine(string.Format("{0:0}ms OK", DateTime.Now.Subtract(start).TotalMilliseconds));
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Format("{0} ERROR", ex.Message));
                return false;
            }
        }

        internal static string RemoveEmptySpaces(string s)
        {
            return Regex.Replace(s, @"\s+", "");
        }

        protected internal delegate void Test();
    }
}