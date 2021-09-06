using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTracking.Models
{
    public class Details
    {
        public int ID { get; set; }
        public string JsonResponse { get; set; }
        public string IsSuccess { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int ApiType { get; set; }
    }
}
