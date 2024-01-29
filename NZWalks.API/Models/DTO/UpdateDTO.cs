﻿using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    public class UpdateDTO
    {
        [Required]
        [MinLength(3,ErrorMessage ="code has to be minimum 3 characters")]
        [MaxLength(3, ErrorMessage = "code has to be minimum 3 characters")]
        public string Code { get; set; }
        [Required]
        [MaxLength(100 , ErrorMessage ="name has to be maximum 100 characters")]
        public string Name { get; set; }
        public string RegionImageUrl { get; set; }
    }
}
