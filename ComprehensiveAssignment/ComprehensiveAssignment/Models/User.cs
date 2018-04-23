namespace ComprehensiveAssignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Responsible for creating a user based off ADO Model of my database table Users.
    /// </summary>
    public partial class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage ="First Name Cannot Be Empty Or Contain Numbers")]
        [StringLength(50)]
        [RegularExpression(@"^([a-zA-Z]+)$")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Last Name Cannot Be Empty Or Contain Numbers")]
        [StringLength(50)]
        [RegularExpression(@"^([a-zA-Z]+)$")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Please enter a valid email... e.g. example@example.com")]
        [StringLength(100)]
        [RegularExpression(@"^([a-z0-9\.\-]+)@([a-z0-9]+)[\.]([a-z]{3})$")]
        public string Email { get; set; }

        //Reason StringLength is so high is because of the way hashed values are stored in my database.
        [Required]
        [StringLength(350)]
        public string Password { get; set; }
    }
}
