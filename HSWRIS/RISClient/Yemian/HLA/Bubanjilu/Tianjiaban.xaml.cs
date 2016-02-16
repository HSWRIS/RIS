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

namespace RISClient.Yemian.HLA.Bubanjilu
{
    /// <summary>
    /// Tianjiaban.xaml 的交互逻辑
    /// </summary>
    public partial class Tianjiaban 
    {
        public Tianjiaban()
        {
            InitializeComponent();
        }
        public Shujuku.Shujuku shujuku { set; get; }
        //确定 点击事件
        private async void quedingUIbutton_Click(object sender, RoutedEventArgs e)
        {
            if (banhaoUItextBox.Text.Trim().Length < 1)
            {
                await Gongju.tanchutishi(this, "板号不能为空！");
                return;
            }

            if (leixingUIcomboBox.Text == null)
            {
                await Gongju.tanchutishi(this, "类型不能为空！");
                return;
            }
            if (lieshuUIcomboBox.Text.Equals("0"))
            {
                await Gongju.tanchutishi(this, "列数不能为空！");
                return;
            }
            if (hangshuUIcomboBox.Text.Equals("0"))
            {
                await Gongju.tanchutishi(this, "行数不能为空！");
                return;
            }

            if (shujuku.HLA_banxinxi.Where(z=>z.banhao.Equals(banhaoUItextBox.Text)).Count()>0&&((Shujuku.HLA_banxinxi)banxinxiUI.DataContext).id<1)
            {
                await Gongju.tanchutishi(this, "相同板号已经存在！");
                return;
            }

            this.DialogResult = true;
            this.Close();
        }
    }
}
