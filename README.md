# NodeosDeepMindSwig

C# Application wrapping AntelopeIO's Nodeos as library invoking C#-delegates through a director on deep-mind-events without logging to stdout

## About
Weekend project testing if Nodeos can be wrapped with SWIG in a library to call methods in the wrapping language via Swig directors. 

The goal is to develop a language compatible better communication-interface for processing deep-mind-events without the use of stdout or pipes and heavy serialization and deserialization of binary data.

## Try yourself
1. Clone https://github.com/cmadh/leap and checkout the **deepmind_swig_csharp**-branch
	2. Clone/Update/Init submodules
	3. Open the project with an IDE of your choice
	4. Turn OFF Boost_USE_STATIC_LIBS (change Boost_USE_STATIC_LIBS ON to Boost_USE_STATIC_LIBS OFF)
	5. Build **nodoes_swig** located in the swig-folder using cmake
	6. Copy nodeos_swig.so to /lib/libnodeos_swig.so (name needs to be changed)
	7. Create the necessary directories and files you need to start Nodeos (config.ini, genesis.json, data-dir etc,)
2. Clone this Repo
	3. Copy nodeos_swig.so to /NodeosSwigWrapper/NodeosSwigSharp (name stays nodeos_swig.so here)
	4. Open NodeosSwigTester.sln with Visual Studio
	5. Connect through ssh or WSL to the machine where libnodeos_swig.so was previously installed
	6. Change data-dir, config-dir and other arguments passed to Nodeos in /NodeosSwigWrapper/NodeosProcess
	7. Build and Run
  