﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiMedidorKI.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbMedidorEntities : DbContext
    {
        public dbMedidorEntities()
            : base("name=dbMedidorEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<MTPersonaje> MTPersonaje { get; set; }
        public DbSet<MTCategoria> MTCategoria { get; set; }
        public DbSet<MTLuchador> MTLuchador { get; set; }
        public DbSet<MTLuchadorPersonaje> MTLuchadorPersonaje { get; set; }
        public DbSet<MTLuchadorReto> MTLuchadorReto { get; set; }
        public DbSet<MTReto> MTReto { get; set; }
        public DbSet<MTUsuario> MTUsuario { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
