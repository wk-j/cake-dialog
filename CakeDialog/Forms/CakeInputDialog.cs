using Gtk;
using System;
namespace CakeDialog.Forms
{
	public partial class CakeInputDialog : Gtk.Dialog
	{
		private readonly CakeInputDialogOptions _options;

		TextView detailTextView = new TextView();

		public CakeInputDialog(CakeInputDialogOptions options)
		{
			_options = options;
		}

		public void Initialize()
		{
			var options = _options;

			var ok = new Button {
				Label = "OK"
			};

			var cancel = new Button
			{
				Label = "Cancel"
			};

			this.Title = options.Title;
			this.DefaultWidth = 400;
			this.DefaultHeight = 200;

			this.ContentArea.Add(detailTextView);
			this.ActionArea.Add(ok);
			this.ActionArea.Add(cancel);

			ok.Clicked += OnOk;
			cancel.Clicked += OnCancel;

		}

		void OnCancel(object sender, EventArgs e)
		{
			_options.OnCancel();
			Application.Quit();
		}

		void OnOk(object sender, EventArgs e)
		{
			_options.OnOk(detailTextView.Buffer.Text);
			Application.Quit();
		}
	}
}
