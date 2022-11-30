using System.ComponentModel.DataAnnotations;

namespace API_Alunos.Models {
    public class TurmaModel {       
        public int TurmaId { get; set; }

        public int Numero { get; set; }

        public int AnoLetivo { get; set; }

    }
}
