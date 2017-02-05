using NUnit.Framework;
using System;
using Gtk;
using CakeDialog;

namespace Cake.Dialog.Tests
{
	[TestFixture()]
	public class Test
	{
		[Test()]
		public void TestCase()
		{
			Application.Init();
			var dlg = new CakeInputDialog();
			dlg.Show();

			Application.Run();
		}
	}
}
