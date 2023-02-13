using System.ComponentModel.DataAnnotations;

namespace DagensMonnerWithEntityFramework.Models
{
    public class LogState
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public Monner Monner { get; set; }
    }
}
