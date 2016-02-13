using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Controls;

namespace RISClient
{
    public class Gongju
    {
        //弹出提示框 OK
        public static Task<MessageDialogResult> tanchutishi(string xinxi)
        {
            return DialogManager.ShowMessageAsync((MetroWindow)App.Current.MainWindow, "提示", xinxi);
        }
        //弹出提示框 OK
        public static Task<MessageDialogResult> tanchutishi(MetroWindow metroWindow, string xinxi)
        {
            return DialogManager.ShowMessageAsync(metroWindow, "提示", xinxi);
        }
        //弹出提示框 OK_CANCEL
        public static Task<MessageDialogResult> tanchutishi_cancel(string xinxi)
        {
            return DialogManager.ShowMessageAsync((MetroWindow)App.Current.MainWindow, "提示", xinxi, MessageDialogStyle.AffirmativeAndNegative);
        }

    }
}
