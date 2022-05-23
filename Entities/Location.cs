using Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Location : IEntity
    {
        [Key]
        public int Id { get; set; }
        [JsonProperty("lat")]
        public string Lat { get; set; }
        [JsonProperty("long")]
        public string Long { get; set; }
        public virtual List<WareHouse> WareHouses { get; set; }
    }
}
