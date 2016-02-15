using System;
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
        public string beizhu { set; get; }

        public HLA_yangbenjieshou HLA_yangbenjieshou { set; get; }
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
