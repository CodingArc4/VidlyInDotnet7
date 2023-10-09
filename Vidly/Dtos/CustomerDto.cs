using System.ComponentModel.DataAnnotations;
using Vidly.CustomValidaton;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {

        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        public byte MembershipTypeId { get; set; }
 
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Min18YrsIfAMember]
        public DateTime? BirthDate { get; set; }
    }
}
