﻿using System.ComponentModel.DataAnnotations;

namespace L01_2020VA601.Models
{
    public class Motorista
    {

        [Key]
        public int motoristaId { get; set; }
        public string? nombreMotorista { get; set; }     

    }
}
