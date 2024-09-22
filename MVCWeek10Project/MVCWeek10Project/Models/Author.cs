using System.ComponentModel.DataAnnotations;

namespace MVCWeek10Project.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        //Id: (Unique ID, type int)

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(100, ErrorMessage = "First name cannot exceed 100 characters.")]
        //FirstName: (Author's name, in string type)
        public string FirstName { get; set; }

        //LastName: (Author's surname, in string type)
        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(100, ErrorMessage = "Last name cannot exceed 100 characters.")]
        public string LastName { get; set; }


        //DateOfBirth: (Date of birth, of type DateTime)
        [Required(ErrorMessage = "Date of birth is required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

    }
}
