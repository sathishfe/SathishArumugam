using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPITestProject.Models
{

    public class InterviewCandidate
    {
        public string Id { get; set; }
        public int ApplicationId { get; set; }
        public string Type { get; set; }
        public string Summary { get; set; }
        public double Amount { get; set; }
        public DateTime? PostingDate { get; set; }
        public bool IsCleared { get; set; }
        public DateTime? ClearedDate { get; set; }

    }

    public class InterviewCandidates
    {
        public IList<InterviewCandidate> CandidateList { get; set; }
    }
}