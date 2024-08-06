﻿using System.ComponentModel.DataAnnotations;

namespace Dal;
public class VideoEntity
{
    [Required]public Guid Id { get; set; }
    [Required]public string Name { get; set; }
    public string Description { get; set; }
    [Required]public TimeSpan Duration { get; set; }

}
