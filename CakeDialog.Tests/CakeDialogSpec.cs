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
		public void TestCase()
		{
			Application.Init();
			var dlg = new CakeInputDialog(new CakeInputDialogOptions {
				Text = "Hello, world!",
				Title = "Show me message",
				OnOk = (obj) => { 

				}
			});

			dlg.ShowAll();
			Application.Run();
		}
	}
}
