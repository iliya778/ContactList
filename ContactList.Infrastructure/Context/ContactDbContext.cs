using ContactList.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.Infrastructure.Context
{
    public class ContactDbContext : DbContext
    {

        public ContactDbContext(DbContextOptions<ContactDbContext>
            options) :
            base(options)
        {

        }

        public DbSet<User> Users { get; set; }


    }
}
