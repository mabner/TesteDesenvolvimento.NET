using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LocaFacil.Models
{
    public class TipoImovel
    {
		public int Id { get; set; }

		[Required(ErrorMessage = "Favor informar a descrição do tipo de imóvel")]
		[StringLength(60, ErrorMessage = "Descrição deve conter no máximo 60 caracteres")]
		[Display(Name = "Descrição")]
		public string Descricao { get; set; }

		public virtual ICollection<Imovel> Imoveis { get; set; }
	}
}
