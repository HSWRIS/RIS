﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISClient.Shujuku
{
    public class HLA_weidian
    {
        public long id { set; get; }
        public string fenzu { set; get; }
        public string leixing { set; get; }
        public string weidian { set; get; }

        public virtual HLA_yangbenjieshou HLA_yangbenjieshou { set; get; }

        public virtual ICollection<HLA_bubanshuoming> HLA_bubans { set; get; }

        public int yibucishu { get { return HLA_bubans.Count; } }

        public string yangbenbianhao { get { return HLA_yangbenjieshou.bianhao; } }
        public int yangbenbuci { get { return HLA_yangbenjieshou.yibucishu; } }
        // 判断两个位点，内容一样
        public bool xiangtong(HLA_weidian z)
        {
            if (z.fenzu.Equals(this.fenzu) && z.leixing.Equals(this.leixing) && z.weidian.Equals(this.weidian))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
