#r "CakeDialog/bin/Debug/CakeDialog.dll"

using CakeDialog;

Task("Test").Does(() => {
    InputDialog(options => {
        options.Title = "Hello, world!";
        options.Text = "Hi";
        options.OnOk = (text) => {
            Console.WriteLine(text);
        };
    });
});

var target = Argument("Target", "Default");
RunTarget(target);