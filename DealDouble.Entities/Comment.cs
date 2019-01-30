using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDouble.Entities
{
    public class Comment : BaseEntity
    {
        public DateTime TimeStamp { get; set; }

        public string UserID { get; set; }
        public virtual DealDoubleUser User { get; set; }

        public int Rating { get; set; }
        public string Text { get; set; }
        
        public int EntityID { get; set; }
        public int RecordID { get; set; }
    }
}
