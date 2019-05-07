using DealDouble.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDouble.Entities
{
    public class Category : BaseEntity
    {
        public int? ParentCategoryID { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public bool isFeatured { get; set; }
        public string SanitizedName { get; set; }

        //public string SanitizedName {
        //    get {
        //        return Name.SanitizeString();
        //    }
        //}

        public virtual Category ParentCategory { get; set; }
        public virtual List<Auction> Auctions { get; set; }

    }
}
