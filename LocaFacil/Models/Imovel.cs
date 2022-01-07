using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocaFacil.Models
{
    public class Imovel
    {
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Favor informar o tipo do imóvel")]
		public int TipoImovelId { get; set; }
		public virtual TipoImovel TipoImovel { get; set; }

		[Required(ErrorMessage = "Favor informar o endereço do imóvel")]
		public int EnderecoId { get; set; }
		public virtual Endereco Endereco { get; set; }

		[Required(ErrorMessage = "Favor informar o valor do aluguel")]
		[Column(TypeName = "decimal(8, 2)")]
		[Range(0, 999999.99, ErrorMessage = "Valor deve conter no máximo 8 dígitos")]
		[Display(Name = "Valor do aluguel")]
		public decimal ValorAluguel { get; set; }

		[Required(ErrorMessage = "Favor informar o valor do condomínio")]
		[Column(TypeName = "decimal(8, 2)")]
		[Range(0, 999999.99, ErrorMessage = "Valor deve conter no máximo 8 dígitos")]
		[Display(Name = "Valor do condomínio")]
		public decimal ValorCondominio { get; set; }

		[Required(ErrorMessage = "Favor informar o valor do IPTU")]
		[Column(TypeName = "decimal(8, 2)")]
		[Range(0, 999999.99, ErrorMessage = "Valor deve conter no máximo 8 dígitos")]
		[Display(Name = "Valor do IPTU")]
		public decimal ValorIPTU { get; set; }

		[Required(ErrorMessage = "Favor informar a quantidade de vagas na garagem")]
		[Column(TypeName = "decimal(5, 0)")]
		[Range(0, 99999, ErrorMessage = "Numero de vagas deve conter no máximo 5 dígitos")]
		[Display(Name = "Vagas na garagem")]
		public decimal VagaGaragem { get; set; }

		[Required(ErrorMessage = "Favor informar uma descrição do imóvel")]
		[Display(Name = "Descrição")]
		[StringLength(400, ErrorMessage = "A descrição deve conter no máximo 400 caracteres")]
		public string Descricao { get; set; }

		[Required(ErrorMessage = "Favor informar o proprietário do imóvel")]
		public int ProprietarioId { get; set; }
		public virtual Proprietario Proprietario { get; set; }

		public int LocatarioId { get; set; }
		public virtual Locatario Locatario { get; set; }
	}
}
