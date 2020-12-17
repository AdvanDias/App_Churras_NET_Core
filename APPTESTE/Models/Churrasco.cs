using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APPTESTE.Models
{
    public class Churrasco
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é Obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo data é Obrigatório")]
        public DateTime Data { get; set; }

        public string Observacoes { get; set; }

       
    }
}
