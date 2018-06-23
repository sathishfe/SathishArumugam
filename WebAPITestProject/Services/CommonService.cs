using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using WebAPITestProject.Models;
using Newtonsoft.Json.Linq;

namespace WebAPITestProject.Services
{
    public class CommonService
    {
        private const string fileName = @"C:\Users\test\Documents\Visual Studio 2015\Projects\SathishArumugam\WebAPITestProject\WebAPITestProject\Services\SampleData.json";
        private string GetJsonStringFromFile()
        {
            string jsonString = File.ReadAllText(fileName);
            return jsonString;
            
        }
        private InterviewCandidates GetCandidateObjects()
        {
            string jsonString = GetJsonStringFromFile();
            InterviewCandidates candidates = Newtonsoft.Json.JsonConvert.DeserializeObject<InterviewCandidates>(jsonString);
            return candidates;
        }
        public void SaveChanges(IList<InterviewCandidate> candidatesList)
        {
            string jsonString = string.Empty;
            InterviewCandidates candidates  = new InterviewCandidates();
            candidates.CandidateList = candidatesList;
            jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(candidates);
            File.WriteAllText(fileName, jsonString);
        }


        //Get all candidates list
        public IList<InterviewCandidate> GetAllCandidates()
        {
            InterviewCandidates candidates = GetCandidateObjects();
            IList<InterviewCandidate> candidate = candidates.CandidateList;
            return candidate; 
        }
        
    }
}