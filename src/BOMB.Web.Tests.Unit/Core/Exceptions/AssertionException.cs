// -----------------------------------------------------------------------
// Grabbed from the MVCContrib project
// -----------------------------------------------------------------------

namespace BOMB.Web.Tests.Core.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    ///<summary>
    /// This exception is thrown by the TestHelper extension methods.  This allows this project to be unit test framework agnostic.
    ///</summary>
    public class AssertionException : System.Exception
    {
        public AssertionException(string message) : base(message) { }

        public override string StackTrace
        {
            get
            {
                string Namespace =
                this.GetType().Namespace;
                var stacktracestring =
                    SplitTheStackTraceByEachNewLine().Where(
                        s => !s.TrimStart(' ').StartsWith("at " + Namespace)).ToArray();
                return JoinArrayWithNewLineCharacters(stacktracestring);
            }
        }

        private string[] SplitTheStackTraceByEachNewLine()
        {
            return base.StackTrace.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }

        private string JoinArrayWithNewLineCharacters(string[] stacktracestring)
        {
            return string.Join(Environment.NewLine, stacktracestring);
        }
    }
}
