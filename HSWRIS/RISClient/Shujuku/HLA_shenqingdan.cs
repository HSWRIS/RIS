using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISClient.Shujuku
{
    public class HLA_shenqingdan
    {
        public long id { set; get; }
        public string bianhao { set; get; }
        public string xingming { set; get; }
        public string xingbie { set; get; }
        public Nullable<DateTime> chushengriqi { set; get; }
        public string shenfenzhenghao { set; get; }

        public virtual ICollection<HLA_yangbenjieshou> HLA_yangbenjieshous { get; set; }

        /// <summary>
        /// 对新添加的，更新编号
        /// </summary>
        public void gengxinbianhao(Shujuku shujuku)
        {
            if (this.id < 1 || !"临时编号".Equals(this.bianhao))
            {
                throw new Exception("业务逻辑错误，只有对新添加的才能调用此方法！");
            }
            var jichubianhao =(this.id- shujuku.Jichuid.Where(z => z.biao.Equals("HLA_shenqingdan") && z.lie.Equals("bianhao") && z.fenzu.Equals("")).Single().jichuid).ToString();
            var bianhao = "HLA" + DateTime.Now.Year + "00000".Substring(jichubianhao.Length) + jichubianhao;
            this.bianhao = bianhao;
            shujuku.SaveChanges();
        }
    }
}
