using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.Entidades;

[Table("Pais")]
public class Pais
{
    [Key]
    [Column("PaisId")]
    public int Id { get; set; }

    [Column(TypeName = "nvarchar(150)")]
    public string Nombre { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }


    public List<Ciudad> Ciudades { get; set; } = new();
}
