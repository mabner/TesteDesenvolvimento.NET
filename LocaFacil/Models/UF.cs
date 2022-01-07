using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LocaFacil.Models
{
	public class Uf
	{
		[Key]
		public int Id { get; set; }

		[StringLength(2, MinimumLength = 2, ErrorMessage = "Sigla do estado deve conter 2 caracteres")]
		[Required(ErrorMessage = "Favor informar a sigla do estado")]
		[Display(Name = "UF")]
		[DefaultValue("MG")]
		public string Sigla { get; set; }

		[StringLength(20, ErrorMessage = "Nome do estado pode conter no máximo 20 caracteres")]
		[Required(ErrorMessage = "Favor informar o nome do estado")]
		[DefaultValue("Minas Gerais")]
		public string Nome { get; set; }

	}
}
