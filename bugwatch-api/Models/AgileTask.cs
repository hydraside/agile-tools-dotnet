using System.ComponentModel.DataAnnotations;

namespace bugwatch_api.Models
{
    public class AgileTask
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        [MinLength(3)]
        public string Description { get; set; }
    }
}
