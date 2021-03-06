﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.ComponentModel;
using MahApps.Metro.Controls.Dialogs;

namespace RISClient.Shujuku
{

    public class HLA_banxinxi
    {
        public long id { set; get; }

        public string banhao { set; get; }
        public Nullable<DateTime> riqi { set; get; }


        public string leixing { set; get; }             //类型
        public int hangshu { set; get; }                //行数
        public int lieshu { set; get; }                 //列数

        public int rongliang
        {
            get { return hangshu * lieshu; }
        }

        public int yibushu { get { return hangs.Sum(z => z.yibushu); } }
        public virtual ICollection<HLA_hang> hangs { set; get; }

        //板 初始化
        public void chushihua()
        {
            if (this.hangs == null || this.hangs.Count == 0)
            {
                this.hangs = new List<HLA_hang>(0);
                for (int i = 0; i < this.hangshu; i++)
                {
                    var xinhang = new HLA_hang { lieshu = this.lieshu, Lable = ((char)(((int)'A') + i)).ToString() };
                    xinhang.HLA_bubans = new List<HLA_bubanshuoming>(0);
                    for (int j = 0; j < this.lieshu; j++)
                    {
                        xinhang.HLA_bubans.Add(new HLA_bubanshuoming { lie = j + 1, HLA_hang = xinhang });
                    }
                    this.hangs.Add(xinhang);
                }
            }
        }

        //datagrid 显示设置
        public void xianshi(DataGrid biaoge)
        {
            biaoge.AutoGenerateColumns = true;
            biaoge.AutoGeneratedColumns += Biaoge_AutoGeneratedColumns;
            biaoge.ItemsSource = this.hangs.ToList();
        }

        private void Biaoge_AutoGeneratedColumns(object sender, EventArgs e)
        {
            var biaoge = ((DataGrid)sender);
            var lies = biaoge.Columns;
            foreach (var lie in lies)
            {
                var xianshi = false;

                var lieming = lie.Header.ToString();
                if (lieming.Equals("Lable"))
                {
                    xianshi = true;
                }
                if (lieming.Length == 3 && lieming.Substring(0, 1).Equals("C"))
                {
                    var shu = int.Parse(lieming.Substring(1));
                    if (shu <= lieshu)
                    {
                        xianshi = true;
                    }
                }
                if (xianshi == false)
                {
                    lie.Visibility = System.Windows.Visibility.Hidden;
                }
            }
        }

        //清除 位点
        public async void qingchuweidian(DataGrid biaoge)
        {
            if (biaoge.SelectedCells.Where(z => z.Column.Header.ToString().Equals("Lable")).Count() > 0)
            {
                await Gongju.tanchutishi("行签（Lable）不能清理！");
                return;
            }

            var queding = await Gongju.tanchutishi_cancel("确定清理位点？");
            if (queding == MessageDialogResult.Affirmative)
            {

                foreach (var weizhi in biaoge.SelectedCells)
                {
                    var hang = (HLA_hang)weizhi.Item;
                    var lie = weizhi.Column.Header.ToString();

                    System.Reflection.PropertyInfo shuxing = hang.GetType().GetProperty(lie);
                    var shuoming = (HLA_bubanshuoming)shuxing.GetValue(hang, null);
                    shuoming.HLA_weidian = null;

                }
                this.xianshi(biaoge);
            }
        }

        //布板
        public async void buban(DataGrid biaoge, List<HLA_weidian> weidians)
        {
            if (biaoge.SelectedCells.Where(z => !z.Column.Header.ToString().Equals("Lable")).Count() == 0)
            {
                await Gongju.tanchutishi("请选择要布的位置！");
                return;
            }
            if (biaoge.SelectedCells.Where(z => z.Column.Header.ToString().Equals("Lable")).Count() > 0)
            {
                await Gongju.tanchutishi("不能在行签（Lable）上布点！");
                return;
            }

            if (weidians == null || weidians.Count == 0)
            {
                await Gongju.tanchutishi("请选择要布的位点！");
                return;
            }

            foreach (var weizhi in biaoge.SelectedCells)
            {
                var hang = (HLA_hang)weizhi.Item;
                var lie = weizhi.Column.Header.ToString();

                System.Reflection.PropertyInfo shuxing = hang.GetType().GetProperty(lie);
                var shuoming = (HLA_bubanshuoming)shuxing.GetValue(hang, null);
                if (shuoming.HLA_weidian != null)
                {
                    await Gongju.tanchutishi("选的位置上已有样本!");
                    return;
                }
            }

            if (biaoge.SelectedCells.Count < weidians.Count)
            {
                await Gongju.tanchutishi("选择的位置少于选择的位点！");
                return;
            }

            foreach (var weidian in weidians)
            {
                foreach (var weizhi in biaoge.SelectedCells)
                {
                    var hang = (HLA_hang)weizhi.Item;
                    var lie = weizhi.Column.Header.ToString();

                    System.Reflection.PropertyInfo shuxing = hang.GetType().GetProperty(lie);
                    var shuoming = (HLA_bubanshuoming)shuxing.GetValue(hang, null);
                    if (shuoming.HLA_weidian == null)
                    {
                        shuoming.HLA_weidian = weidian;
                        break;
                    }
                }
            }
            this.xianshi(biaoge);
        }
    }
}
