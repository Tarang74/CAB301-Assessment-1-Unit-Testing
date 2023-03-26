# CAB301 Unit Testing Project

This repository provides unit testing for CAB301 Assessment 1.

## Prerequisites

Your application must use the .NET 7.0 framework to be compatible with the MSTest framework.

## Getting Started

1. Start by cloning this repository into the parent repository of your project.
2. Right-click your solution, then click `Add > Existing Project...`.
3. Then add a reference to the `UnitTesting` project by navigating to `Dependencies > Add Project Reference...`.

   Note this should be done in the `UnitTesting` project, not your own project.

4. Create a `Usings.cs` file to the `UnitTesting` project to add a `global using` to your assessment project.

   ```cs
   global using <namespace>;
   ```

   This file is ignored by git.

To begin testing, build your application, and click `Run All Tests` in the `Test Explorer`.

## Adding to this repository

If you want to add some of your own tests to this library, create a Pull Request using GitHub.

## Declaration of Consent

I, Tarang Janawalkar, give any student studying CAB301 in Semester 1, 2023, to modify, use, and share the files in this repository.
