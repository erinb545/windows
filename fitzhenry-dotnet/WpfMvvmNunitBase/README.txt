This build should work right out of the box. To run it:

1. Open the solution in Visual Studio (I am using Microsoft Visual Studio Professional 2013, Version 12.0.21005.1 REL)
2. Click Play to run the application.

To run the unit tests, right-click on the WpfMvvmNunitBase.Test project and click Run Unit Tests.

If this does not work, the Nunit Test Adapter package may not be installed. To install it manually:
 
1. Right-click on the solution in the Solution Explorer
2. Click Manage NuGet Packages for Solution...
3. Search for "nunit test adapter"
4. Choose NUnit Test Adapter including NUnit 2.6.4 Framework and click Install

Then try running the unit tests again.

