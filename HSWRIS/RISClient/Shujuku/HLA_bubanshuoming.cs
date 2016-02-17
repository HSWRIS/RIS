using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISClient.Shujuku
{
    public class HLA_bubanshuoming
    {
        public long id { set; get; }

        public virtual HLA_hang HLA_hang { set; get; }
        public int lie { set; get; }
        public virtual HLA_weidian HLA_weidian { set; get; }
    }
}
