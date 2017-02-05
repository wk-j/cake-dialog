#r "CakeDialog/bin/Debug/CakeDialog.dll"

var name = "CakeDialog";
var solution = $"{name}.sln";
var packageName = "Cake.Dialog";
var releasePath = $"{name}/bin/Release";
var projectDll = $"{releasePath}/{name}.dll";
var info = $"{name}/Properties/AssemblyInfo.cs";
var npi = EnvironmentVariable("npi");

Func<string, string> abs = (path) => new FileInfo(path).FullName;

using CakeDialog;

Task("Build-Release")
    .Does(() => {
        DotNetBuild(solution, settings =>
            settings.SetConfiguration("Release")
            .WithTarget("Build")
            .WithProperty("TreatWarningsAsErrors","true"));
    });

Task("Publish-Nuget")
    .IsDependentOn("Create-Nuget-Package")
    .Does(() => {
        var nupkg = new DirectoryInfo("./nuget").GetFiles("*.nupkg").LastOrDefault();
        var package = nupkg.FullName;
        NuGetPush(package, new NuGetPushSettings {
            Source = "https://www.nuget.org/api/v2/package",
            ApiKey = npi
        });
    });

Action<string, string> process = (cmd, args) => {
    StartProcess(cmd, new ProcessSettings {
        Arguments = args
    });
};

Task("Commit").Does(() => {
    InputDialog(options => {
        options.Title = "Enter commit message";
        options.OnOk = (message) => {
            process("git", "add --all");
            process("git", "commit -m \"{message}\"");
            process("git", "push -u github master");
        };
    });
});

Task("Clean").Does(() => {
    CleanDirectory("./nuget");
});

Task("Create-Nuget-Package")
    .IsDependentOn("Build-Release")
    .IsDependentOn("Clean")
    .Does(() => {

        var files = new System.IO.DirectoryInfo(releasePath).GetFiles("*.*").Select(x => new NuSpecContent {
            Source = x.FullName,
            Target = "bin/net45"
        }).ToArray();

        var logo = "https://github.com/cake-addin/cake-watch/raw/master/Assets/logo.png";
        var version = ParseAssemblyInfo(info).AssemblyVersion;
        var settings   = new NuGetPackSettings {
                    Id                      = packageName,
                    Version                 = version,
                    Title                   = packageName,
                    Authors                 = new[] {"wk"},
                    Owners                  = new[] {"wk"},
                    Description             = "Cake.Dialog",
                    Summary                 = "Show input dialog",
                    ProjectUrl              = new Uri("https://github.com/wk-j/cake-dialog"),
                    IconUrl                 = new Uri(logo),
                    LicenseUrl              = new Uri("https://github.com/wk-j/cake-dialog"),
                    Copyright               = "MIT",
                    ReleaseNotes            = new [] { "New version"},
                    Tags                    = new [] {"Cake", "Dialog" },
                    RequireLicenseAcceptance= false,
                    Symbols                 = false,
                    NoPackageAnalysis       = true,
                    Files                   = files,
                    BasePath                = "./",
                    OutputDirectory         = "./nuget"
                };
        NuGetPack(settings);
    });

Task("Show-Input-Dialog").Does(() => {
    InputDialog(options => {
        options.Title = "Enter commit message";
        options.Text = "Update ...";
        options.OnOk = (text) => {
            Console.WriteLine(text);
        };
    });
});

var target = Argument("Target", "Default");
RunTarget(target);