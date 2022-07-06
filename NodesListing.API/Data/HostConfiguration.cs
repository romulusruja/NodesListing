namespace NodesListing.API.Data;

public class HostConfiguration
{
    public int Id { get; set; }

    public string? Hostname { get; set; }

    public string? OnionServicePort { get; set; }

    public string? DirectoryServicePort { get; set; }

    public Node? Node { get; set; }
}
