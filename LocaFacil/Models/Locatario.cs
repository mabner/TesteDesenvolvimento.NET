using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LocaFacil.Models
{
    public class Locatario
    {
		// TODO: Normalizar documentação, adicionar blob pra anexar documentos

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Favor informar o nome do locatário")]
		[StringLength(60, ErrorMessage = "O nome deve conter no máximo 60 caracteres")]
		public string Nome { get; set; }

		[Required(ErrorMessage = "Favor informar o telefone do locatário")]
		public int TelefoneId { get; set; }
		public virtual Telefone Telefone { get; set; }

		[Required(ErrorMessage = "Favor informar o endereço do locatário")]
		public int EnderecoId { get; set; }
		public virtual Endereco Endereco { get; set; }

		public ICollection<Imovel> Imoveis { get; set; }
	}
}
