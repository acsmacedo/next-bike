using System;
using System.ComponentModel.DataAnnotations;

namespace NextBike.Models
{
    public class Client
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Endereço")]
        public string Address { get; set; }

        [Display(Name = "Telefone")]
        public string Phone { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDay { get; set; }

        [Display(Name = "Limite de Aluguel")]
        public int MaxQtyRented { get; set; }
    }
}
