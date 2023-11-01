﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ButterfliesShop.Validators;

namespace ButterfliesShop.Models
{
    public class Butterfly
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the butterfly name")]
        [Display(Name = "Common Name:")]
        public string CommonName { get; set; }

        [Required(ErrorMessage = "Please select the butterfly family")]
        [Display(Name = "Butterfly Family:")]
        public Family? ButterflyFamily { get; set; }

        [Required(ErrorMessage = "Please select the butterfly quantity")]
        [Display(Name = "Butterflies Quantity:")]
        [MaxButterflyQuantityValidation(50)]
        public int? Quantity { get; set; }

        [Required(ErrorMessage = "Please type the characteristics")]
        [MaxLength(50)]
        [Display(Name = "Characteristics:")]
        public string Characteristics { get; set; }

        [Display(Name = "Updated on:")]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "Please select the butterflies picture")]
        [Display(Name = "Butterflies Picture:")]
        public IFormFile PhotoAvatar { get; set; }
        public string ImageName { get; set; }
        public byte[] PhotoFile { get; set; }
        public string ImageMimeType { get; set; }

    }
}
