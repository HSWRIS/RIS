using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISClient.Shujuku
{
    public class HLA_yangbenjieshou
    {
        public long id { set; get; }
        public string xingming { set; get; }
        public string xingbie { set; get; }
        public HLA_shenqingdan HLA_shenqingdan { get; set; }

        public virtual ICollection<HLA_weidian> HLA_weidians { set; get; }
    }
}
