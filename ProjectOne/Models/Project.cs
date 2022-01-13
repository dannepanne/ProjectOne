using System;
using System.Collections.Generic;

namespace ProjectOne.Models
{
    public partial class Project
    {
        public Project()
        {
            ProjectTasks = new HashSet<ProjectTask>();
        }

        public long Id { get; set; }
        public string? Description { get; set; }
        public string? Customer { get; set; }
        public string? Status { get; set; }
        public string? Active { get; set; }
        public DateTime? DueDate { get; set; }

        public virtual ICollection<ProjectTask> ProjectTasks { get; set; }
    }
}
