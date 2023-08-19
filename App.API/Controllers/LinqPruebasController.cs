using App.Data;
using App.Models.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LinqPruebasController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public LinqPruebasController(ApplicationDbContext context)
    {
        _context = context;
    }














    ////--Creo tabla   Pais   y   Ciudad (de 1 a muchos) 
    ////tablas: Pais - Ciudad 
    //// lo voy hacer con Query y Method sintax
    ////--**************************************************************************

    //[HttpGet("GetPaisesQuery")]
    //public async Task<ActionResult<IEnumerable<Pais>>> GetPaisesQuery()
    //{
    //    var lista = await (from p in _context.Paises 
    //                       select new
    //                       {
    //                           p.Id,
    //                           p.Nombre,
    //                           p.FechaCreacion
    //                       }).ToListAsync();
    //    return Ok(lista);
    //}
    //[HttpGet("GetPaisesMethod")]
    //public async Task<ActionResult<IEnumerable<Pais>>> GetPaisesMethod()
    //{
    //    var lista = await _context.Paises
    //                       .Select( p=> new
    //                       {
    //                           p.Id,
    //                           p.Nombre,
    //                           p.FechaCreacion
    //                       }).ToListAsync();
    //    return Ok(lista);
    //}




    //[HttpGet("GetCiudadesQuery")]
    //public async Task<ActionResult<IEnumerable<Pais>>> GetCiudadesQuery()
    //{
    //    var lista = await (from c in _context.Ciudades
    //                       select new
    //                       {
    //                           c.Id,
    //                           c.Nombre,
    //                           c.FechaCreacion
    //                       }).ToListAsync();
    //    return Ok(lista);
    //}
    //[HttpGet("GetCiudadesMethod")]
    //public async Task<ActionResult<IEnumerable<Pais>>> GetCiudadesMethod()
    //{
    //    var lista = await _context.Ciudades
    //                       .Select( c => new
    //                       {
    //                           c.Id,
    //                           c.Nombre,
    //                           c.FechaCreacion
    //                       }).ToListAsync();
    //    return Ok(lista);
    //}




    //[HttpGet("GetCiudadesConPaisQuery")]
    //public async Task<ActionResult<IEnumerable<Ciudad>>> GetCiudadesConPaisQuery()
    //{
    //    var lista = await (from c in _context.Ciudades.Include(c => c.Pais) 
    //                       select new
    //                       {
    //                           c.Id,
    //                           c.Nombre,
    //                           c.FechaCreacion,
    //                           Pais = c.Pais.Nombre
    //                       }).ToListAsync();
    //    return Ok(lista);
    //}
    //[HttpGet("GetCiudadesConPaisMethod")]
    //public async Task<ActionResult<IEnumerable<Ciudad>>> GetCiudadesConPaisMethod()
    //{
    //    var lista = await _context.Ciudades.Include(c => c.Pais)
    //                       .Select( c=> new
    //                       {
    //                           c.Id,
    //                           c.Nombre,
    //                           c.FechaCreacion,
    //                           Pais = c.Pais.Nombre
    //                       }).ToListAsync();
    //    return Ok(lista);
    //}




    //[HttpGet("GetPaisesConCiudadesQuery")]
    //public async Task<ActionResult<IEnumerable<Ciudad>>> GetPaisesConCiudadesQuery()
    //{
    //    var lista = await (from p in _context.Paises.Include(p => p.Ciudades)
    //                       select new
    //                       {
    //                           p.Id,
    //                           Pais = p.Nombre,
    //                           p.FechaCreacion,
    //                           Ciudades = p.Ciudades.Select(c => new
    //                           {
    //                               IdCiudad = c.Id,
    //                               Ciudad = c.Nombre,
    //                               FechaCreacionCiudad = c.FechaCreacion
    //                           })
    //                       }).ToListAsync();
    //    return Ok(lista);
    //}
    //[HttpGet("GetPaisesConCiudadesMethod")]
    //public async Task<ActionResult<IEnumerable<Ciudad>>> GetPaisesConCiudadesMethod()
    //{
    //    var lista = await _context.Paises.Include(p => p.Ciudades)
    //                       .Select ( p => new
    //                       {
    //                           p.Id,
    //                           Pais = p.Nombre,
    //                           p.FechaCreacion,
    //                           Ciudades = p.Ciudades.Select(c => new
    //                           {
    //                               IdCiudad = c.Id,
    //                               Ciudad = c.Nombre,
    //                               FechaCreacionCiudad = c.FechaCreacion
    //                           })
    //                       }).ToListAsync();
    //    return Ok(lista);
    //}




    ////--Creo tabla Usuario y Usuarioextra con relacion de 1 a 1
    ////tablas: Usuario - Usuarioextra 
    //// lo voy hacer solo con Method sintax
    ////--**************************************************************************

    //[HttpGet("GetUsuarioConExtraMethod")]
    //public async Task<ActionResult<IEnumerable<Ciudad>>> GetUsuarioConExtraMethod()
    //{
    //    var lista = await _context.Usuarios.Include(u => u.UsuarioExtra)
    //                       .Select(p => new
    //                       {
    //                           p.Id,
    //                           p.Nombre,
    //                           p.Apellido,
    //                           p.Email,
    //                           p.FechaCreacion,
    //                           p.UsuarioExtra.Calle,
    //                           p.UsuarioExtra.CodigoPostal,
    //                           p.UsuarioExtra.CiudadId                     
    //                       }).ToListAsync();
    //    return Ok(lista);
    //}


    ////Igual que anterior pero añadidendo las entidades de Ciudad y de esta Pais (desde UsuarioExtra)
    //[HttpGet("GetUsuarioConExtraConCiudadPaisMethod")]
    //public async Task<ActionResult<IEnumerable<Ciudad>>> GetUsuarioConExtraConCiudadPaisMethod()
    //{
    //    var lista = await _context.Usuarios
    //        .Include(u => u.UsuarioExtra).ThenInclude( e => e.Ciudad).ThenInclude(c => c.Pais)
    //                       .Select(p => new
    //                       {
    //                           p.Id,
    //                           p.Nombre,
    //                           p.Apellido,
    //                           p.Email,
    //                           p.FechaCreacion,
    //                           p.UsuarioExtra.Calle,
    //                           p.UsuarioExtra.CodigoPostal,
    //                           Ciudad = p.UsuarioExtra.Ciudad.Nombre,
    //                           Pais = p.UsuarioExtra.Ciudad.Pais.Nombre,
                               
    //                       }).ToListAsync();
    //    return Ok(lista);
    //}





    ////--Creo tabla Rol y UsuarioRol(muchos a muchos) -> Usuario - Rol con tabla itermedia UsuarioRol
    ////tablas: Rol - UsuarioRol -  Usuario
    //// lo voy hacer solo con Method sintax
    ////--**************************************************************************

    ////Igual que anterior pero añadidendo las entidades de Ciudad y de esta Pais (desde UsuarioExtra)
    //[HttpGet("GetUsuarioConSusRolesMethod")]
    //public async Task<ActionResult<IEnumerable<Ciudad>>> GetUsuarioConSusRolesMethod()
    //{
    //    var lista = await _context.Usuarios
    //        .Include(u => u.UsuarioRoles).ThenInclude(ur => ur.Rol)
    //                       .Select(u => new
    //                       {
    //                           u.Id,
    //                           u.Nombre,
    //                           u.Apellido,
    //                           u.Email,
    //                           u.FechaCreacion,
    //                           Roles = u.UsuarioRoles.Select(ur => new
    //                           {
    //                               Rol = ur.Rol.Nombre
    //                           })
    //                       }).ToListAsync();
    //    return Ok(lista);
    //}


    //[HttpGet("GetRolConSusUsuariosMethod")]
    //public async Task<ActionResult<IEnumerable<Ciudad>>> GetRolConSusUsuariosMethod()
    //{
    //    var lista = await _context.Roles
    //        .Include(r => r.UsuarioRoles).ThenInclude(ru => ru.Usuario)
    //                       .Select(r => new
    //                       {
    //                           r.Id,
    //                           r.Nombre,
    //                           r.FechaCreacion,
    //                           Usuarios = r.UsuarioRoles.Select(ru => new
    //                           {
    //                               Usuario = ru.Usuario.Nombre
    //                           })
    //                       }).ToListAsync();
    //    return Ok(lista);
    //}











}//fin clase LinqPruebasController
