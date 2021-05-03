﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace visitor_management_api.Models
{
    public class Visit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ArrivalTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime DepartureTime { get; set; }

        [Required]
        [ForeignKey("Visitor")]
        public int VisitorId { get; set; }

        [Required]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
    }
}