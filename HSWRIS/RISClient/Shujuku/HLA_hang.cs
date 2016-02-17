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


        public HLA_bubanshuoming C01 { set { value.lie = 01; HLA_bubans.Remove(HLA_bubans.Where(z => z.lie == 01).SingleOrDefault()); HLA_bubans.Add(value); } get { return HLA_bubans.Where(z => z.lie == 01).SingleOrDefault(); } }
        public HLA_bubanshuoming C02 { set { value.lie = 02; HLA_bubans.Remove(HLA_bubans.Where(z => z.lie == 02).SingleOrDefault()); HLA_bubans.Add(value); } get { return HLA_bubans.Where(z => z.lie == 02).SingleOrDefault(); } }
        public HLA_bubanshuoming C03 { set { value.lie = 03; HLA_bubans.Remove(HLA_bubans.Where(z => z.lie == 03).SingleOrDefault()); HLA_bubans.Add(value); } get { return HLA_bubans.Where(z => z.lie == 03).SingleOrDefault(); } }
        public HLA_bubanshuoming C04 { set { value.lie = 04; HLA_bubans.Remove(HLA_bubans.Where(z => z.lie == 04).SingleOrDefault()); HLA_bubans.Add(value); } get { return HLA_bubans.Where(z => z.lie == 04).SingleOrDefault(); } }
        public HLA_bubanshuoming C05 { set { value.lie = 05; HLA_bubans.Remove(HLA_bubans.Where(z => z.lie == 05).SingleOrDefault()); HLA_bubans.Add(value); } get { return HLA_bubans.Where(z => z.lie == 05).SingleOrDefault(); } }
        public HLA_bubanshuoming C06 { set { value.lie = 06; HLA_bubans.Remove(HLA_bubans.Where(z => z.lie == 06).SingleOrDefault()); HLA_bubans.Add(value); } get { return HLA_bubans.Where(z => z.lie == 06).SingleOrDefault(); } }
        public HLA_bubanshuoming C07 { set { value.lie = 07; HLA_bubans.Remove(HLA_bubans.Where(z => z.lie == 07).SingleOrDefault()); HLA_bubans.Add(value); } get { return HLA_bubans.Where(z => z.lie == 07).SingleOrDefault(); } }
        public HLA_bubanshuoming C08 { set { value.lie = 08; HLA_bubans.Remove(HLA_bubans.Where(z => z.lie == 08).SingleOrDefault()); HLA_bubans.Add(value); } get { return HLA_bubans.Where(z => z.lie == 08).SingleOrDefault(); } }
        public HLA_bubanshuoming C09 { set { value.lie = 09; HLA_bubans.Remove(HLA_bubans.Where(z => z.lie == 09).SingleOrDefault()); HLA_bubans.Add(value); } get { return HLA_bubans.Where(z => z.lie == 09).SingleOrDefault(); } }
        public HLA_bubanshuoming C10 { set { value.lie = 10; HLA_bubans.Remove(HLA_bubans.Where(z => z.lie == 10).SingleOrDefault()); HLA_bubans.Add(value); } get { return HLA_bubans.Where(z => z.lie == 10).SingleOrDefault(); } }
        public HLA_bubanshuoming C11 { set { value.lie = 11; HLA_bubans.Remove(HLA_bubans.Where(z => z.lie == 11).SingleOrDefault()); HLA_bubans.Add(value); } get { return HLA_bubans.Where(z => z.lie == 11).SingleOrDefault(); } }
        public HLA_bubanshuoming C12 { set { value.lie = 12; HLA_bubans.Remove(HLA_bubans.Where(z => z.lie == 12).SingleOrDefault()); HLA_bubans.Add(value); } get { return HLA_bubans.Where(z => z.lie == 12).SingleOrDefault(); } }
        public HLA_bubanshuoming C13 { set { value.lie = 13; HLA_bubans.Remove(HLA_bubans.Where(z => z.lie == 13).SingleOrDefault()); HLA_bubans.Add(value); } get { return HLA_bubans.Where(z => z.lie == 13).SingleOrDefault(); } }
        public HLA_bubanshuoming C14 { set { value.lie = 14; HLA_bubans.Remove(HLA_bubans.Where(z => z.lie == 14).SingleOrDefault()); HLA_bubans.Add(value); } get { return HLA_bubans.Where(z => z.lie == 14).SingleOrDefault(); } }
        public HLA_bubanshuoming C15 { set { value.lie = 15; HLA_bubans.Remove(HLA_bubans.Where(z => z.lie == 15).SingleOrDefault()); HLA_bubans.Add(value); } get { return HLA_bubans.Where(z => z.lie == 15).SingleOrDefault(); } }
        public HLA_bubanshuoming C16 { set { value.lie = 16; HLA_bubans.Remove(HLA_bubans.Where(z => z.lie == 16).SingleOrDefault()); HLA_bubans.Add(value); } get { return HLA_bubans.Where(z => z.lie == 16).SingleOrDefault(); } }
        public HLA_bubanshuoming C17 { set { value.lie = 17; HLA_bubans.Remove(HLA_bubans.Where(z => z.lie == 17).SingleOrDefault()); HLA_bubans.Add(value); } get { return HLA_bubans.Where(z => z.lie == 17).SingleOrDefault(); } }
        public HLA_bubanshuoming C18 { set { value.lie = 18; HLA_bubans.Remove(HLA_bubans.Where(z => z.lie == 18).SingleOrDefault()); HLA_bubans.Add(value); } get { return HLA_bubans.Where(z => z.lie == 18).SingleOrDefault(); } }
        public HLA_bubanshuoming C19 { set { value.lie = 19; HLA_bubans.Remove(HLA_bubans.Where(z => z.lie == 19).SingleOrDefault()); HLA_bubans.Add(value); } get { return HLA_bubans.Where(z => z.lie == 19).SingleOrDefault(); } }
        public HLA_bubanshuoming C20 { set { value.lie = 20; HLA_bubans.Remove(HLA_bubans.Where(z => z.lie == 20).SingleOrDefault()); HLA_bubans.Add(value); } get { return HLA_bubans.Where(z => z.lie == 20).SingleOrDefault(); } }

        public virtual ICollection<HLA_bubanshuoming> HLA_bubans { set; get; }
        public int yibushu { get { return HLA_bubans.Count; } }

    }
}
