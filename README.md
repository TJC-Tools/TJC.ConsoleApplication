# NuGet Package Template
This repository is a template for **Public C# Libraries** that will be published as **NuGet Packages**.

## Setup
1. Clone the repository
2. Open `Testing.sln` & create a **Class Library** (`TJC.LibraryName/TJC.LibraryName.csproj`) & **MSTest Test Project** (`TJC.LibraryName.Tests/TJC.LibraryName.Tests.csproj`)
3. Set **NuGet Package** settings in the `.csproj`, like below
```xml
<PropertyGroup>
	<TargetFramework>net8.0</TargetFramework>
	<ImplicitUsings>enable</ImplicitUsings>
	<Nullable>enable</Nullable>
	<Title>TJC LibraryName</Title>
	<Description>Library Description</Description>
	<RepositoryUrl>https://github.com/TJC-Tools/TJC.LibraryName</RepositoryUrl>
	<PackageReadmeFile>README.md</PackageReadmeFile>
</PropertyGroup>
```
4. Add the `InternalsVisibleToAttribute` to the **project** `.csproj`, so that the **tests** `.csproj` can see `internal` **classes**, **methods** & **properties**
```xml
<ItemGroup>
	<AssemblyAttribute Include="System.Runtime.CompilerServices.InternalsVisibleToAttribute">
		<_Parameter1>TJC.LibraryName.Tests</_Parameter1>
	</AssemblyAttribute>
</ItemGroup>
```
5. Copy `Nuget.config` into the `TJC.LibraryName` directory & add the following lines to the `.csproj`
```xml
<ItemGroup>
	<None Remove="Nuget.config" />
</ItemGroup>

<ItemGroup>
	<Content Include="Nuget.config">
		<CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
	</Content>
</ItemGroup>

<ItemGroup>
	<None Include="..\README.md">
		<Pack>True</Pack>
		<PackagePath>\</PackagePath>
	</None>
</ItemGroup>
```
6. In `workflows` replace the `{REPLACE_ME}` placeholders
7. In the `README.md` delete everything above the `---` and add some initial documentation
8. Delete the [ruleset](.github/ruleset.json) (back it up somewhere locally for later)
9. Amend the initial commit & force push the changes using `git push -f`
10. ~~Set `GitHub NuGet Package` visibility to `public`~~
11. **Repository Settings**
  - Import repository permissions from the local backup of [ruleset](.github/ruleset.json)
  - **Pull Requests**
    - Disable `Allow merge commits`
    - Enable `Always suggest updating pull request branches`
    - Enable `Automatically delete head branches`
12. On **GitHub** deselect **Releases**, **Packages** & **Deployments**
13. On **GitHub**, add a **Description**, **Website** link to [www.nuget.org/packages/TJC.LibraryName](https://www.nuget.org/packages/TJC.Test) & **Topics**

---

[![NuGet Version and Downloads count](https://buildstats.info/nuget/TJC.LibraryName)](https://www.nuget.org/packages/TJC.LibraryName)

## Items
