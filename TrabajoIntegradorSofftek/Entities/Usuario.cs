using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TrabajoIntegradorSofftek.DTOs;
using TrabajoIntegradorSofftek.Helpers;

namespace TrabajoIntegradorSofftek.Entities
{
    public class Usuario
    {
        public Usuario(UsuarioDto dto)
        {
			Nombre = dto.Nombre;
			Apellido = dto.Apellido;
			Edad = dto.Edad;
			Dni = dto.Dni;
			Email = dto.Email;
			Clave = PasswordEncryptHelper.EncryptPassword(dto.Clave, dto.Email);
			CodRol = dto.CodRol;
			Activo = true;
			
        }

		public Usuario(UsuarioDto dto, int id)
		{
			Id = id;
			Nombre = dto.Nombre;
			Apellido = dto.Apellido;
			Edad = dto.Edad;
			Dni = dto.Dni;
			Email = dto.Email;
			Clave = PasswordEncryptHelper.EncryptPassword(dto.Clave, dto.Email);
			CodRol = dto.CodRol;
			Activo = true;
			
		}

		public Usuario() 
		{
		
		}


        [Key]
		[Column("CodUsuario")]
		public int Id {  get; set; }

		[Required]
		[MaxLength(50)]
		[Column("Nombre")]
		public string Nombre { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("Apellido")]
        public string Apellido { get; set; }

        [Required]
        [Column("Edad")]
        public int Edad { get; set; }	

        [Required]
		[Column("Dni")]
		public int Dni {  get; set; }

		[Required]
		[Column("CodRol")]
		public int CodRol { get; set; }

		[ForeignKey("CodRol")]
		public Rol? Roles { get; set; }

		[Required]
		[MaxLength(100)]
		[Column("Email")]
		public string Email { get; set; }

		[Required]
		[MaxLength(250)]
		[Column("Clave")]
		public string Clave { get; set; }

		[Required]
		[Column("Activo")]
		public bool Activo { get; set; }
	}
}
