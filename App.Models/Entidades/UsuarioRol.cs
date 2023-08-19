using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace App.Models.Entidades;

[Table("UsuarioRol")]

//Ejemplo DataAnnotation para la clase
//   De forma predeterminada, los índices no son únicos hay que poner ->  IsUnique = true
//   y si queremos poner un nombre al indice ->  Name = "UC_NomTabla_NomCampoID")]
//[Index(nameof(UsuarioId), IsUnique = true, Name = "UC_UsuarioExtra_UsuarioId")]
//   tambien se puden hacer indices compuestos -> [Index(nameof(FirstName), nameof(LastName))]

//Ejemplos DataAnnotation para los campos:
//[Column(TypeName = "decimal(18, 6)")]           //--> si queremos poner el tamaño en bbdd.
//[Column("CityName", TypeName = "varchar(25)")]  //--> si queremos poner el nombre y el tamaño que tiene en BBDD.
//[MaxLength(20)]                                 //--> es predeterminado nvarchar -> nvarchar(20)


[Index(nameof(UsuarioId), nameof(RolId), IsUnique = true, Name = "UC_UserioRol_UsuarioId_RolId")]
public class UsuarioRol
{
    [Key]
    [Column("UsuarioRolId")]
    public int Id { get; set; }


    public int UsuarioId { get; set; }
    [ForeignKey("UsuarioId")]
    public Usuario Usuario { get; set; } = null!;


    public int RolId { get; set; }
    [ForeignKey("RolId")]
    public Rol Rol { get; set; } = null!;
}
//jajaja le pues como nombre a la tabla de bbdd a una ya existente [Table("UsuarioRol")]
//ya lo cambie y perfecto.
//No se puede usar la tabla 'UsuarioExtra' para el tipo de entidad 'UsuarioRol'
//ya que se está usando para el tipo de entidad 'UsuarioExtra' y potencialmente
//para otros tipos de entidades, pero no existe una relación de vinculación.Agregue
//una clave externa a 'UsuarioRol' en las propiedades de la clave principal y
//apunte a la clave principal en otro tipo de entidad asignada a 'UsuarioExtra'