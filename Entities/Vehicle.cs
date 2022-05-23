using Core.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Vehicle : IEntity
    {
        [JsonProperty("_id")]
        [Key]
        public int Id { get; set; }
        public int CarsId { get; set; }
        [JsonProperty("make")]
        public string Make { get; set; }
        [JsonProperty("model")]
        public string Model { get; set; }
        [JsonProperty("year_model")]
        public int YearModel { get; set; }
        [JsonProperty("price")]
        public float Price { get; set; }
        [JsonProperty("licensed")]
        public bool Licensed { get; set; }
        [JsonProperty("date_added")]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime DateAdded { get; set; }
        public virtual Cars Cars { get; set; }
        public virtual List<CartItem> CartItems { get; set; }
    }

    public class DateFormatConverter : IsoDateTimeConverter
    {
        public DateFormatConverter(string format)
        {
            DateTimeFormat = format;
        }
    }
}
