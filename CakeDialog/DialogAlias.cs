using Cake.Core;
using Cake.Core.Annotations;
using CakeDialog.Forms;
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
        public static void InputDialog(this ICakeContext context, Action<CakeInputDialogOptions> st)
        {
            var settings = new CakeInputDialogOptions();
            st(settings);

            Application.Init();
            var dlg = new CakeInputDialog(settings);
            dlg.ShowAll();
            Application.Run();
        }
    }
}
