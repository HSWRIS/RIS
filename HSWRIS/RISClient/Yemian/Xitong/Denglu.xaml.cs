using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace RISClient.Yemian.Xitong
{
    /// <summary>
    /// Denglu.xaml 的交互逻辑
    /// </summary>
    public partial class Denglu : MetroWindow
    {
        public Denglu()
        {
            InitializeComponent();
        }

        private async void dengluUIbutton_Click(object sender, RoutedEventArgs e)
        {
            using (Shujuku.Shujuku shujuku=new Shujuku.Shujuku())
            {
                if (shujuku.Yonghu.Where(z=>z.zhanghao.Equals(zhanghaoUItextBox.Text)&&z.mima.Equals(mimaUIpasswordBox.Password)).Count()==1)
                {
                    var zhuchuangti = new Yemian.Xitong.Zhujiemian();
                    zhuchuangti.Show();
                    this.Close();
                }
                else
                {
                    await DialogManager.ShowMessageAsync(this, "提示", "登录信息有误！");
                }
            }
        }
    }
}
