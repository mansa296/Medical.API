using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Model.Entities
{
    public class MenuDetail
    {
        public int MCat_Id { get; set; }
        public string MCat_Name { get; set; }
        public int MT_Id { get; set; }
        public string MType_Name { get; set; }
        public int M_Id { get; set; }
        public string MenuName { get; set; }
        public double Price { get; set; }
        public double DisPrice { get; set; }
        public double Discount { get; set; }
        public bool Active { get; set; }
    }
}
