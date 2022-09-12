using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodeosSwigWrapper;

// ReSharper disable once CheckNamespace
public partial class NodeosSwig
{
    public void Start(IList<string> args, SwigLoggerBase swigLoggerBase)
    {
        Start(args.Count, args.ToList(), swigLoggerBase);
    }
}
