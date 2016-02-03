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

namespace RISClient.Yemian.HLA.Jianceshenqingdan
{
    /// <summary>
    /// Jianceshenqingdan.xaml 的交互逻辑
    /// </summary>
    public partial class Jianceshenqingdan : Kongjian.Jichuyemian
    {
        public Jianceshenqingdan()
        {
            InitializeComponent();
        }
        //添加申请单
        private void shenqingdanliebiaokongzhiUI_Tianjia_Click(object sender, RoutedEventArgs e)
        {
            var tianjia = new Tianjiashenqingdan();
            tianjia.ShowDialog();
        }

        private void shenqingdanliebiaokongzhiUI_Shanchu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void shenqingdanliebiaokongzhiUI_Xiugai_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
