using System.ComponentModel.DataAnnotations;

namespace API_Alunos.Models {
    public class AlunoModel {
        public int AlunoId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        public int Cpf { get; set; }

        [StringLength(80)]
        public string email { get; set; }

    }
}
