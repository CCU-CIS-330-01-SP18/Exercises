namespace ComprehensiveAssignment.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    /// <summary>
    /// Entity Framework Model for my sql database.
    /// </summary>
    public partial class AdoTickrModel : DbContext
    {
        /// <summary>
        /// Constructor that sets the EF to the base name of AdoTickrModel.
        /// </summary>
        public AdoTickrModel()
            : base("name=AdoTickrModel")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        /// <summary>
        /// Additional Method.
        /// </summary>
        /// <param name="modelBuilder">Of type DbModelBuilder</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
