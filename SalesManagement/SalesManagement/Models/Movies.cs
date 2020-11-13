using System;
using System.Collections.Generic;

namespace SalesManagement.Models
{
    public partial class Movies
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string ReleasedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
    }
}
