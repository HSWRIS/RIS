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
using System.Windows.Threading;

namespace RISClient.Yemian.Xitong
{
    /// <summary>
    /// Qidongyemian.xaml 的交互逻辑
    /// </summary>
    public partial class Qidongyemian
    {
        public Qidongyemian()
        {
            InitializeComponent();

            shujuku = new Shujuku.Shujuku();
            IsVisibleChanged += Qidongyemian_IsVisibleChanged;

            if (!shujuku.Database.Exists())
            {
                MessageBox.Show("链接数据库失败！！","提示");
                this.Close();
                return;
            }

            tm = new DispatcherTimer();
            tm.Tick += new EventHandler(chushihua);
            tm.Interval = TimeSpan.FromSeconds(0.01);
            tm.Tag = 0;
            tm.Start();
        }

        private Shujuku.Shujuku shujuku { set; get; }

        //页面不可见
        private void Qidongyemian_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var kejian = (bool)e.NewValue;
            if (kejian == false)
            {
                shujuku.SaveChanges();
                shujuku.Dispose();
            }
        }

        DispatcherTimer tm { set; get; }

        private  void chushihua(object sender, EventArgs e)
        {

            tm.Tag = (int)tm.Tag + 1;
            jindutiaoUI.Value = (int)tm.Tag;

            if (jindutiaoUI.Value == 1)
            {
                jinduxinxiUI.Content = "更新数据库：HLA申请单数据";
                var ls = shujuku.Jichuid.Where(z => z.biao.Equals("HLA_shenqingdan") && z.lie.Equals("bianhao")).Single();
                if (ls.gengxinshijian.Year != DateTime.Now.Year)
                {
                    ls.gengxinshijian = DateTime.Now;
                    if (shujuku.HLA_shenqingdan.Count() == 0)
                    {
                        ls.jichuid = 0;
                    }
                    else
                    {
                        ls.jichuid = shujuku.HLA_shenqingdan.OrderBy(z => z.id).Last().id;
                    }
                }
            }
            else if (jindutiaoUI.Value == 100)
            {
                tm.Stop();
                var denglu = new Denglu();
                denglu.Show();
                this.Close();
            }
        }
    }
}
