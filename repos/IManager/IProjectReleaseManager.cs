using StudentApi.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IManager
{
    public interface IProjectReleaseManager
    {
        public Task<ProjectReleaseDto> GetReleaseInfo();
    }
}
