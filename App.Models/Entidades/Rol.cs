using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.Entidades;

[Table("Rol")]
public class Rol
{
    [Key]
    [Column("RolId")]
    public int Id { get; set; }

    [Column(TypeName = "nvarchar(150)")]
    public string Nombre { get; set; } = null!;

    [Column(TypeName = "nvarchar(500)")]
    public string? Descripcion { get; set; }

    public DateTime FechaCreacion { get; set; }


    public List<UsuarioRol> UsuarioRoles { get; set; } = new();
}
