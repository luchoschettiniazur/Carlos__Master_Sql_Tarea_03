using App.Data;
using App.Models.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class Tarea03Controller : ControllerBase
{

    private readonly ApplicationDbContext _context;

    public Tarea03Controller(ApplicationDbContext context)
    {
        _context = context;
    }

    //de las agrupaciones ->"Count"-> es el unico que se puede sacar directamente de la agrupacion.
    //Count -> se puede sacar directamente de la agrupacion (como se ve)  
    //-> Catidad = grp.Count()
    [HttpGet("GetCountTotalUsuariosPorPaisMethod")]
    public async Task<ActionResult<IEnumerable<Ciudad>>> GetCountTotalUsuariosPorPaisMethod()
    {
        var lista = await _context.Usuarios.Include(u => u.UsuarioExtra)
                                           .ThenInclude( ux => ux.Ciudad).ThenInclude(c => c.Pais)
                                           .Where(u => u.FechaCreacion.Year >= 2021 && u.FechaCreacion.Year <= 2023)
                                           .GroupBy(u => u.UsuarioExtra.Ciudad.Pais.Nombre)
                           .Select(grp => new
                           {
                               Pais = grp.Key,
                               CatidadDeRegPorPais = grp.Count()
                           }).ToListAsync();
        return Ok(lista);
    }

    [HttpGet("GetCountTotalUsuariosPorPaisQuery")]
    public async Task<ActionResult<IEnumerable<Ciudad>>> GetCountTotalUsuariosPorPaisQuery()
    {
        var lista = await (from u in _context.Usuarios.Include(u => u.UsuarioExtra)
                           .ThenInclude(ux => ux.Ciudad).ThenInclude(c => c.Pais)
                           where u.FechaCreacion.Year >= 2021 && u.FechaCreacion.Year <= 2023
                           group u by u.UsuarioExtra.Ciudad.Pais.Nombre into grp
                           select new
                           {
                               Pais = grp.Key,
                               CatidadDeRegPorPais = grp.Count()
                           }
                           ).ToListAsync();
        return Ok(lista);
    }




    //Min -> no se puede sacar directamente de la agrupacion, hay que hacer un select del agrupado
    //y escoger el campo del que se quiere el minimo (como se ve)  
    //-> PuntosMinimosDeFechaCreacion = grp.Select(u => u.UsuarioExtra.PuntosAcumulados).Min()
    [HttpGet("GetMinPuntosMinimosPorFechaCreacionMethod")]
    public async Task<ActionResult<IEnumerable<Ciudad>>> GetMinPuntosMinimosPorFechaCreacionMethod()
    {
        var lista = await _context.Usuarios.Include(u => u.UsuarioExtra)
                                           .Where(u => u.FechaCreacion.Year >= 2022 && u.FechaCreacion.Year <= 2023)
                                           .GroupBy(u => u.FechaCreacion)
                           .Select(grp => new
                           {
                               FechaCreacionUsuario = grp.Key,
                               PuntosMinimosPorFechaCreacion = grp.Select(u => u.UsuarioExtra.PuntosAcumulados).Min()
                           }).ToListAsync();
        return Ok(lista);
    }

    [HttpGet("GetMinPuntosMinimosPorFechaCreacionQuery")]
    public async Task<ActionResult<IEnumerable<Ciudad>>> GetMinPuntosMinimosPorFechaCreacionQuery()
    {
        var lista = await (from u in _context.Usuarios.Include(u => u.UsuarioExtra)
                           where u.FechaCreacion.Year >= 2022 && u.FechaCreacion.Year <= 2023
                           group u by u.FechaCreacion into grp
                           select new
                           {
                               FechaCreacionUsuario = grp.Key,
                               PuntosMinimosPorFechaCreacion = (from u in grp select u.UsuarioExtra.PuntosAcumulados).Min()
                           }
                           ).ToListAsync();
        return Ok(lista);
    }





    //Max -> no se puede sacar directamente de la agrupacion, hay que hacer un select del agrupado
    //y escoger el campo del que se quiere el maximo (como se ve)  
    //-> PuntosMinimosDeFechaCreacion = grp.Select(u => u.UsuarioExtra.PuntosAcumulados).Max()
    [HttpGet("GetMinPuntosMaximosPorFechaCreacionMethod")]
    public async Task<ActionResult<IEnumerable<Ciudad>>> GetMinPuntosMaximosPorFechaCreacionMethod()
    {
        var lista = await _context.Usuarios.Include(u => u.UsuarioExtra)
                                           .Where(u => u.FechaCreacion.Year >= 2022 && u.FechaCreacion.Year <= 2023)
                                           .GroupBy(u => u.FechaCreacion)
                           .Select(grp => new
                           {
                               FechaCreacionUsuario = grp.Key,
                               PuntosMaximosPorFechaCreacion = grp.Select(u => u.UsuarioExtra.PuntosAcumulados).Max()
                           }).ToListAsync();
        return Ok(lista);
    }

    [HttpGet("GetMinPuntosMaximosPorFechaCreacionQuery")]
    public async Task<ActionResult<IEnumerable<Ciudad>>> GetMinPuntosMaximosPorFechaCreacionQuery()
    {
        var lista = await ( from u in _context.Usuarios.Include(u => u.UsuarioExtra)
                                           where u.FechaCreacion.Year >= 2022 && u.FechaCreacion.Year <= 2023
                                           group u  by u.FechaCreacion into grp
                           select new
                           {
                               FechaCreacionUsuario = grp.Key,
                               PuntosMaximosPorFechaCreacion = (from u in grp select u.UsuarioExtra.PuntosAcumulados).Max()
                           }
                           ).ToListAsync();
        return Ok(lista);
    }






    //Avg -> no se puede sacar directamente de la agrupacion, hay que hacer un select del agrupado
    //y escoger el campo del que se quiere el Avg (como se ve)  
    //-> PuntosMinimosDeFechaCreacion = grp.Select(u => u.UsuarioExtra.PuntosAcumulados).Max()
    [HttpGet("GetAvgPuntosMediosPorFechaCreacionMethod")]
    public async Task<ActionResult<IEnumerable<Ciudad>>> GetAvgPuntosMediosPorFechaCreacionMethod()
    {
        var lista = await _context.Usuarios.Include(u => u.UsuarioExtra)
                                           .Where(u => u.FechaCreacion.Year >= 2022 && u.FechaCreacion.Year <= 2023)
                                           .GroupBy(u => u.FechaCreacion)
                           .Select(grp => new
                           {
                               FechaCreacionUsuario = grp.Key,
                               PuntosMediosPorFechaCreacion = grp.Select(u => u.UsuarioExtra.PuntosAcumulados).Average()
                           }).ToListAsync();
        return Ok(lista);
    }

    [HttpGet("GetAvgPuntosMediosPorFechaCreacionQuery")]
    public async Task<ActionResult<IEnumerable<Ciudad>>> GetMinPuntosMediosPorFechaCreacionQuery()
    {
        var lista = await (from u in _context.Usuarios.Include(u => u.UsuarioExtra)
                           where u.FechaCreacion.Year >= 2022 && u.FechaCreacion.Year <= 2023
                           group u by u.FechaCreacion into grp
                           select new
                           {
                               FechaCreacionUsuario = grp.Key,
                               PuntosMediosPorFechaCreacion = (from u in grp select u.UsuarioExtra.PuntosAcumulados).Average()
                           }
                           ).ToListAsync();
        return Ok(lista);
    }




    [HttpGet("GetDirUsuariosPorAnioCreacionSP")]
    public async Task<ActionResult<IEnumerable<SpDirUsuario>>> GetRangoSP(int anioInicio, int anioFin)
    {
        var lista = await _context.SpDirUsuarios
            .FromSqlRaw("spDirUsuariosPorAnioCreacion {0}, {1}", anioInicio, anioFin)
            .ToListAsync();

        return Ok(lista);
    }








}//fin class Tarea03Controller
