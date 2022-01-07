using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LocaFacil.Models
{
    public class Telefone
    {
		[Key]
		public int Id { get; set; }

		[StringLength(2, MinimumLength = 2, ErrorMessage = "DDD deve conter 2 caracteres")]
		[DefaultValue("31")]
		[Display(Name = "DDD")]
		public string ddd { get; set; }

		[StringLength(9, MinimumLength = 8, ErrorMessage = "Número de telefone deve conter entre 8 a 9 caracteres")]
		[Required(ErrorMessage = "Favor informar o número do telefone")]
		[Display(Name = "Número")]
		public string numero { get; set; }

	}
}
