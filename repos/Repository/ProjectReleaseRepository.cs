using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IRepository;
using Newtonsoft.Json.Linq;
using StudentApi.Dtos;

namespace Repository
{
    public class ProjectReleaseRepository : IProjectReleaseRepository
    {
        private List<object> issueList = new List<object>();
        private List<object> issueSummary = new List<object>();
        private readonly IMapper _mapper;
        private int totalResults;

        public ProjectReleaseRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ProjectReleaseDto> GetReleaseInfoAsync()
        {
            string projectName = "dummy";
            string URL = $"https://dummyhemant.atlassian.net/rest/api/2/search?jql=fixVersion in releasedVersions({projectName}) AND fixVersion=v1";

            HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(URL);
            httpWReq.Method = "Get";
            httpWReq.PreAuthenticate = true;
            httpWReq.Headers.Add("Authorization", "Basic " + getAuthorization());

            HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseString = reader.ReadToEnd();
            var responseJson = JObject.Parse(responseString);

            return await MapProjectReleaseDto(responseJson["issues"]);
        } 

        public string getAuthorization()
        {
            var userName = "hemantdutt98@gmail.com";
            var password = "TDWQX0ejs7ASe8AK0txu8E0D";
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(userName + ":" + password));
        }

        public async Task<ProjectReleaseDto> MapProjectReleaseDto(JToken issues) 
        {
            foreach (var issue in issues)
            {
                issueList.Add(issue["fields"]["description"]);
                issueSummary.Add(issue["fields"]["summary"]);
            }

            var finalResult = new ProjectReleaseDto()
            {
                ProjectName = issues[0]["fields"]["project"]["name"],
                ReleaseVersion = issues[0]["fields"]["fixVersions"][0]["name"],
                ReleaseDate = issues[0]["fields"]["fixVersions"][0]["releaseDate"],
                ReleaseDescription = issues[0]["fields"]["fixVersions"][0]["description"],
                IssueDetails = issueList,
                Summary = issueSummary

            };

            return (finalResult);
        }
    }
}
