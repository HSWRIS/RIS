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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RISClient.Kongjian
{
    /// <summary>
    /// Liebiaokongzhi.xaml 的交互逻辑
    /// </summary>
    public partial class Liebiaokongzhi : UserControl
    {
        public Liebiaokongzhi()
        {
            InitializeComponent();
        }
        public event RoutedEventHandler Tianjia_Click;
        public event RoutedEventHandler Xiugai_Click;
        public event RoutedEventHandler Shanchu_Click;

        private async  void tianjiaUIbutton_Click(object sender, RoutedEventArgs e)
        {
            if (Tianjia_Click != null)
            {
                Tianjia_Click(sender, e);
            }
            else
            {
                await Gongju.tanchutishi("此功能没有实现!");
            }
        }

        private async void xiugaiUIbutton_Click(object sender, RoutedEventArgs e)
        {
            if (Xiugai_Click != null)
            {
                Xiugai_Click(sender, e);
            }
            else
            {
                await Gongju.tanchutishi("此功能没有实现!");
            }
        }

        private async void shanchuUIbutton_Click(object sender, RoutedEventArgs e)
        {
            if (Shanchu_Click != null)
            {
                Shanchu_Click(sender, e);
            }
            else
            {
                await Gongju.tanchutishi("此功能没有实现!");
            }
        }
    }
}
