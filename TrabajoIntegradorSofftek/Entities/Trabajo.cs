using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TrabajoIntegradorSofftek.DTOs;
using TrabajoIntegradorSofftek.Migrations;

namespace TrabajoIntegradorSofftek.Entities
{
	public class Trabajo 
    {
		public Trabajo(TrabajoDto dto)
		{
			Fecha = dto.Fecha;
			CodProyecto = dto.CodProyecto;
			CodServicio = dto.CodServicio;
			CantHoras = dto.CantHoras;
			ValorHora = (double)dto.ValorHora;
			Costo = (double)dto.Costo;
			Activo = true;

		}
		public Trabajo(TrabajoDto dto, int id)
		{
			Id = id;
			CodProyecto = dto.CodProyecto;
			CodServicio = dto.CodServicio;
			Fecha = dto.Fecha;
			CantHoras = dto.CantHoras;
			ValorHora = (double)dto.ValorHora;
			Costo = (double)dto.Costo;
			Activo = true;
		}

		public Trabajo()
        {
            
        }

        [Key]
		[Column("CodTrabajo")]
		public int Id { get; set; }

		[Required]
		[Column("Fecha")]
		public DateTime Fecha { get; set; }

		[Required]
		[Column("CodProyecto")]
		public int CodProyecto { get; set; }

		[Required]
		[Column("CodServicio")]
		public int CodServicio { get; set; }

		[Required]
		[Column("CantHoras")]
		public int CantHoras { get; set; }

		[Required]
		[Column("ValorHora")]
		public double ValorHora { get; set; }

		[Required]
		[Column("Costo")]
		public double Costo { get; set; }

		[Required]
		[Column("Activo")]
		public bool Activo { get; set; } = true;



		[ForeignKey("CodProyecto")]
		public Proyecto Proyecto { get; set; }

		[ForeignKey("CodServicio")]
		public Servicio Servicio { get; set; }
	}
}
