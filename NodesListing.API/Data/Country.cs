using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NodesListing.API.Data;

public class Country
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string Code { get; set; }

    [Required]
    public string Name { get; set; }

    public virtual IList<Node>? Nodes { get; set; }
}
