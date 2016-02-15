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
        //申请单数据源
        private List<Shujuku.HLA_shenqingdan> shujuyuan_shenqingdan
        {
            get { return (List<Shujuku.HLA_shenqingdan>)shenqingdanUIdataGrid.ItemsSource; }
            set { shenqingdanUIdataGrid.ItemsSource = value; }
        }

        //样本数据源
        private List<Shujuku.HLA_yangbenjieshou> shujuyuan_yangbenjieshou
        {
            get { return (List<Shujuku.HLA_yangbenjieshou>)yangbenjieshouUIdataGrid.ItemsSource; }
            set { yangbenjieshouUIdataGrid.ItemsSource = value; }
        }
        //选择的申请单
        private Shujuku.HLA_shenqingdan xuanzedeshenqingdan
        {
            get
            {
                if (shenqingdanUIdataGrid.SelectedItem == null)
                {
                    return null;
                }
                else
                {
                    return (Shujuku.HLA_shenqingdan)shenqingdanUIdataGrid.SelectedItem;
                }
            }
        }
        //选择的样本接受
        private Shujuku.HLA_yangbenjieshou xuanzhedeyangbenjieshou
        {
            get
            {
                if (yangbenjieshouUIdataGrid.SelectedItem == null)
                {
                    return null;
                }
                else
                {
                    return (Shujuku.HLA_yangbenjieshou)yangbenjieshouUIdataGrid.SelectedItem;
                }
            }
        }
        //添加申请单
        private void shenqingdantianjiaUI_Click(object sender, RoutedEventArgs e)
        {
            var xindan = new Shujuku.HLA_shenqingdan();
            xindan.bianhao = "临时编号";
            var tianjia = new Tianjiashenqingdan();
            tianjia.shujuyuan = xindan;
            var queding = tianjia.ShowDialog();
            if (queding == true)
            {
                shujuku.HLA_shenqingdan.Add(xindan);
                shujuku.SaveChanges();
                xindan.gengxinbianhao(shujuku);
                fenyeshenqingdanUI.Dangqianye = 1;
                fenyeshenqingdanUI_Fenye_Click(null, null);
            }
        }

        //修改申请单
        private async void shenqingdanxiugaiUI_Click(object sender, RoutedEventArgs e)
        {
            if (xuanzedeshenqingdan == null)
            {
                await Gongju.tanchutishi("请先选择申请单！");
                return;
            }
            shujuku.SaveChanges();
            var xiugai = new Tianjiashenqingdan();
            xiugai.shujuyuan = xuanzedeshenqingdan;
            var queding = xiugai.ShowDialog();

            if (queding == true)
            {
                shujuku.SaveChanges();
            }
            else
            {
                shujuku.Entry(xuanzedeshenqingdan).Reload();
                shujuyuan_shenqingdan = shujuyuan_shenqingdan.ToList();
            }
        }
        //分页查询申请单
        private void fenyeshenqingdanUI_Fenye_Click(object sender, RoutedEventArgs e)
        {
            var sql = shujuku.HLA_shenqingdan.AsQueryable();
            if (chaxunxingmingUItextBox.Text.Trim().Length > 0)
            {
                sql = sql.Where(z => z.xingming.Equals(chaxunxingmingUItextBox.Text.Trim()));
            }
            if (chaxunbianhaoUItextBox.Text.Trim().Length > 0)
            {
                sql = sql.Where(z => z.bianhao.Equals(chaxunbianhaoUItextBox.Text.Trim()));
            }
            fenyeshenqingdanUI.Gongjiye = sql.Count() / 15 + 1;
            var jieguo = sql.OrderByDescending(z => z.id).Skip(fenyeshenqingdanUI.Dangqianye * 15 - 15).Take(15).ToList();
            shujuyuan_shenqingdan = jieguo;
        }

        //删除申请单
        private async void shenqingdanshanchuUI_Click(object sender, RoutedEventArgs e)
        {
            if (xuanzedeshenqingdan == null)
            {
                await Gongju.tanchutishi("请先选择申请单！");
                return;
            }
            var shanchu = await Gongju.tanchutishi_cancel("确定删除？");
            if (shanchu == MessageDialogResult.Affirmative)
            {
                shujuku.HLA_shenqingdan.Remove(xuanzedeshenqingdan);
                shujuku.SaveChanges();
                fenyeshenqingdanUI_Fenye_Click(sender, e);
            }
        }
        //申请单 详细
        private async void shenqingdanxiangxiUI_Click(object sender, RoutedEventArgs e)
        {
            if (xuanzedeshenqingdan == null)
            {
                await Gongju.tanchutishi("请先选择申请单！");
                return;
            }
            shujuyuan_yangbenjieshou = xuanzedeshenqingdan.HLA_yangbenjieshous.ToList();
            shenqingdanmokuaiUI.Visibility = Visibility.Collapsed;
            shenqingdanxiangximokuaiUI.Visibility = Visibility.Visible;
        }
        //添加 样本
        private void tianjiayangbenjieshouUIMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var tianjia = new Tianjiayangben();
            var xinyangben = new Shujuku.HLA_yangbenjieshou();
            tianjia.yangbenjieshouUI.DataContext = xinyangben;
            var queding = tianjia.ShowDialog();
            if (queding == true)
            {
                xuanzedeshenqingdan.HLA_yangbenjieshous.Add(xinyangben);
                shujuku.SaveChanges();
                shujuyuan_yangbenjieshou = xuanzedeshenqingdan.HLA_yangbenjieshous.ToList();
            }
        }
        //返回列表
        private void fanhuiliebiaoUI_Click(object sender, RoutedEventArgs e)
        {
            shenqingdanmokuaiUI.Visibility = Visibility.Visible;
            shenqingdanxiangximokuaiUI.Visibility = Visibility.Collapsed;
        }
        //修改样本
        private async void xiugaiyangbenjieshouUIMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (xuanzhedeyangbenjieshou == null)
            {
                await Gongju.tanchutishi("请先选择样本接受！");
                return;
            }
            shujuku.SaveChanges();

            var tianjia = new Tianjiayangben();
            tianjia.yangbenjieshouUI.DataContext = xuanzhedeyangbenjieshou;
            var queding = tianjia.ShowDialog();
            if (queding == true)
            {
                shujuku.SaveChanges();
            }
            else
            {
                shujuku.Entry(xuanzhedeyangbenjieshou).Reload();
            }
            shujuyuan_yangbenjieshou = xuanzedeshenqingdan.HLA_yangbenjieshous.ToList();
        }
        //删除样本
        private async void shanchuyangbenjieshouUIMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (xuanzhedeyangbenjieshou == null)
            {
                await Gongju.tanchutishi("请先选择样本接受！");
                return;
            }
            var shanchu = await Gongju.tanchutishi_cancel("确定删除？");
            if (shanchu == MessageDialogResult.Affirmative)
            {
                shujuku.HLA_yangbenjieshou.Remove(xuanzhedeyangbenjieshou);
                shujuku.SaveChanges();
                shujuyuan_yangbenjieshou = xuanzedeshenqingdan.HLA_yangbenjieshous.ToList();
            }
        }
        //修改 位点
        private async void xiugaiweidianUI_Click(object sender, RoutedEventArgs e)
        {
            if (xuanzhedeyangbenjieshou == null)
            {
                await Gongju.tanchutishi("请先选择样本接受！");
                return;
            }
            var xiugai = new Xiugaiweidian();
            xiugai.yangben = xuanzhedeyangbenjieshou;
            xiugai.shujuku = shujuku;
            xiugai.shuaxinshuju();
            xiugai.ShowDialog();
            shujuku.SaveChanges();
            weidianUIdataGrid.ItemsSource = null;
            weidianUIdataGrid.ItemsSource = xuanzhedeyangbenjieshou.HLA_weidians;
        }

        //样本接受 选择变化
        private void yangbenjieshouUIdataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (xuanzhedeyangbenjieshou == null)
            {
                weidianUIdataGrid.ItemsSource = null;
            }
            else
            {
                weidianUIdataGrid.ItemsSource = xuanzhedeyangbenjieshou.HLA_weidians;
            }
        }
    }
}
