using Atlassian.Jira;
using Atlassian.Jira.Linq;
using IManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using StudentApi.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StudentApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JiraController : ControllerBase
    {
        private readonly IProjectReleaseManager _projectReleaseManager;
        public JiraController(IProjectReleaseManager projectReleaseManager)
        {
            _projectReleaseManager = projectReleaseManager;
        }

        [HttpGet]
        public async  Task<ProjectReleaseDto> GetIssues()
        {
           return await _projectReleaseManager.GetReleaseInfo();
        }

    }

   
}
