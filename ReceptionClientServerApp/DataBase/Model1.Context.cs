//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReceptionClientServerApp.DataBase
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CorpusReceptionEntities1 : DbContext
    {
        public CorpusReceptionEntities1()
            : base("name=CorpusReceptionEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Existence> Existence { get; set; }
        public virtual DbSet<Hotelrooms> Hotelrooms { get; set; }
        public virtual DbSet<Reservations> Reservations { get; set; }
        public virtual DbSet<RoomCategories> RoomCategories { get; set; }
        public virtual DbSet<RoomStates> RoomStates { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<UsersData> UsersData { get; set; }
    }
}
