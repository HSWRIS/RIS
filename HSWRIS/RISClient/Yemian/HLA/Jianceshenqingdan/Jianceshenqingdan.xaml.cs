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
        //申请单数据源
        private List<Shujuku.HLA_shenqingdan> shujuyuan_shenqingdan
        {
            get { return (List<Shujuku.HLA_shenqingdan>)shenqingdanUIdataGrid.ItemsSource; }
            set { shenqingdanUIdataGrid.ItemsSource = value; }
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
                fenyeshenqingdanUI_Fenye_Click(null,null);
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


    }
}
