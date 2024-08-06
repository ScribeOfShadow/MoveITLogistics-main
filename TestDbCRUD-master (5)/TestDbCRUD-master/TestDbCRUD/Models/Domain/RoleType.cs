using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TestDbCRUD.Models.Domain
{
    public class RoleType
    {
       
        [Key]
        public int? RoleID { get; set; }
        
        public string? RoleName { get; set; }
        
    }
}
