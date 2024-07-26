using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CORS_web.Model
{
    public class register
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage ="User Name is required")]
        public  string Name { get; set; }
        [Required(ErrorMessage ="Email is required")]
        public  string Email { get; set; }
        [Required(ErrorMessage ="Password is required")]
        public  string Password { get; set; }
    }
}
