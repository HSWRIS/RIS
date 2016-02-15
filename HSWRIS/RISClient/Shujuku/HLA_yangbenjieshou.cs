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

        private ICollection<HLA_weidian> HLA_weidians_;

        public virtual ICollection<HLA_weidian> HLA_weidians
        {
            set { HLA_weidians_ = value; }
            get
            {
                if (HLA_weidians_ == null)
                {
                    HLA_weidians_ = new List<HLA_weidian>(0);
                }
                return HLA_weidians_;
            }
        }
    }
}
