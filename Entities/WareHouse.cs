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
    public class WareHouse : IEntity
    {
        [JsonProperty("_id")]
        [Key]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        public int LocationId { get; set; }
        public int CarsId { get; set; }
        [JsonProperty("location")]
        public virtual Location Location { get; set; }
        [JsonProperty("cars")]
        public virtual Cars Cars { get; set; }
    }
}
