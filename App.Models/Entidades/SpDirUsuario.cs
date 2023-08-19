using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.Entidades;

//lo que me devuelve el store procedure
//no necesito key -> utilizamos el [Keyless] para que no se queje EntityFramework
//  OJO esta tabla no se mapea en bbdd en el DbContext hacemos esto:
//     [NotMapped] //solo es para la respueta de un Procedure (no se tiene que mapear en BBDD)
//     public DbSet<spDirUsuario> SpDirUsuario { get; set; }
[Keyless]   //necesita el pakage-> Microsoft.EntityFrameworkCore
public class SpDirUsuario
{

    public DateTime FechaCreacion { get; set; }

    public int UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Calle { get; set; } = null!;

    public string CodigoPostal { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public string Pais { get; set; } = null!;

}


