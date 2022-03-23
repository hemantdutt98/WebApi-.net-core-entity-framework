using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApi.Dtos
{
    public class ProjectReleaseDto
    {
        public object ProjectName { get; set; }
        public List<object> IssueDetails { get; set; }
        public List<object> Summary { get; set; }
        public object ReleaseVersion { get; set; }
        public object ReleaseDate { get; set; }
        public object ReleaseDescription { get; set; }
    }
}
