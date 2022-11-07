﻿using ASPApp.Domain.Entities.Auth;
using ASPApp.Domain.Entities;

namespace ASPApp.Common.Dtos.CollectionDtos
{
    public class CollectionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImgImageUrl { get; set; }
        public Guid ApplicationUserId { get; set; }
        public ICollection<Guid> CollectionGameIds { get; set; }
    }
}