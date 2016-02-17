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
using MahApps.Metro.Controls.Dialogs;

namespace RISClient.Yemian.HLA.Bubanjilu
{
    /// <summary>
    /// Bubanjilu.xaml 的交互逻辑
    /// </summary>
    public partial class Bubanjilu : Kongjian.Jichuyemian
    {
        public Bubanjilu()
        {
            InitializeComponent();
        }

        //数据源 板列表
        private List<Shujuku.HLA_banxinxi> shujuyuan_banliebiao
        {
            set { banliebiaoUIdataGrid.ItemsSource = value; }
            get { return (List<Shujuku.HLA_banxinxi>)banliebiaoUIdataGrid.ItemsSource; }
        }
        //数据源 板详细
        private List<Shujuku.HLA_hang> shujuyuan_banxiangxi
        {
            set { banxiangxiUIdataGrid.ItemsSource = value; }
            get { return (List<Shujuku.HLA_hang>)banxiangxiUIdataGrid.ItemsSource; }
        }
        //选择的 板
        private Shujuku.HLA_banxinxi xuanzedeban
        {
            get
            {
                if (banliebiaoUIdataGrid.SelectedItem == null)
                {
                    return null;
                }
                else
                {
                    return (Shujuku.HLA_banxinxi)banliebiaoUIdataGrid.SelectedItem;
                }
            }
        }

        //添加 板
        private void tianjiabanUI_Click(object sender, RoutedEventArgs e)
        {
            var tianjia = new Tianjiaban();
            var banxinxi = new Shujuku.HLA_banxinxi();
            banxinxi.riqi = DateTime.Now;
            tianjia.banxinxi = banxinxi;
            tianjia.shujuku = shujuku;
            var queding = tianjia.ShowDialog();
            if (queding == true)
            {
                shujuku.HLA_banxinxi.Add(banxinxi);
                shujuku.SaveChanges();
                fenyechaxunUI_Fenye_Click(sender, e);
            }
        }

        //修改 板
        private async void xiugaibanUI_Click(object sender, RoutedEventArgs e)
        {
            if (xuanzedeban == null)
            {
                await Gongju.tanchutishi("请先选择板！");
                return;
            }
            shujuku.SaveChanges();
            var tianjia = new Tianjiaban();
            tianjia.hangshuUIcomboBox.IsEnabled = false;
            tianjia.lieshuUIcomboBox.IsEnabled = false;
            tianjia.banxinxiUI.DataContext = xuanzedeban;
            tianjia.shujuku = shujuku;
            var queding = tianjia.ShowDialog();
            if (queding == true)
            {
                shujuku.SaveChanges();
            }
            else
            {
                shujuku.Entry(xuanzedeban).Reload();
                shujuyuan_banliebiao = shujuyuan_banliebiao.ToList();
            }
        }

        //分页查询
        private void fenyechaxunUI_Fenye_Click(object sender, RoutedEventArgs e)
        {
            var sql = shujuku.HLA_banxinxi.AsQueryable();
            if (chanxunbanhaoUItextBox.Text.Trim().Length > 0)
            {
                sql = sql.Where(z => z.banhao.Equals(chanxunbanhaoUItextBox.Text.Trim()));
            }
            if (chaxunriqiUI.SelectedDate != null)
            {
                sql = sql.Where(z => z.riqi == chaxunriqiUI.SelectedDate);
            }
            fenyechaxunUI.Gongjiye = sql.Count() / 15 + 1;
            var jieguo = sql.OrderByDescending(z => z.id).Skip(fenyechaxunUI.Dangqianye * 15 - 15).Take(15).ToList();
            shujuyuan_banliebiao = jieguo;
        }

        //删除板
        private async void shanchubanUI_Click(object sender, RoutedEventArgs e)
        {
            if (xuanzedeban == null)
            {
                await Gongju.tanchutishi("请先选择板！");
                return;
            }
            var queding = await Gongju.tanchutishi_cancel("确定删除板？");
            if (queding == MessageDialogResult.Affirmative)
            {
                shujuku.HLA_banxinxi.Remove(xuanzedeban);
                shujuyuan_banliebiao.Remove(xuanzedeban);
                shujuku.SaveChanges();
                shujuyuan_banliebiao = shujuyuan_banliebiao.ToList();
            }
        }

        //板详细点击
        private async void banxiangxiUI_Click(object sender, RoutedEventArgs e)
        {
            if (xuanzedeban == null)
            {
                await Gongju.tanchutishi("请先选择板！");
                return;
            }
            xuanzedeban.xianshi(banxiangxiUIdataGrid);
            banliebiaomokuaiUI.Visibility = Visibility.Collapsed;
            banxiangximokuiaUI.Visibility = Visibility.Visible;
        }

        //返回 板列表
        private void fanhuiliebiaoUI_Click(object sender, RoutedEventArgs e)
        {
            banliebiaomokuaiUI.Visibility = Visibility.Visible;
            banxiangximokuiaUI.Visibility = Visibility.Collapsed;
        }

        //布板
        private void bubanUI_Click(object sender, RoutedEventArgs e)
        {
            var biaoge = banxiangxiUIdataGrid;
            if (biaoge.CurrentColumn.Header.ToString().Equals("Lable"))
            {
                return;
            }
            Console.WriteLine(biaoge.CurrentColumn.Header);
            Console.WriteLine("222222222222222");
            Console.WriteLine("222222222222222");
            Console.WriteLine("222222222222222");
        }
    }
}
