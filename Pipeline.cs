using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace designIssueExample
{
    public class Pipeline
    {
        public static void Process<T1, T2>(Func<T1> source, Func<T1, T2> processor, Action<T2> sink )
        {
            sink(processor(source()));
        }
    }
}
