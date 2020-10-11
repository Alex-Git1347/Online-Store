using System;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Shop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }
        
        [Display(Name ="To Input name")]
        [StringLength(3)]
        [Required(ErrorMessage = "Length name must more 2 symbols")]
        public string name { get; set; }

        [Display(Name = "To Input surname")]
        [StringLength(3)]
        [Required(ErrorMessage = "Length name must more 2 symbols")]
        public string surname { get; set; }

        [Display(Name = "To Input adress")]
        [StringLength(10)]
        [Required(ErrorMessage = "Length name must more 10 symbols")]
        public string adress { get; set; }

        [Display(Name = "To Input phone number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(11)]
        [Required(ErrorMessage = "Length name must 11 symbols")]
        public string phone { get; set; }

        [Display(Name = "To Input email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(10)]
        [Required(ErrorMessage = "Length name must more 5 symbols")]
        public string email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }

        public List<OrderDetail> orderDetails { get; set; }
    }
}
