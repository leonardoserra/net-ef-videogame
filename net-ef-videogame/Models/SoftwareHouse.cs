using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace net_ef_videogame.Models
{
    [Table("software_houses")]
    public class SoftwareHouse
    {
        [Key]
        [Column("software_house_id")]
        public long SoftwareHouseId { get; set; }


        [Column("name"),Required]
        public string? Name { get; set; }


        [Column("tax_id"),MaxLength(11), MinLength(11)]
        public string? TaxId {  get; set; }


        [Column("city"),MaxLength(50)]
        public string? City {  get; set; }

        [Column("country"),MaxLength(50)]
        public string? Country {  get; set; }

        [Column("videogames")]
        public List<Videogame>? Videogames { get; set; }

        public override string ToString()
        {
            return $"ID: {SoftwareHouseId} - Nome: {Name}";
        }
    }
}
