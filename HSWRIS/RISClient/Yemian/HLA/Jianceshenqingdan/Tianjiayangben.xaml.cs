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

namespace RISClient.Yemian.HLA.Jianceshenqingdan
{
    /// <summary>
    /// Tianjiayangben.xaml 的交互逻辑
    /// </summary>
    public partial class Tianjiayangben 
    {
        public Tianjiayangben()
        {
            InitializeComponent();
        }

        private async void quedingUIbutton_Click(object sender, RoutedEventArgs e)
        {
            if (xingmingUItextBox.Text.Trim().Length == 0)
            {
                await Gongju.tanchutishi(this, "姓名不能为空！");
                return;
            }
            if (xingmingUItextBox.Text.Trim().Length == 0)
            {
                await Gongju.tanchutishi(this, "姓名不能为空！");
                return;
            }
            if (xingmingUItextBox.Text.Trim().Length == 0)
            {
                await Gongju.tanchutishi(this, "姓名不能为空！");
                return;
            }

            if (leixingUIcomboBox1.Text.Trim().Length == 0)
            {
                await Gongju.tanchutishi(this, "类型不能为空！");
                return;
            }
            if (bianhaoUItextBox.Text.Trim().Length == 0)
            {
                await Gongju.tanchutishi(this, "编号不能为空！");
                return;
            }

            this.DialogResult = true;
            this.Close();
        }
    }
}
