using CakeDialog.Forms;
using System;
using System.Windows.Forms;

namespace CakeDialog.Win
{
    public partial class InputDialog : Form
    {
        readonly DialogOptions _options;

        public InputDialog(DialogOptions options)
        {
            _options = options;

            InitializeComponent();
            Text = options.Title;

            okButton.Text = options.OkText;
            detailTextBox.Text = options.Text;
            detailTextBox.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            var text = detailTextBox.Text;
            this.Close();
            _options.OnOk(text);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            _options.OnCancel();
        }
    }
}
