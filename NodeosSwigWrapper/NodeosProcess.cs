using System.Runtime.InteropServices;
using NodeosSwigWrapper.NodeosSwigExtensions;

namespace NodeosSwigWrapper
{
    // Simple test-class to Start Nodeos while passing
    // a SwigLogger to receive deep-mind events and their data in C#
    // without the need of writing to stdout or similar
    public class NodeosProcess
    {
        public void StartNodeos()
        {
            // Create new NodeosSwig, wrapping the swig-enabled Nodeos-library
            var nodeosSwig = new NodeosSwig();
            
            // Create a new SwigLogProcessor which copies data to a queue to enable asynchronity
            var swigLogProcessor = new SwigLogProcessor();

            // Create new SwigLogger (inheriting SwigLoggerBase)
            // whichs Methods are invoked from within the Nodeos-lib/compiled C++-Code
            var swigLogger = new SwigLogger(swigLogProcessor);

            // define Args to be passed to Nodeos
            var args = new List<string>()
            {
                "--delete-all-blocks",
                "--config-dir", "/home/cmadh/swig_testing/config/",
                "--genesis-json", "/home/cmadh/swig_testing/genesis.json",
                "--data-dir", "/home/cmadh/swig_testing/data/"
            };

            // Start Nodeos while passing args and the SwigLogger
            // with Methods being be invoked on dfuse-events
            nodeosSwig.Start(args, swigLogger);
        }
    }
}