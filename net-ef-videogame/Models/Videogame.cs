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
using System.Xml.Linq;

namespace net_ef_videogame.Models

{
    [Table("videogames")]
    public class Videogame
    {
        [Key,Column("id")]
        public long Id { get; set; }


        [Required,Column("name")]
        public string? Name { get; set; }


        [DefaultValue(""), Column("overwiev")]
        public string? Overview { get; set; }


        [Required, Column("release_date")]
        public DateTime ReleaseDate{ get; set; }


        [Column("software_house_id")]
        public long? SoftwareHouseId{ get; set; }


        [Column("software_house")]
        public SoftwareHouse? SoftwareHouse { get; set; }

       

        public override string ToString()
        {
            return $"ID: {Id},\r\nName: {Name}";
        }
    }
}
