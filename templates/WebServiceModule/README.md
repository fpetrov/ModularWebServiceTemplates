# WebServiceModule (for the ModularWebService)

![.NET](https://img.shields.io/badge/.NET-8%2F9-blueviolet?logo=dotnet&logoColor=white)
![License](https://img.shields.io/badge/license-MIT-green)

## About
This template produces a **module** you can plug into the *Modular Web Service Solution*.

## When to use
- You already have a solution created with the **Modular Web Service Solution** template.
- You want to add a module to your existing Modular Web Service.

## Quick start (inside an existing solution)
From the solution root:

```bash
dotnet new module -n AwesomeModule
```

Then reference the module from your web host/composition root and register its services/endpoints as needed.