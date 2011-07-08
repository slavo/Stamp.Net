Introduction
============
Stamp.Net is a library inspired by the [Stamp][stamp_src] library for the Ruby language. Its purpose is to format string representation of dates in .NET by an example, rather than the standard .NET format strings. For more information on the original Stamp library please see the [git repository][stamp_src].
	
Installation
============
The repository contains two Visual Studio projects - a class library for the utility itself and a Console application to illustrate its usage. The are two ways to use the library:

1. From source - just copy the Stamp.Net project, add it to your solution and add a project reference to any other project you are going to call it from.
2. As a binary - Build the Stamp.Net project and copy the Stamp.Net.dll file. Add a normal reference to the DLL in the project that is going to use it.

Usage
=====

Stamp.Net provides an extension method for the DateTime class, that you can call to get a string representation. The method accepts a single parameter with an example format as string. The formats that are implemented until now are seen in the following example:

    var currentDate = DateTime.Now;
    
	// Full month name, two-digit day, four-digit year
    Console.WriteLine(currentDate.Format("June 24, 2001"));
	
	// Three-letter month name, two-digit day, four-digit year
    Console.WriteLine(currentDate.Format("Jun 23, 2345"));
	
	// Three-digit month name, two-digit day
    Console.WriteLine(currentDate.Format("Jun 09"));
	
	// Full day of week, full month name, two-digit day, four-digit year
    Console.WriteLine(currentDate.Format("Monday, June 09, 2003"));

  [stamp_src]: https://github.com/jeremyw/stamp