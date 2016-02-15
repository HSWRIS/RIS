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
    /// Xiugaiweidian.xaml 的交互逻辑
    /// </summary>
    public partial class Xiugaiweidian 
    {
        public Xiugaiweidian()
        {
            InitializeComponent();
        }

        //刷新列表数据
        public void shuaxinshuju()
        {
            baoliuUIdataGrid.ItemsSource = null;
            baoliuUIdataGrid.ItemsSource = yangben.HLA_weidians;
            var lsliebiao = new List<Shujuku.HLA_weidian>();
            foreach (var ls in chushishuju)
            {
                if (yangben.HLA_weidians == null || yangben.HLA_weidians.Where(z => z.xiangtong(ls)).Count() == 0)
                {
                    lsliebiao.Add(ls);
                }
            }
            shanchuUIdataGrid.ItemsSource = null;
            shanchuUIdataGrid.ItemsSource = lsliebiao;
        }
        //修改的样本接受
        public Shujuku.HLA_yangbenjieshou yangben { set; get; }
        public Shujuku.Shujuku shujuku { set; get; }
        //初始数据
        private List<Shujuku.HLA_weidian> chushishuju
       = new List<Shujuku.HLA_weidian>
           {
                new Shujuku.HLA_weidian { fenzu="HLA高分辨基因分型初筛",leixing="SBT",weidian="A"},
                new Shujuku.HLA_weidian { fenzu="HLA高分辨基因分型初筛",leixing="SBT",weidian="B"},
                new Shujuku.HLA_weidian { fenzu="HLA高分辨基因分型初筛",leixing="SBT",weidian="DRB1"},
                new Shujuku.HLA_weidian { fenzu="HLA高分辨基因分型初筛",leixing="SBT",weidian="C"},
                new Shujuku.HLA_weidian { fenzu="HLA高分辨基因分型初筛",leixing="SBT",weidian="DQB1"},
                new Shujuku.HLA_weidian { fenzu="HLA等位基因确认分型",leixing="SBT",weidian="A"},
                new Shujuku.HLA_weidian { fenzu="HLA等位基因确认分型",leixing="SBT",weidian="B"},
                new Shujuku.HLA_weidian { fenzu="HLA等位基因确认分型",leixing="SBT",weidian="DRB1"},
                new Shujuku.HLA_weidian { fenzu="HLA等位基因确认分型",leixing="SBT",weidian="C"},
                new Shujuku.HLA_weidian { fenzu="HLA等位基因确认分型",leixing="SBT",weidian="DQB1"},
                new Shujuku.HLA_weidian { fenzu="HLA等位基因确认分型",leixing="SSOP",weidian="A"},
                new Shujuku.HLA_weidian { fenzu="HLA等位基因确认分型",leixing="SSOP",weidian="B"},
                new Shujuku.HLA_weidian { fenzu="HLA等位基因确认分型",leixing="SSOP",weidian="DRB1"},
                new Shujuku.HLA_weidian { fenzu="HLA等位基因确认分型",leixing="SSOP",weidian="C"},
                new Shujuku.HLA_weidian { fenzu="HLA等位基因确认分型",leixing="SSOP",weidian="DQB1"},
                new Shujuku.HLA_weidian { fenzu="HLA等位基因确认分型",leixing="NGS",weidian="CI"},
                new Shujuku.HLA_weidian { fenzu="HLA等位基因确认分型",leixing="NGS",weidian="CII"},
                new Shujuku.HLA_weidian { fenzu="HLA初筛转确认分型",leixing="SSOP",weidian="A"},
                new Shujuku.HLA_weidian { fenzu="HLA初筛转确认分型",leixing="SSOP",weidian="B"},
                new Shujuku.HLA_weidian { fenzu="HLA初筛转确认分型",leixing="SSOP",weidian="DRB1"},
                new Shujuku.HLA_weidian { fenzu="HLA初筛转确认分型",leixing="SSOP",weidian="C"},
                new Shujuku.HLA_weidian { fenzu="HLA初筛转确认分型",leixing="SSOP",weidian="DQB1"},
                new Shujuku.HLA_weidian { fenzu="HLA初筛转确认分型",leixing="NGS",weidian="CI"},
                new Shujuku.HLA_weidian { fenzu="HLA初筛转确认分型",leixing="NGS",weidian="CII"},
                new Shujuku.HLA_weidian { fenzu="HLA免费复检",leixing="SBT",weidian="A"},
                new Shujuku.HLA_weidian { fenzu="HLA免费复检",leixing="SBT",weidian="B"},
                new Shujuku.HLA_weidian { fenzu="HLA免费复检",leixing="SBT",weidian="DRB1"},
                new Shujuku.HLA_weidian { fenzu="HLA免费复检",leixing="SBT",weidian="C"},
                new Shujuku.HLA_weidian { fenzu="HLA免费复检",leixing="SBT",weidian="DQB1"},
                new Shujuku.HLA_weidian { fenzu="HLA免费复检",leixing="SBT",weidian="DPB1"},
                new Shujuku.HLA_weidian { fenzu="HLA免费复检",leixing="SSOP",weidian="A"},
                new Shujuku.HLA_weidian { fenzu="HLA免费复检",leixing="SSOP",weidian="B"},
                new Shujuku.HLA_weidian { fenzu="HLA免费复检",leixing="SSOP",weidian="DRB1"},
                new Shujuku.HLA_weidian { fenzu="HLA免费复检",leixing="SSOP",weidian="C"},
                new Shujuku.HLA_weidian { fenzu="HLA免费复检",leixing="SSOP",weidian="DQB1"},
                new Shujuku.HLA_weidian { fenzu="HLA免费复检",leixing="SSOP",weidian="DPB1"},
                new Shujuku.HLA_weidian { fenzu="HLA单个位点基因分形",leixing="SBT",weidian="A"},
                new Shujuku.HLA_weidian { fenzu="HLA单个位点基因分形",leixing="SBT",weidian="B"},
                new Shujuku.HLA_weidian { fenzu="HLA单个位点基因分形",leixing="SBT",weidian="DRB1"},
                new Shujuku.HLA_weidian { fenzu="HLA单个位点基因分形",leixing="SBT",weidian="C"},
                new Shujuku.HLA_weidian { fenzu="HLA单个位点基因分形",leixing="SBT",weidian="DQB1"},
                new Shujuku.HLA_weidian { fenzu="HLA单个位点基因分形",leixing="SBT",weidian="DPB1"},
                new Shujuku.HLA_weidian { fenzu="HLA单个位点基因分形",leixing="SSOP",weidian="A"},
                new Shujuku.HLA_weidian { fenzu="HLA单个位点基因分形",leixing="SSOP",weidian="B"},
                new Shujuku.HLA_weidian { fenzu="HLA单个位点基因分形",leixing="SSOP",weidian="DRB1"},
                new Shujuku.HLA_weidian { fenzu="HLA单个位点基因分形",leixing="SSOP",weidian="C"},
                new Shujuku.HLA_weidian { fenzu="HLA单个位点基因分形",leixing="SSOP",weidian="DQB1"},
                new Shujuku.HLA_weidian { fenzu="HLA单个位点基因分形",leixing="SSOP",weidian="DPB1"},
       };
        //添加位点
        private void tianjiaUIbutton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var ls in shanchuUIdataGrid.SelectedItems)
            {
                var dangqian = (Shujuku.HLA_weidian)ls;
                yangben.HLA_weidians.Add(dangqian);
            }
            shuaxinshuju();
        }
        //删除位点
        private void shanchuUIbutton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var ls in baoliuUIdataGrid.SelectedItems)
            {
                var dangqian = (Shujuku.HLA_weidian)ls;
                yangben.HLA_weidians.Remove(dangqian);
                shujuku.HLA_weidian.Remove(dangqian);
            }
            shuaxinshuju();
        }
    }
}
