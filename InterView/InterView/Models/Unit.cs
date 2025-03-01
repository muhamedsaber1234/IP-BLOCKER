using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsess.models
{
    public class Unit
    {
        [Key] 
        public int UnitNo { get; set; }
        [MaxLength(100)]
        public string UnitName { get; set; }
        public virtual List<InvoiceDetails> InvoiceDetails { get; set; }
    }
}
