using NUnit.Framework;
using System;
using Gtk;
using CakeDialog;

namespace Cake.Dialog.Tests
{
	[TestFixture()]
	public class CakeDialogSpec
	{
		[Test()]
		public void ShowDialog()
		{
			Application.Init();
			var dlg = new CakeInputDialog(new CakeInputDialogOptions {
				Text = "Hello, world!",
				Title = "Show me message",
				OnOk = (obj) => { 

				}
			});
			dlg.Initialize();

			dlg.ShowAll();
			Application.Run();
		}

		[Test]
		public void ShowWindow()
		{
			Application.Init();

			var btn = new Button("Hello World");
			btn.Events |= Gdk.EventMask.ButtonPressMask | Gdk.EventMask.ButtonReleaseMask;

			btn.Clicked += (s, e) => {
				Console.WriteLine(e);
			};

			var window = new Window("helloworld");
			window.Events |= Gdk.EventMask.ButtonPressMask | Gdk.EventMask.ButtonReleaseMask;

			window.DeleteEvent += (s, e) => {
				Console.Write(e);
			}; 

			window.Add(btn);
			window.ShowAll();

			Application.Run();
		}
	}
}
