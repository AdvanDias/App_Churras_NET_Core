using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APPTESTE.Models
{
    public class Participante
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é Obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "Contribuição")]
        public float V_Com { get; set; }

        [Display(Name = "Churrasco")]
        public int ChurrascoId { get; set; }
        public Churrasco Churrasco { get; set; }

    }
}
