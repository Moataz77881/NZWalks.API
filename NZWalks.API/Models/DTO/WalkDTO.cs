﻿namespace NZWalks.API.Models.DTO
{
    public class WalkDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LenghtInKm { get; set; }
        public string? WalkImageUrl { get; set; } // can be null
        public RegionDTO Region { get; set; }
        public DifficultyDTO Difficulty { get; set; }
    }
}