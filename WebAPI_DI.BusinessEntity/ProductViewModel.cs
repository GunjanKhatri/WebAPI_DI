using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_DI.BusinessEntity
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }

        [Range(0, 99, ErrorMessage = "please enter proper range for categoryId")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Please enter productName")]
        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
