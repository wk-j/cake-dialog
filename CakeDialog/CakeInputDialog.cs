using System;
namespace CakeDialog
{
	public partial class CakeInputDialog : Gtk.Dialog
	{
		private readonly CakeInputDialogOptions _options;

		public CakeInputDialog(CakeInputDialogOptions options)
		{
			_options = options;
		}

		public void Initialize()
		{

			Build();

			Events |= Gdk.EventMask.ButtonPressMask | Gdk.EventMask.ButtonReleaseMask;
			okButton.Events |= Gdk.EventMask.ButtonPressMask | Gdk.EventMask.ButtonReleaseMask;;
			cancelButton.Events |= Gdk.EventMask.ButtonPressMask | Gdk.EventMask.ButtonReleaseMask;;

			var options = _options;

			Title = options.Text;
			detailTextView.Buffer.Text = options.Text;

			okButton.Clicked += new EventHandler(OnClick);
			cancelButton.Clicked += new EventHandler(OkCancel);

			okButton.Clicked += (s, e) => {
				options.OnOk(detailTextView.Buffer.Text);
			};

			cancelButton.Clicked += (s, e) => {
				options.OnCancel();
			};
		}

		void OkCancel(object sender, EventArgs e)
		{
		}

		void OnClick(object sender, EventArgs e)
		{
		}
	}
}
