using Cake.Core;
using Cake.Core.Annotations;
using CakeDialog.Forms;
using CakeDialog.Win;
using Gtk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeDialog
{
    [CakeAliasCategory("Dialog")]
    public static class DialogAlias
    {
        [CakeMethodAlias]
        public static void GtkInputDialog(this ICakeContext context, Action<DialogOptions> st)
        {
            var settings = new DialogOptions();
            st(settings);

            Application.Init();
            var dlg = new CakeInputDialog(settings);
            dlg.ShowAll();
            Application.Run();
        }

        [CakeMethodAlias]
        public static void InputDialog(this ICakeContext context, Action<DialogOptions> st)
        {
            var settings = new DialogOptions();
            st(settings);

            var dlg = new InputDialog(settings);
            dlg.ShowDialog();
        }
    }
}
