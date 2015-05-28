# RCRunner

RCRunner is a toll designed to run automated tests scripts in parallel using Selenium Grid. It is written in C# and it allows full customization. There are a few things necessary if you want to use it: 

  - You will need ```Visual Studio 2013``` and .```Net framework 4.5```
  - Your test scripts should already be using ```Selenium Grid```
  - You need a full ```Selecnium Grid``` setup with nodes, hub, etc.

Currently, ```RCRunner``` only supports tests scripts that use ```MSTest```. But since it is written having plugins in mind, it is very easy to create your own plugin to support other frameworks such as ```NUnit```, ```MBUnit```, etc. Those are the steps necessary to create your custom plugin:

  - Create a ```Visual Studio Class Library Solution```
  - Add a reference on your library to RCRunner
  - Create a public class that implements the ```ITestFrameworkRunner``` interface (check the ```MSTestWrapper``` class if you need more information on how to do that)
  - Build your project
  - Copy the DLL to the ```<path_of_rcrunner_exe>\Plugins\TestRunners```
  - Run RCRunner. If everything is fine, you will see your custom runner in the RCRunner main screen "Test framework" combobox.

RCRunner is under construction and currently it is in a beta stage. That means that things could not work for you. In that case, you can do 2 things:

  - Send me an e-mail explaining what is happening and I will try to help you
  - You can fix it by yourself since you have the full source code. Just make sure that fixing it will not break it for other people.

### Version
Beta
