using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocaFacil.Models
{
	//TODO: Implementar o modelo de cliente e normalizar os dados
	// entre locatarios e proprietarios
	public class Cliente
	{
		[Key]
		public int Id { get; set; }

		public string Nome
		{ get; set; }

		//... telefone, endereço, tipo de cliente (proprietario ou locatario) etc
	}
}