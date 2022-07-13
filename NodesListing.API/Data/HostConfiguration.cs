﻿using System.ComponentModel.DataAnnotations;

namespace NodesListing.API.Data;

public class HostConfiguration
{
    public int Id { get; set; }

    [Required]
    public string Hostname { get; set; }

    [Required]
    public int OnionServicePort { get; set; }

    [Required]
    public int DirectoryServicePort { get; set; }

    public Node? Node { get; set; }
}
