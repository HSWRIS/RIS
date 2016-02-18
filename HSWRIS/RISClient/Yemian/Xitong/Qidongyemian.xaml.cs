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

            tm = new DispatcherTimer();
            tm.Tick += new EventHandler(chushihua);
#if DEBUG
            tm.Interval = TimeSpan.FromSeconds(0.005);
#else
            tm.Interval = TimeSpan.FromSeconds(0.05);
#endif
            tm.Tag = -1;
            tm.Start();
        }

        private Shujuku.Shujuku shujuku { set; get; }

        //页面可见变化
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

        private async void chushihua(object sender, EventArgs e)
        {
            tm.Stop();
            tm.Tag = (int)tm.Tag + 1;
            jindutiaoUI.Value = (int)tm.Tag;

            if (jindutiaoUI.Value == 0) jinduxinxiUI.Content = "初始化...";

            if (jindutiaoUI.Value == 1)
            {
                shujuku = new Shujuku.Shujuku();
                IsVisibleChanged += Qidongyemian_IsVisibleChanged;
            }

            if (jindutiaoUI.Value == 10) jinduxinxiUI.Content = "检测数据库连接...";

            if (jindutiaoUI.Value == 11)
            {
                if (!shujuku.Database.Exists()||!shujuku.Database.Connection.ConnectionString.Equals("Data Source=127.0.0.1;Initial Catalog=HSWRIS;Persist Security Info=True;User ID=sa;Password=shishi"))
                {
                    await Gongju.tanchutishi(this, "链接数据库失败...");
                    this.Close();
                }
            }

            if (jindutiaoUI.Value == 20)
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
            if (jindutiaoUI.Value == 21)
            {
                jinduxinxiUI.Content = "更新数据库：HLA样本数据";
                var ls = shujuku.Jichuid.Where(z => z.biao.Equals("HLA_yangbenjieshou") && z.lie.Equals("bianhao") && z.fenzu.Equals("SZ")).Single();
                if (ls.gengxinshijian.Year != DateTime.Now.Year)
                {
                    ls.gengxinshijian = DateTime.Now;
                    if (shujuku.HLA_shenqingdan.Count() == 0)
                    {
                        ls.jichuid = 0;
                    }
                    else
                    {
                        ls.jichuid = shujuku.HLA_yangbenjieshou.Where(z => z.leixing.Equals("SZ")).OrderBy(z => z.id).Last().id;
                    }
                }

                ls = shujuku.Jichuid.Where(z => z.biao.Equals("HLA_yangbenjieshou") && z.lie.Equals("bianhao") && z.fenzu.Equals("FY")).Single();
                if (ls.gengxinshijian.Year != DateTime.Now.Year)
                {
                    ls.gengxinshijian = DateTime.Now;
                    if (shujuku.HLA_shenqingdan.Count() == 0)
                    {
                        ls.jichuid = 0;
                    }
                    else
                    {
                        ls.jichuid = shujuku.HLA_yangbenjieshou.Where(z => z.leixing.Equals("FY")).OrderBy(z => z.id).Last().id;
                    }
                }
            }

            if (jindutiaoUI.Value == 100)
            {
                var denglu = new Denglu();
                denglu.Show();
                this.Close();
            }

            if (jindutiaoUI.Value < 100)
            {
                tm.Start();
            }
        }
    }
}
