using App.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }


    public DbSet<Ciudad> Ciudades { get; set; }
    public DbSet<Pais> Paises { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<UsuarioExtra> UsuarioExtras { get; set; }


    public DbSet<UsuarioRol> UsuarioRoles { get; set; }


    [NotMapped] //solo es para la respueta de un Procedure (no se tiene que mapear en BBDD)
    public DbSet<SpDirUsuario> SpDirUsuarios { get; set; }


}
