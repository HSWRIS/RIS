﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RISClient.Shujuku
{
    public class HLA_banxinxi
    {
        public long id { set; get; }

        public string banhao { set; get; }
        public Nullable<DateTime> riqi { set; get; }
        public string leixing { set; get; }


        public int hangshu { set; get; }                //行数

        public int lieshu { set; get; }                 //列数

        public int rongliang
        {
            get { return hangshu * lieshu; }
        }

        public int yibushu { get { return hangs.Sum(z => z.yibushu); } }
        public virtual ICollection<HLA_hang> hangs { set; get; }

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
    }
}
