using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TrabajoIntegradorSofftek.DTOs;

namespace TrabajoIntegradorSofftek.Entities
{
	public class Rol
	{
		public Rol(RolDto dto)
		{
			Descripcion = dto.Descripcion;
			Activo = true;
		}
		public Rol(RolDto dto, int id)
		{
			Id = id;
			Descripcion = dto.Descripcion;
			Activo = true;
		}

		public Rol()
        {
            
        }

        [Key]
		[Column("CodRol")]
		public int Id { get; set; }

		[Required]
		[Column("Descripcion")]
		public string Descripcion { get; set; }

		[Required]
		[Column("Activo")]
		public bool Activo { get; set; }
	}
}

