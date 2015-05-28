# RCRunner

RCRunner is a tool designed to run automated test scripts in parallel using Selenium Grid. It is written in C# and it allows full customization. There are a few things necessary if you want to use it: 

  - You will need ```Visual Studio 2013``` and .```Net framework 4.5```.
  - Your test scripts should already be using ```Selenium Grid```.
  - You need a full ```Selenium Grid``` setup with nodes, hub, etc.

Currently, ```RCRunner``` only supports test scripts that use ```MSTest```. But since it is written having plugins in mind, it is very easy to create your own plugin to support other frameworks such as ```NUnit```, ```MBUnit```, etc. Those are the steps necessary to create your custom plugin:

  - Create a new ```Class Library``` and add a reference to RCRunner.
  - Create a public class that implements ```ITestFrameworkRunner``` (check the ```MSTestWrapper``` class if you need an example).
  - Build your project.
  - Copy the DLL to the ```<path_of_rcrunner_exe>\Plugins\TestRunners```.
  - Run RCRunner. If everything is fine, you will see your custom runner in the RCRunner main screen "Test framework" combobox.

RCRunner is under construction and it is currently in a beta stage. Things may not work properly.

In case you need help, please [submit an issue](https://github.com/colutti/RCRunner/issues/new) and I'll be glad to help.

### Version
Beta
