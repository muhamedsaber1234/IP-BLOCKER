using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcsess.models;
using Microsoft.EntityFrameworkCore;

namespace DataAcsess.Context
{
    public class InterViewDBContext : DbContext 
    {
        public InterViewDBContext(DbContextOptions<InterViewDBContext> options) :base(options) { }

        public virtual DbSet<InvoiceDetails> Invoices { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
    }
}
