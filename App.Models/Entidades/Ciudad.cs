using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.Entidades;

[Table("Ciudad")]
public class Ciudad
{
    [Key]
    [Column("CiudadId")]
    public int Id { get; set; }

    [Column(TypeName = "nvarchar(150)")]
    public string Nombre { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }


    public int PaisId { get; set; }
    [ForeignKey("PaisId")]
    public Pais Pais { get; set; } = null!;
}
