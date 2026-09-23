# AGENTS.md

Single-project Windows Forms (.NET Framework 4.7.2) app, generated from the VS template. No tests, no NuGet packages, no CI.

## Build / run
- Build the whole solution: `dotnet build "Cely Sabores.slnx"` (dotnet SDK 10 handles the legacy csproj and the `.slnx` solution format).
- The app is a `WinExe` GUI; it only runs on Windows (`dotnet run` launches a GUI form, not a console).
- Entrypoint: `Cely Sabores/Program.cs` -> `Form1`. Namespace is `Cely_Sabores` (underscore).

## Gotchas
- The csproj is the legacy (pre-SDK) format with explicit `<Compile Include="...">` entries. New `.cs` files are NOT picked up automatically — add them to `Cely Sabores.csproj` or they will not be compiled.
- Do not hand-edit designer- or settings-generated files: `Form1.Designer.cs`, `Properties/Resources.Designer.cs`, `Properties/Settings.Designer.cs`. Edit them via the VS WinForms designer, or edit `Form1.cs`/the `.resx`/`.settings` sources and regenerate.
- Target framework is .NET Framework 4.7.2 (default C# language version for legacy csprojs). References are framework assemblies only; no `PackageReference`.