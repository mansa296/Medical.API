using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Model.Entities
{
    public class MTypeDetail
    {
        public int MCat_Id { get; set; }
        public string MCat_Name { get; set; }
        public int MT_Id { get; set; }
        public string MType_Name { get; set; }
        public int Value { get; set; }
        public string Text { get; set; }
    }
    public class MCategoryDetail
    {
        public int MCat_Id { get; set; }
        public string MCat_Name { get; set; }


    }
}
