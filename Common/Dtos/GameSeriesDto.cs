﻿namespace ASPApp.Common.Dtos
{
    public class GameSeriesDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
