﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PersonSearch
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using PersonSearch.Model;
    
    public partial class PersonContextContainer : DbContext
    {
        public PersonContextContainer()
            : base("name=PersonContextContainer")
        {
        }
    
        public DbSet<Person> Persons { get; set; }
    
    }
}
