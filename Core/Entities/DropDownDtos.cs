using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class DropDownDtos
    {
        [JsonProperty("id")]
        public string Id  { get; set; }
        [JsonProperty("text")]
        public string Text  { get; set; }
    }
}
