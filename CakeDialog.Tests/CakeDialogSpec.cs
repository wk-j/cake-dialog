using NUnit.Framework;
using System;
using Gtk;
using CakeDialog;
using Xunit;
using CakeDialog.Forms;

namespace CakeDialog.Tests
{
	public class CakeDialogSpec
	{
		[Fact]
		[Test]
		public void ShowDialog()
		{
			Application.Init();
			var dlg = new CakeInputDialog(new DialogOptions {
				Text = "Hello, world!",
				Title = "Enter commit message",
				OnOk = (obj) => {
					Console.Write(obj);
				}
			});
			dlg.Initialize();

			dlg.ShowAll();
			Application.Run();
		}

		[Fact]
		public void ShowWindow()
		{
			Application.Init();

			var btn = new Button("Hello World");
			btn.Events |= Gdk.EventMask.ButtonPressMask | Gdk.EventMask.ButtonReleaseMask;

			btn.Clicked += (s, e) => {
				Application.Quit();
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
