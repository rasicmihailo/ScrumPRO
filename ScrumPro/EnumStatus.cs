using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScrumPRO
{
    public class EnumStatus
    {
        public enum IssueStatus
        {
            InProgress = 1,//This issue is being actively worked on at the moment by the assignee.
            Done = 2,//Work has finished on the issue.
            Cancelled = 3,//Work has stopped on the issue and the issue is considered done.
            Accepted = 4, //For recruitment projects, this indicates that the candidate has accepted the position. The issue is considered done.
            Published = 5,//For content management projects, the work described on the issue has been published and/or released for internal consumption. The issue is considered done.
            Open = 6, //The issue is open and ready for the assignee to start work on it.
            Requested = 7, //For procurement projects, this indicates that the service or item has been requested and is waiting for a procurement team member to action the request.
            Purchased = 8, //For procurement projects, this indicates that the service or item was purchased. The issue is considered done.
            InNegotiation = 9, //For lead tracking projects, this indicates that the sales team is adjusting their terms to make a sale.
            Opportunity = 10, //For lead tracking projects, this indicates that the sales team has identified and opportunity they want to pursue.
            Contacted = 11, //For lead tracking projects, this indicates that the sales representative has contacted their lead and the pitch is in progress.
            ToDo = 12, //The issue has been reported and is waiting for the team to action it.
            InReview = 13, //The assignee has carried out the work needed on the issue, and it needs peer review before being considered done.
            UnderReview = 14,//A reviewer is currently assessing the work completed on the issue before considering it done.
            Approved = 15, //A reviewer has approved the work completed on the issue and the issue is considered done.
            Rejected = 16, //A reviewer has rejected the work completed on the issue and the issue is considered done.
            Draft = 17, //For content management and document approval projects, the work described on the issue is being prepared for review and is considered in progress, in the draft stage of writing.
            Interviewing = 18, //For recruitment projects, this indicates that the candidate is currently in the interviewing stage of the hiring process.
            InterviewDebrief = 20, //For recruitment projects, this indicates that the candidate has completed interviewing and interviewers are discussing their next steps in the hiring process.
            Screening = 21, //For recruitment projects, this indicates that the candidate has applied and is being considered for interviews.
            OfferDiscussions = 22, //For recruitment projects, this indicates that the candidate has been offered a position and recruiters are working to shore up the details.
            Applications = 23, //For recruitment projects, this indicates that a candidate has applied and recruiters are waiting to screen them for future action in the hiring process.
            SecondReview = 24, //For document approval projects, the work described on the issue has passed its initial review and is being closely proofed for publication.
            Lost = 25, //For lead tracking projects, this indicates that the lead was unsuccessful. The issue is considered done.
            Won = 26 //For lead tracking projects, this indicates that the lead was successful. The issue is considered done.
        }

        public enum Priorities
        {
            Highest = 1,
            High = 2,
            Medium = 3,
            Low = 4, 
            Lowest = 5
        }

        public enum SoftwareStatus
        {
            Reopened = 1, //This issue was once resolved, but the resolution was deemed incorrect. From here, issues are either marked assigned or resolved.
            Resolved = 2, //A resolution has been taken, and it is awaiting verification by reporter. From here, issues are either reopened, or are closed.
            Closed = 3, //The issue is considered finished. The resolution is correct. Issues which are closed can be reopened.
            Building = 4, //Source code has been committed, and ScrumPRO is waiting for the code to be built before moving to the next status.
            BuildBroken = 5,//The source code committed for this issue has possibly broken the build.
            Backlog = 6, //The issue is waiting to be picked up in a future sprint.
            SelectedForDevelopment = 7 //The issue is verified and has been selected to be worked on in the future.
        }

    }
}