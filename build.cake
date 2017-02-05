#r "CakeDialog/bin/Debug/CakeDialog.dll"

using CakeDialog;

Task("Test").Does(() => {
    InputDialog(options => {
        options.Title = "Hello, world!";
        options.OnOk = (text) => {
            Console.WriteLine(text);
        };
    });
});

var target = Argument("Target", "Default");
RunTarget(target);