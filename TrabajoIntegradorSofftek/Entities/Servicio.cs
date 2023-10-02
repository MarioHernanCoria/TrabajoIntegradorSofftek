using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TrabajoIntegradorSofftek.DTOs;

namespace TrabajoIntegradorSofftek.Entities
{
    public class Servicio
    {
		public Servicio(ServicioDto dto)
		{
			Descripcion = dto.Descripcion;
			Estado = true;
			ValorHora = (double)dto.ValorHora;

		}
		public Servicio(ServicioDto dto, int id)
		{
			Id = id;
			Descripcion = dto.Descripcion;
			Estado = true;
			ValorHora = (double)dto.ValorHora;
		}

		public Servicio()
        {
            
        }

        [Required]
		[Column("CodServicio")]
        public int Id { get; set; }

        [Required]
		[Column("Descripcion")]
        public string Descripcion {  get; set; }

        [Required]
		[Column("Estado")]
        public bool Estado { get; set; }

        [Required]
		[Column("ValorHora")]
        public double ValorHora { get; set; }
	}
}
