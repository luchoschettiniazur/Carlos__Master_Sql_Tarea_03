using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace App.Models.Entidades;

[Table("UsuarioExtra")]

//Ejemplo DataAnnotation para la clase
//   De forma predeterminada, los índices no son únicos hay que poner ->  IsUnique = true
//   y si queremos poner un nombre al indice ->  Name = "UC_NomTabla_NomCampoID")]
//[Index(nameof(UsuarioId), IsUnique = true, Name = "UC_UsuarioExtra_UsuarioId")]
//   tambien se puden hacer indices compuestos -> [Index(nameof(FirstName), nameof(LastName))]

//Ejemplos DataAnnotation para los campos:
//[Column(TypeName = "decimal(18, 6)")]           //--> si queremos poner el tamaño en bbdd.
//[Column("CityName", TypeName = "varchar(25)")]  //--> si queremos poner el nombre y el tamaño que tiene en BBDD.
//[MaxLength(20)]                                 //--> es predeterminado nvarchar -> nvarchar(20)


[Index(nameof(UsuarioId), IsUnique = true, Name = "UC_UsuarioExtra_UsuarioId")]
public class UsuarioExtra
{
    [Key]
    [Column("UsuarioExtraId")]
    public int Id { get; set; }

    public int UsuarioId { get; set; }
    [ForeignKey("UsuarioId")]
    public Usuario Usuario { get; set; } = null!;


    [Column(TypeName = "nvarchar(20)")]
    public string Dni { get; set; } = null!;
    [Column(TypeName = "nvarchar(150)")]
    public string Calle { get; set; } = null!;
    [Column(TypeName = "nvarchar(20)")]
    public string CodigoPostal { get; set; } = null!;


    public int CiudadId { get; set; }
    [ForeignKey("CiudadId")]
    public Ciudad Ciudad { get; set; } = null!;


    public DateTime FechaCreacion { get; set; }


    public int PuntosAcumulados { get; set; }
}
