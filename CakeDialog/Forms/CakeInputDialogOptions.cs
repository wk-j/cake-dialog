using System;
namespace CakeDialog.Forms
{
	public class CakeInputDialogOptions
	{
		public string Title { set; get; } = "Title";
		public string Text { set; get; } = "";
		public Action<string> OnOk { set; get; } = (text) => { };
		public Action OnCancel { set; get; } = () => { };

		public CakeInputDialogOptions()
		{
		}
	}
}
