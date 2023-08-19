using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.Entidades;

[Table("Usuario")]
public class Usuario
{
    [Key]
    [Column("UsuarioId")]
    public int Id { get; set; }

    [Column(TypeName = "nvarchar(50)")]
    public string Nombre { get; set; } = null!;
    [Column(TypeName = "nvarchar(50)")]
    public string Apellido { get; set; } = null!;
    [Column(TypeName = "nvarchar(50)")]
    public string Email { get; set; } = null!;
    [Column(TypeName = "nvarchar(50)")]
    public string Password { get; set; } = null!;
    public DateTime FechaCreacion { get; set; }


    //es una relacion de 1 a 1, es por eso que es una entidad y no una lista 
    //en el Lado de la entidad "UsuarioExtra" tiene un indice unico del Id Usuario
    //para que no se repita (ese indice es el que lo vuelve una relacion 1 a 1)
    public UsuarioExtra UsuarioExtra { get; set; } = null!;


    public List<UsuarioRol> UsuarioRoles { get; set; } = new();


}
