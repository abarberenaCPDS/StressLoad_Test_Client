# AGENTS.md

Single-project .NET Framework 4.6.2 WinForms desktop app. No packages, no tests, not a git repo.

## Build

- **Must use VS MSBuild** — `dotnet build` fails on this legacy csproj (MSB4216: `GenerateResource` can't run the x86 task host under the .NET SDK).
  ```powershell
  & "C:\Program Files\Microsoft Visual Studio\2022\Enterprise\MSBuild\Current\Bin\MSBuild.exe" Abes_StressLoad_Test_Client.csproj -restore -t:Build -p:Configuration=Debug
  ```
- Non-SDK csproj (XML `Microsoft.Common.props` style), not the SDK-style format. Don't convert/migrate casually.
- Output is a WinExe: `bin\Debug\StressLoad_Test_Client.exe`.

## Naming mismatch

Project/solution file is `Abes_StressLoad_Test_Client`, but the C# namespace and assembly name are `StressLoad_Test_Client` (Form1.Designer.cs, Program.cs, AssemblyInfo.cs). Keep new types in the `StressLoad_Test_Client` namespace.

## Gotchas

- The stress test in `Form1.cs:btnStressTest_Click` is a **stub**: the inner loop's HTTP call site is a placeholder (`// invoke here...`). It currently measures only empty-loop timing, so reported TPS/transaction-duration numbers are not real load.
- Results are emitted via `Trace.WriteLine`, visible in the VS Debug output — not in the UI. Trace listeners are not configured in App.config.
- `Form1.Designer.cs` (`InitializeComponent`) is designer-generated; edit controls in the Designer or via code, not by hand-editing that method.
- Non-UI worker `Thread`s are used directly in the handler (no async/await, no CancellationToken).
