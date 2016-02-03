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

namespace RISClient.Yemian.Xitong
{
    /// <summary>
    /// Zhujiemian.xaml 的交互逻辑
    /// </summary>
    public partial class Zhujiemian 
    {
        public Zhujiemian()
        {
            InitializeComponent();
            App.Current.MainWindow = this;
        }

        private void gerenzhongxinUItreeViewItem_Selected(object sender, RoutedEventArgs e)
        {
            jiazaiqiUIframe.Content = new Yemian.Xitong.Gerenzhongxin();
        }

        private void linchuanghla_jianceshenqingdanUItreeViewItem_Selected(object sender, RoutedEventArgs e)
        {
            jiazaiqiUIframe.Content = new Yemian.HLA.Jianceshenqingdan.Jianceshenqingdan();
        }
    }
}
