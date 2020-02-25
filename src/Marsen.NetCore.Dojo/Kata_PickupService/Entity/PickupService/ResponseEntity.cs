using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Marsen.NetCore.Dojo.Kata_PickupService.Entity.PickupService
{
    public class ResponseEntity
    {
        public string result { get; set; }

        [JsonPropertyName("content")]
        public List<Content> Content { get; set; }
    }
}