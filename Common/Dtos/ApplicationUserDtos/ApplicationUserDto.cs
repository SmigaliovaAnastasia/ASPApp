﻿using System.ComponentModel.DataAnnotations;

namespace ASPApp.Common.Dtos.ApplicationUserDtos
{
    public class ApplicationUserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
    }
}
