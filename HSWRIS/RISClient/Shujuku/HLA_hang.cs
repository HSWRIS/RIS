using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISClient.Shujuku
{
    public class HLA_hang
    {
        public long id { set; get; }

        public string Lable { set; get; }

        public int lieshu { set; get; }

        public HLA_banxinxi HLA_banxinxi { set; get; }


        public HLA_bubanshuoming C01 { set { HLA_bubans.Where(z => z.lie == 01).Single().HLA_weidian = value.HLA_weidian; } get { return HLA_bubans.Where(z => z.lie == 01).SingleOrDefault(); } }
        public HLA_bubanshuoming C02 { set { HLA_bubans.Where(z => z.lie == 02).Single().HLA_weidian = value.HLA_weidian; } get { return HLA_bubans.Where(z => z.lie == 02).SingleOrDefault(); } }
        public HLA_bubanshuoming C03 { set { HLA_bubans.Where(z => z.lie == 03).Single().HLA_weidian = value.HLA_weidian; } get { return HLA_bubans.Where(z => z.lie == 03).SingleOrDefault(); } }
        public HLA_bubanshuoming C04 { set { HLA_bubans.Where(z => z.lie == 04).Single().HLA_weidian = value.HLA_weidian; } get { return HLA_bubans.Where(z => z.lie == 04).SingleOrDefault(); } }
        public HLA_bubanshuoming C05 { set { HLA_bubans.Where(z => z.lie == 05).Single().HLA_weidian = value.HLA_weidian; } get { return HLA_bubans.Where(z => z.lie == 05).SingleOrDefault(); } }
        public HLA_bubanshuoming C06 { set { HLA_bubans.Where(z => z.lie == 06).Single().HLA_weidian = value.HLA_weidian; } get { return HLA_bubans.Where(z => z.lie == 06).SingleOrDefault(); } }
        public HLA_bubanshuoming C07 { set { HLA_bubans.Where(z => z.lie == 07).Single().HLA_weidian = value.HLA_weidian; } get { return HLA_bubans.Where(z => z.lie == 07).SingleOrDefault(); } }
        public HLA_bubanshuoming C08 { set { HLA_bubans.Where(z => z.lie == 08).Single().HLA_weidian = value.HLA_weidian; } get { return HLA_bubans.Where(z => z.lie == 08).SingleOrDefault(); } }
        public HLA_bubanshuoming C09 { set { HLA_bubans.Where(z => z.lie == 09).Single().HLA_weidian = value.HLA_weidian; } get { return HLA_bubans.Where(z => z.lie == 09).SingleOrDefault(); } }
        public HLA_bubanshuoming C10 { set { HLA_bubans.Where(z => z.lie == 10).Single().HLA_weidian = value.HLA_weidian; } get { return HLA_bubans.Where(z => z.lie == 10).SingleOrDefault(); } }
        public HLA_bubanshuoming C11 { set { HLA_bubans.Where(z => z.lie == 11).Single().HLA_weidian = value.HLA_weidian; } get { return HLA_bubans.Where(z => z.lie == 11).SingleOrDefault(); } }
        public HLA_bubanshuoming C12 { set { HLA_bubans.Where(z => z.lie == 12).Single().HLA_weidian = value.HLA_weidian; } get { return HLA_bubans.Where(z => z.lie == 12).SingleOrDefault(); } }
        public HLA_bubanshuoming C13 { set { HLA_bubans.Where(z => z.lie == 13).Single().HLA_weidian = value.HLA_weidian; } get { return HLA_bubans.Where(z => z.lie == 13).SingleOrDefault(); } }
        public HLA_bubanshuoming C14 { set { HLA_bubans.Where(z => z.lie == 14).Single().HLA_weidian = value.HLA_weidian; } get { return HLA_bubans.Where(z => z.lie == 14).SingleOrDefault(); } }
        public HLA_bubanshuoming C15 { set { HLA_bubans.Where(z => z.lie == 15).Single().HLA_weidian = value.HLA_weidian; } get { return HLA_bubans.Where(z => z.lie == 15).SingleOrDefault(); } }
        public HLA_bubanshuoming C16 { set { HLA_bubans.Where(z => z.lie == 16).Single().HLA_weidian = value.HLA_weidian; } get { return HLA_bubans.Where(z => z.lie == 16).SingleOrDefault(); } }
        public HLA_bubanshuoming C17 { set { HLA_bubans.Where(z => z.lie == 17).Single().HLA_weidian = value.HLA_weidian; } get { return HLA_bubans.Where(z => z.lie == 17).SingleOrDefault(); } }
        public HLA_bubanshuoming C18 { set { HLA_bubans.Where(z => z.lie == 18).Single().HLA_weidian = value.HLA_weidian; } get { return HLA_bubans.Where(z => z.lie == 18).SingleOrDefault(); } }
        public HLA_bubanshuoming C19 { set { HLA_bubans.Where(z => z.lie == 19).Single().HLA_weidian = value.HLA_weidian; } get { return HLA_bubans.Where(z => z.lie == 19).SingleOrDefault(); } }
        public HLA_bubanshuoming C20 { set { HLA_bubans.Where(z => z.lie == 20).Single().HLA_weidian = value.HLA_weidian; } get { return HLA_bubans.Where(z => z.lie == 20).SingleOrDefault(); } }

        public virtual ICollection<HLA_bubanshuoming> HLA_bubans { set; get; }
        public int yibushu { get { return HLA_bubans.Count; } }

    }
}
