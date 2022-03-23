using StudentApi.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IProjectReleaseRepository
    {
        public Task<ProjectReleaseDto> GetReleaseInfoAsync();
    }
}
