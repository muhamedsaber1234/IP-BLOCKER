using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsess.models
{
    public class InvoiceDetails
    {
        [MaxLength(100)]

        public string ProductName {  get; set; }
        [ForeignKey("UnitNo" )]
				 public int UnitNo { get; set; }
        [Key]
        public int LineNo { get; set; }
        public decimal Price { get; set; }

        public decimal Quantity { get; set; }

        public decimal Total { get; set; }

        public  DateTime ExpiryDate { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
