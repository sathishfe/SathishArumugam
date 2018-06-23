using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPITestProject.Models;
using WebAPITestProject.Services;

namespace WebAPITestProject.Controllers
{
    [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
    public class SampleWebApiController : ApiController
    {
        CommonService service = new CommonService();


        // GET list of all candidates>
        [Route("GetAllCandidates")]
        public IEnumerable<InterviewCandidate> Get()
        {
            IList<InterviewCandidate> allCandidates = service.GetAllCandidates();
            return allCandidates;
        }

        // GET candidate by id
        public InterviewCandidate Get(string id)
        {
            IList<InterviewCandidate> allCandidates = service.GetAllCandidates();
            InterviewCandidate candidate = allCandidates.Where(c => c.Id == id).FirstOrDefault();
            return candidate;
        }

        // Add new candidate 
        public void Post([FromBody]InterviewCandidate candidate)
        {
            // call the service method to save the values.

            //sample logic 
            IList<InterviewCandidate> allCandidates = service.GetAllCandidates();
            allCandidates.Add(candidate);

            // call the service method to save the values.
            service.SaveChanges(allCandidates);
        }

        // update existing candidate 
        public void Put(InterviewCandidate candidate)
        {
            //sample logic 
            IList<InterviewCandidate> allCandidates = service.GetAllCandidates();
            InterviewCandidate oldCandidateData = allCandidates.Where(c => c.Id == candidate.Id).FirstOrDefault();
            allCandidates.Remove(oldCandidateData);
            allCandidates.Add(candidate);

            // call the service method to update the values.
            service.SaveChanges(allCandidates);
        }

        // delete the candidate 
        public void Delete(string id)
        {
            IList<InterviewCandidate> allCandidates = service.GetAllCandidates();
            InterviewCandidate candidate = allCandidates.Where(c => c.Id == id).FirstOrDefault();
            allCandidates.Remove(candidate);

            // call the service method to delete the values.
            service.SaveChanges(allCandidates);
        }
    }
}