using IManager;
using IRepository;
using StudentApi.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class ProjectReleaseManager : IProjectReleaseManager
    {
        private readonly IProjectReleaseRepository _projectReleasecontext;

        public ProjectReleaseManager(IProjectReleaseRepository projectReleaseRepository)
        {
            _projectReleasecontext = projectReleaseRepository;
        }
        public async Task<ProjectReleaseDto> GetReleaseInfo()
        {
            return await _projectReleasecontext.GetReleaseInfoAsync();
        }
    }
}
