# StressLoad_Test_Client

![C#](https://img.shields.io/badge/language-C%23-239120)
![.NET Framework 4.6.2](https://img.shields.io/badge/.NET-Framework%204.6.2-512BD4)
![WinForms](https://img.shields.io/badge/GUI-Windows_Forms-512BD4)
![Windows](https://img.shields.io/badge/platform-Windows-0078D6)

A Windows Forms (.NET Framework 4.6.2) stress/load test client.

## Overview

Provides a simple WinForms UI where you enter a thread count and iteration count and click **Stress Test**. Each worker thread runs the configured number of iterations and reports throughput (transactions per second) and transaction duration.

> **Note:** The HTTP call site inside the iteration loop is currently a placeholder. As-is, the test measures only empty-loop timing and the reported numbers are not real load. Add your service call at the marked location in `Form1.cs`.

## Build

This is a legacy (non-SDK) `.NET Framework 4.6.2` csproj, so it must be built with the Visual Studio MSBuild, not `dotnet build` (which fails with MSB4216):

```powershell
& "C:\Program Files\Microsoft Visual Studio\2022\Enterprise\MSBuild\Current\Bin\MSBuild.exe" Abes_StressLoad_Test_Client.csproj -restore -t:Build -p:Configuration=Debug
```

Output: `bin\Debug\StressLoad_Test_Client.exe`.

## Usage

1. Set **Threads** and **Iterations**.
2. Click **Stress Test**.
3. Results appear in the Visual Studio Debug output (via `Trace.WriteLine`), not in the UI.

## Notes

- Project file is named `Abes_StressLoad_Test_Client`, but the C# namespace/assembly is `StressLoad_Test_Client`.
- No packages, no tests, no CI.
