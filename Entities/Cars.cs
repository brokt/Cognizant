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
    public class Cars : IEntity
    {
        [Key]
        public int Id { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("vehicles")]
        public List<Vehicle> Vehicles { get; set; }
        public List<WareHouse> WareHouse { get; set; }
    }
}
