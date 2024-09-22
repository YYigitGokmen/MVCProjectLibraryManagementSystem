using System.ComponentModel.DataAnnotations;

namespace MVCWeek10Project.Models
{
    public class User
    {
        //Id: (Unique ID, type int)
        [Key]
        public int Id { get; set; }


        //FullName: (Member name and surname, in string type)
        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(150, ErrorMessage = "Full name cannot exceed 150 characters.")]
        public string FullName { get; set; }

        //Email: (Member email address, in string type)
        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        //Password: (Member login password, string type)
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //PhoneNumber: (Member phone number, in string type)

        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Join date is required.")]
        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }
        //JoinDate: (Member registration date, in DateTime type)

    }
}
