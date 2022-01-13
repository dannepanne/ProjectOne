using System;
using System.Collections.Generic;

namespace ProjectOne.Models
{
    public partial class Resource
    {
        public Resource()
        {
            ProjectTasks = new HashSet<ProjectTask>();
        }

        public long Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? Skill { get; set; }
        public string? AdminRights { get; set; }

        public virtual ICollection<ProjectTask> ProjectTasks { get; set; }
    }
}
