using EAMS.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAMS.Domain.Entities;

public class Amenity : BaseEntity
{
    public string Name { get; set; }
    public AmenityType AmenityType { get; set; }
    public string HelpText { get; set; }
    public List<AmenityOptions> AmenityOptions { get; set; }
}

public class AmenityOptions : BaseEntity
{
    public string Name { get; set; }
    public string DisplayText { get; set; }
    public string Icon { get; set; }
    public string Color { get; set; }
}
