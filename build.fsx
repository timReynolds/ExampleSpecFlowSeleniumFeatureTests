// include Fake lib
#r @"packages/FAKE/tools/FakeLib.dll"

open Fake
open System
open System.IO
open Fake.MSTest

let buildDir = environVarOrDefault "BUILD_DIR" (currentDirectory @@ "build")
let artifactsDir = environVarOrDefault "ARTIFACT_DIR" (currentDirectory @@ "artifacts")

let buildVersion = if isLocalBuild then "0.0.0.0" else buildVersion
let buildChangeset = environVarOrDefault "BUILD_VCS_NUMBER" "Unknown"
let solutionFile = environVarOrDefault "SOLUTION_FILE" "./ExampleBrowserFeatureTests.sln"
let buildMode = environVarOrDefault "TEST_ENV_NAME" "Release"

let mstestOptions p =
  { p with
      ResultsDir = artifactsDir
      WorkingDir = buildDir }

Target "Clean" (fun _ ->
    CleanDirs [buildDir; artifactsDir;]
)

Target "RestorePackages" (fun _ ->
    solutionFile
        |> RestoreMSSolutionPackages (fun p ->
            { p with
                Retries = 4 })
)

Target "SetVersion" (fun _ ->
    tracefn "This build is version %s. Changeset %s" buildVersion buildChangeset
    File.WriteAllText(artifactsDir @@ "/version.txt", buildVersion + Environment.NewLine + buildChangeset)
)

Target "BuildFeatureTests" (fun _ ->
    let properties = [
        "Configuration", buildMode
    ]

    !! "./**/*FeatureTests.csproj"
        |> MSBuild buildDir "Build" properties
        |> Log "BuildFeatureTests-Output: "
)

Target "RunFeatureTests" (fun _ ->
    !! (buildDir @@ "/*.FeatureTests.dll")
        |> MSTest mstestOptions
)

"Clean"
    ==> "RestorePackages"
    ==> "SetVersion"
    ==> "BuildFeatureTests"
    ==> "RunFeatureTests"

RunTargetOrDefault "RunFeatureTests"
