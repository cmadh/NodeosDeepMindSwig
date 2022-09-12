# NodeosDeepMindSwig

C# Application wrapping AntelopeIO's Nodeos as library invoking C#-Methods through a director on deep-mind-events without logging to stdout

## About
Weekend project testing if Nodeos can be wrapped with SWIG in a library to call methods in the wrapping language via Swig directors. 

The goal is to develop a language compatible better communication-interface for processing deep-mind-events without the use of stdout or pipes and heavy serialization and deserialization of binary data.

## Directories and Classes
- /NodeosSwigWrapper/NodeosSwigSharp contains generated Wrapper Code
- /NodeosSwigWrapper/NodeosSwigExtensions extends the generated Types
- SwigDataWrapper.cs allows allows high performance copying of binary data owned by the nodeos process
- Methods in SwigLogger.cs are invoked through a swig-director passed to Nodeos
- SwigLogProcessor.cs implements asynchronity by queueing data received (and copied so it's owned by the C#-process) and allows to build any form of consumer on top

## Try yourself

1. Clone https://github.com/cmadh/leap and checkout the **deepmind_swig_csharp**-branch
2. Clone/Update/Init submodules
3. Open the project with an IDE of your choice
4. Turn OFF Boost_USE_STATIC_LIBS (change Boost_USE_STATIC_LIBS ON to Boost_USE_STATIC_LIBS OFF)
5. Build **nodoes_swig** located in the swig-folder using cmake
6. Copy nodeos_swig.so to /lib/libnodeos_swig.so (name needs to be changed)
7. Create the necessary directories and files you need to start Nodeos (config.ini, genesis.json, data-dir etc,)
8. Clone this Repo
9. Copy nodeos_swig.so to /NodeosSwigWrapper/NodeosSwigSharp (name stays nodeos_swig.so here)
10. Open NodeosSwigTester.sln with Visual Studio
11. Connect through ssh or WSL to the machine where libnodeos_swig.so was previously installed
12. Change data-dir, config-dir and other arguments passed to Nodeos in /NodeosSwigWrapper/NodeosProcess
13. Build and Run
  
  
# SWIG Directors
Directors-Support is available for different languages:
- C# https://www.swig.org/Doc3.0/CSharp.html#CSharp_directors
- GO https://www.swig.org/Doc3.0/Go.html#Go_director_classes
- Java https://www.swig.org/Doc1.3/Java.html#java_directors
- Python https://www.swig.org/Doc1.3/Python.html#Python_nn33
