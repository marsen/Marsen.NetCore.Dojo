﻿using System;

namespace Marsen.NetCore.Dojo.Kata_PickupService
{
    public class ShippingOrderUpdateEntity
    {
        /// <summary>
        /// OuterCode
        /// </summary>
        public string OuterCode { get; set; }

        /// <summary>
        /// Gets or sets the accept time.
        /// </summary>
        /// <value>
        /// The accept time.
        /// </value>
        public DateTime AcceptTime { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public StatusEnum? Status { get; set; }
    }
}