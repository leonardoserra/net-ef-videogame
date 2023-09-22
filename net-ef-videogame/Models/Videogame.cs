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
    [Table("videogames")]
    public class Videogame
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DefaultValue("")]
        public string Overview { get; set; }
        [Required]
        public DateTime ReleaseDate{ get; set; }
        
        public long? SoftwarehouseId{ get; set; }
        public SoftwareHouse SoftwareHouse { get; set; }

       

        public override string ToString()
        {
            return $"ID: {Id},\r\nName: {Name}";
        }
    }
}
