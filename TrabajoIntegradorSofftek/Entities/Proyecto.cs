using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrabajoIntegradorSofftek.DTOs;

namespace TrabajoIntegradorSofftek.Entities
{
    public class Proyecto
    {

		public Proyecto(ProyectoDto dto)
		{
			Nombre = dto.Nombre;
			Direccion = dto.Direccion;
			Estado = dto.Estado;
			Activo = true;
		}
		public Proyecto(ProyectoDto dto, int id)
		{
			Id = id;
			Nombre = dto.Nombre;
			Direccion = dto.Direccion;
			Estado = dto.Estado;
			Activo = true;
		}

		public Proyecto()
        {
            
        }

        [Key]
        [Column("CodProyecto")]
        public int Id {  get; set; }

        [Required]
        [MaxLength(25)]
        [Column("Nombre")]
        public string Nombre { get; set; }

        [Required]
		[MaxLength(50)]
		[Column("Direccion")]
        public string Direccion {  get; set; }

        [Required]
        [Column("Estado")]
        public int Estado { get; set; }

		[Required]
		[Column("Activo")]
		public bool Activo { get; set; }

		internal bool Any()
		{
			throw new NotImplementedException();
		}
	}
}
