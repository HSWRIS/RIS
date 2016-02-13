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
            if (shanchu==MessageDialogResult.Affirmative)
            {
                shujuku.HLA_shenqingdan.Remove(xuanzedeshenqingdan);
                shujuku.SaveChanges();
                fenyeshenqingdanUI_Fenye_Click(sender,e);
            }
        }
    }
}
