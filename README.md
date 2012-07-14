BuildsOnMyBox
=============

BuildsOnMyBox.com: The Tale of two courageous developers on their quest for the Coding Grail...

SETUP:

Follow these steps to get NCrunch working with StyleCop.

In Visual Studio, in the NCrunch Menu, select configuration.
Select a project node
In the properties window for the selected project:
Find the "Additional files to include" property.
Click the ... button in the value of the property.
Add the following item: ..\packages\StyleCop.MSBuild.4.7.33.0\tools\stylecop.dll
Do the above steps for each project that is using StyleCop.

This will tell NCrunch to include the StyleCop assembly when it builds. Once NCrunch knows it needs this file the build should complete successfully and NCrunch should work.