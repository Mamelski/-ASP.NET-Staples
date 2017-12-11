// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Person.cs" company="">
//   
// </copyright>
// <summary>
//   The person base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Staples.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    /// <summary>
    /// The person base.
    /// </summary>
    public class PersonBase
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Required]
        [XmlIgnore]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// The comparer.
        /// </summary>
        /// <param name="personBase">
        /// The person base.
        /// </param>
        /// <returns>
        /// The <see cref="Expression"/>.
        /// </returns>
        public static Func<PersonBase, bool> Comparer(PersonBase personBase)
        {
            // TODO this is not as cool as I thought, but I had some problems with EntityFramework and overrided Equals method 
            return p => p.FirstName == personBase.FirstName && p.LastName == personBase.LastName;
        }
    }
}