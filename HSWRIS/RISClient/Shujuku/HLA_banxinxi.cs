using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISClient.Shujuku
{
    public class HLA_banxinxi
    {
        public long id { set; get; }

        public string banhao { set; get; }
        public Nullable<DateTime> riqi { set; get; }
        public string leixing { set; get; }

        public int hangshu { set; get; }//行数
        public int lieshu { set; get; }//列数

        private  ICollection<HLA_hang> hangs_;

        public virtual ICollection<HLA_hang> hangs
        {
            set { hangs_ = value; }
            get
            {
                if (hangs_ == null)
                {
                    hangs_ = new List<HLA_hang> { new HLA_hang { hangqian="A"}, };
                }
                return hangs_;
            }
        }
    }
}
