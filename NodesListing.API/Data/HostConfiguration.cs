namespace NodesListing.API.Data;

public class HostConfiguration
{
    public int Id { get; set; }

    public string? Hostname { get; set; }

    public int? OnionServicePort { get; set; }

    public int? DirectoryServicePort { get; set; }

    public Node? Node { get; set; }
}
