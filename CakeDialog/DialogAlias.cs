using Cake.Core;
using Cake.Core.Annotations;
using CakeDialog.Win;
using System;

namespace CakeDialog
{
    [CakeAliasCategory("Dialog")]
    public static class DialogAlias
    {
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
