﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace BookStore.Domain.Models;

public partial class Order : Entity<int>
{
    //public int OrderId { get; set; }

    public string CustomerId { get; set; }

    public int? EmployeeId { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? RequiredDate { get; set; }

    public DateTime? ShippedDate { get; set; }

    public int? ShipVia { get; set; }

    public double? Freight { get; set; }

    public string ShipName { get; set; }

    public string ShipAddress { get; set; }

    public string ShipCity { get; set; }

    public string ShipRegion { get; set; }

    public string ShipPostalCode { get; set; }

    public string ShipCountry { get; set; }

    public virtual Customer Customer { get; set; }

    public virtual Employee Employee { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Shipper ShipViaNavigation { get; set; }
}