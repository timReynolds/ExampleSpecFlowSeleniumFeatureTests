cls
".nuget\NuGet.exe" "Install" "FAKE" "-OutputDirectory" "packages" "-ExcludeVersion" "-Source" "https://api.nuget.org/v3/index.json"
"packages\FAKE\tools\Fake.exe" build.fsx
