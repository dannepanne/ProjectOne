using System;
using System.Collections.Generic;

namespace ProjectOne.Models
{
    public partial class ProjectTask
    {
        public long? Resourceid { get; set; }
        public long? Projectid { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public long Id { get; set; }

        public virtual Project? Project { get; set; }
        public virtual Resource? Resource { get; set; }
    }
}
