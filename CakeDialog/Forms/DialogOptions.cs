using System;
namespace CakeDialog.Forms
{
	public class DialogOptions
	{
		public string Title { set; get; } = "Title";
		public string Text { set; get; } = "";
		public string OkText { set; get; } = "OK";
		public Action<string> OnOk { set; get; } = (text) => { };
		public Action OnCancel { set; get; } = () => { };

		public DialogOptions()
		{
		}
	}
}
