using System.ComponentModel.DataAnnotations;

namespace LocaFacil.Models
{
    public class Endereco
    {
        public int ID { get; set; }

        [StringLength(8, MinimumLength = 8, ErrorMessage = "O CEP completo deve conter 8 números")]
        [Required(ErrorMessage = "Favor informar o CEP")]
        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [StringLength(60, ErrorMessage = "O logradouro pode conter no máximo 60 caracteres")]
        [Required(ErrorMessage = "Favor informar o logradouro")]
        public string Logradouro { get; set; }

        [StringLength(12, MinimumLength = 1, ErrorMessage = "O número deve conter no maximo 12 caracteres")]
        [Required(ErrorMessage = "Favor informar o número")]
        [Display(Name = "Número")]
        public int Numero { get; set; }

        [StringLength(20, ErrorMessage = "O complemento pode conter no máximo 20 caracteres")]
        public string Complemento { get; set; }

        [StringLength(40, MinimumLength = 1, ErrorMessage = "O bairro deve conter no máximo 40 caracteres")]
        [Required(ErrorMessage = "Favor informar o bairro")]
        public string Bairro { get; set; }

        [StringLength(60, ErrorMessage = "O nome da localidade pode conter no máximo 60 caracteres")]
        [Required(ErrorMessage = "Favor informar o nome da localidade")]
        public string Localidade { get; set; }

        public virtual UF UF { get; set; }

    }
}
