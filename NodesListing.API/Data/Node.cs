using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NodesListing.API.Data;

public class Node
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string Address { get; set; }

    [Required]
    public string PublicKey { get; set; }

    [ForeignKey(nameof(CountryCode))]
    public string CountryCode { get; set; }

    public Country? Country { get; set; }

    [ForeignKey(nameof(HostConfigurationId))]
    public int HostConfigurationId { get; set; }

    public HostConfiguration? HostConfiguration { get; set; }
}
