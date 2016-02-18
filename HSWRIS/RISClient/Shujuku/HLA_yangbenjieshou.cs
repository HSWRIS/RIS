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

        public string leixing { set; get; }
        public string bianhao { set; get; }

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

        /// <summary>
        /// 对新添加的，更新编号
        /// </summary>
        public void gengxinbianhao(Shujuku shujuku)
        {
            if (this.id < 1 || !"临时编号".Equals(this.bianhao))
            {
                throw new Exception("业务逻辑错误，只有对新添加的才能调用此方法！");
            }
            var jichubianhao = (this.id - shujuku.Jichuid.Where(z => z.biao.Equals("HLA_yangbenjieshou") && z.lie.Equals("bianhao") && z.fenzu.Equals(this.leixing)).Single().jichuid).ToString();
            var bianhao = this.leixing + DateTime.Now.Year + "00000".Substring(jichubianhao.Length) + jichubianhao;
            this.bianhao = bianhao;
            shujuku.SaveChanges();
        }
    }
}
