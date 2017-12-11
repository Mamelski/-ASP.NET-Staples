// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StaplesDatabaseContext.cs" company="">
//   
// </copyright>
// <summary>
//   The staples database context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Staples.DAL
{
    using System.Data.Entity;

    using Staples.Model;

    /// <summary>
    /// The staples database context.
    /// </summary>
    public class StaplesDatabaseContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StaplesDatabaseContext"/> class.
        /// </summary>
        public StaplesDatabaseContext()
            : base("StaplesConnection")
        {
        }

        /// <summary>
        /// Gets or sets the persons.
        /// </summary>
        public DbSet<PersonBase> Persons { get; set; }
    }
}