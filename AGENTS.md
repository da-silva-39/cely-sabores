# AGENTS.md

WinForms app for restaurant management, .NET Framework 4.7.2, four projects
(`CelySabores.Models`, `.Data`, `.Business`, `Cely Sabores` UI). No tests,
no NuGet packages, no CI. UI text is pt-PT.

## Build / run
- Build: `dotnet build "Cely Sabores.slnx"` (dotnet SDK 10 handles the legacy csprojs and the `.slnx` solution format).
- The app is a `WinExe` GUI, Windows only. `dotnet run` opens a window, not a console.
- Entrypoint: `src/Cely Sabores/Program.cs` -> `FormularioLogin`. Namespace is `Cely_Sabores` (underscore).
- Database is LocalDB, connection string `CelySabores` in `App.config`; schema and seeds live in `schema.sql` at the repo root.

## UI architecture (important)
Every screen is split in two files, so the layout can be edited by dragging in the Visual Studio designer:
- `X.cs` — logic only: services, event wiring, data loading, validation.
- `X.Designer.cs` — `partial class X`, the control fields and `InitializeComponent()`.

Rules that keep the designer working:
- **The `partial class` name in `X.Designer.cs` must equal the file name and `this.Name`.** A wrong name makes the build fail with `CS0102`/`CS0111` (two classes merging) and the designer will not open any form.
- **No `abstract` classes.** The VS designer refuses to open `abstract` types, so `PainelBase` is concrete and `Recarregar()` is `virtual` (subclasses `override` it).
- **UserControls must declare `this.Size = new System.Drawing.Size(940, 660);` and Forms `this.ClientSize`,** both next to `this.Name` at the end of `InitializeComponent()`.
- **`SuspendLayout()` / `ResumeLayout()` and `BeginInit()` / `EndInit()` must pair up exactly**; an unpaired one breaks the designer.
- **Every `private` field declared in `X.Designer.cs` must be assigned with `new` and added to some container** in the same file; a field never added is dead weight the designer will strip.
- Every class needs `<SubType>Form</SubType>` or `<SubType>UserControl</SubType>` in the csproj, otherwise VS opens it as plain code.
- **Never create visual controls in `X.cs`.** Everything static goes in `X.Designer.cs`. Dynamically created controls (dashboard cards, `AdicionarAcao` buttons) stay in `X.cs` and only fill containers declared in the Designer.
- **No `Tema.*` calls inside `X.Designer.cs`.** Use literal `Color.FromArgb(...)` values, otherwise the designer drops the control when it regenerates the file. The palette is in `Tema.cs`.
- **`DataGridView` columns use `HeaderText`, never `Text`** (`Text` is not a column property and fails to compile).
- Panels derive from `PainelBase` (a `UserControl`, not a `Panel` — the designer only opens Forms and UserControls). Their controls are added to `this._conteudo` in the Designer file.
- Every screen has a **parameterless constructor for the designer** that does not touch the database. Loading is guarded with `LicenseManager.UsageMode == LicenseUsageMode.Runtime`.
- Screens with constructor parameters split the data population into a private `Carregar()` / `InicializarDados(...)`; it must not run in the parameterless constructor or the designer throws.
- The `PainelBase` title is set through the `base(...)` call chain or via `DefinirTitulo(...)`.
- `Controls.Add` order is the reverse of the desired dock order: what is added first ends up underneath.

## Gotchas
- The UI csproj is the legacy (pre-SDK) format with explicit `<Compile Include="...">` entries. New `.cs` files are NOT picked up automatically — add them to `Cely Sabores.csproj` (with `<DependentUpon>`) or they will not compile. Same for new `*.Designer.cs`.
- Do not hand-edit `Properties/Settings.Designer.cs`. The `X.Designer.cs` files are meant to be edited by the VS designer.
- Services live in `CelySabores.Business`, data access in `CelySabores.Data`; the UI calls services, never repositories. `Servicos.cs` builds the whole service graph.
- Permissions go through `ContextoPermissao` (`EhGerente`, `ExigirGerente`); reports and stock are manager-only.
- Target framework is .NET Framework 4.7.2 (default C# language version for legacy csprojs). References are framework assemblies only; no `PackageReference`.
- Source files are UTF-8 **without** BOM and use LF line endings.
