// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonDetails.cs" company="">
//   
// </copyright>
// <summary>
//   The person.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Staples.Model
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The person.
    /// </summary>
    public class PersonDetails : PersonBase
    {
        /// <summary>
        /// Gets or sets the sex.
        /// </summary>
        [Required]
        public Sex Sex { get; set; }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        [Required]
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is a cool person.
        /// </summary>
        [Required]
        [Display(Name = "Is this person cool ?")]
        public bool IsACoolPerson { get; set; }
    }
}