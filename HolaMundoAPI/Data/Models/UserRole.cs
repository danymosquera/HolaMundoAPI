using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HolaMundoAPI.Data.Enumerations;

namespace HolaMundoAPI.Data.Models
{
    public class UserRole
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RoleId { get; set; }

        [Required]
        public string Name { get; set; }

        public RoleType Type { get; set; }
    }

}
