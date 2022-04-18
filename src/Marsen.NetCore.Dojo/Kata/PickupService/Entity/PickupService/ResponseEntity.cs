using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Marsen.NetCore.Dojo.Kata.PickupService.Entity.PickupService;

public class ResponseEntity
{
    [JsonPropertyName("result")] public string Result { get; set; }

    [JsonPropertyName("content")] public List<Content> Content { get; set; }
}