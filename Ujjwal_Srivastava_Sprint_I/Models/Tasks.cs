using System;
namespace Ujjwal_Srivastava_Sprint_I.Models
{
    public class Tasks
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public int Status { get; set; }
        public int AssiignedToUserID { get; set; }
        public string Detail { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
