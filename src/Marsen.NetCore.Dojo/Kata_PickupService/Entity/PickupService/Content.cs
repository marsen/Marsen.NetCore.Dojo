using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Marsen.NetCore.Dojo.Kata_PickupService.Entity.PickupService
{
    public class Content
    {
        public string merchantId { get; set; }
        public string merchantRef { get; set; }
        public string waybillNo { get; set; }
        public string locationId { get; set; }
        public string pudoRef { get; set; }
        public string pudoVerifyCode { get; set; }
        public string senderId { get; set; }
        public string consigneeId { get; set; }
        public string customerName { get; set; }
        public string customerAddress1 { get; set; }
        public string customerAddress2 { get; set; }
        public string customerAddress3 { get; set; }
        public string customerAddress4 { get; set; }
        public string feedbackURL { get; set; }
        public string eta { get; set; }
        public string codAmt { get; set; }
        public string sizeCode { get; set; }
        public List<Item> item { get; set; }

        [JsonPropertyName("lastStatusId")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Status Status { get; set; }

        public string lastStatusDescription { get; set; }
        public string lastStatusDate { get; set; }
        public string lastStatusTime { get; set; }
        public string customerMobile { get; set; }
        public string customerEmail { get; set; }
    }
}