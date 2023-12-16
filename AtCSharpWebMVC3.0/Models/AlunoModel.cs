using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtCSharpWebMVC3._0.Models
{
    public class AlunoModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Matricula { get; set; }
        [Required]
        public int Idade { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        public string ImageFile { get; set; }

        [NotMapped]
        public IFormFile Upload {  get; set; }
        public string ImageFileName { get; set; }
    }
}
