using JSJournal.Data;
using JSJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSJournal.Services
{
    public class InterviewService
    {
        private readonly Guid _userId;

        public InterviewService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreateInterview(InterviewCreate model)
        {
            var entity =
                new Interview()
                {
                    OwnerID = _userId,
                    LeadID = model.LeadID,
                    PrimaryInterviewer = model.PrimaryInterviewer,
                    SecondaryInterviewer = model.SecondaryInterviewer,
                    InterviewTimeDateUtc = model.InterviewTimeDateUtc,
                    InterviewerLink = model.InterviewerLink,
                    Notes = model.Notes
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Interviews.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<InterviewListItem> GetInterview()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Interviews
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new InterviewListItem
                                {
                                    InterviewID = e.InterviewID,
                                    LeadID = e.LeadID,
                                    PrimaryInterviewer = e.PrimaryInterviewer,
                                    SecondaryInterviewer = e.SecondaryInterviewer,
                                    InterviewTimeDateUtc = e.InterviewTimeDateUtc,
                                    InterviewerLink = e.InterviewerLink,
                                    Notes = e.Notes
                                }
                        );

                return query.ToArray();
            }
        }
        public InterviewEdit GetInterviewById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Interviews
                        .Single(e => e.InterviewID == id && e.OwnerID == _userId);
                return
                    new InterviewEdit
                    {
                        InterviewID = id,
                        LeadID = entity.LeadID,
                        PrimaryInterviewer = entity.PrimaryInterviewer,
                        SecondaryInterviewer = entity.SecondaryInterviewer,
                        InterviewTimeDateUtc = entity.InterviewTimeDateUtc,
                        InterviewerLink = entity.InterviewerLink,
                        Notes = entity.Notes
                    };
            }
        }

        public bool DeleteInterview(int InterviewId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Interviews
                        .Single(e => e.InterviewID == InterviewId && e.OwnerID == _userId);

                ctx.Interviews.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateInterview(InterviewEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Interviews
                        .Single(e => e.InterviewID == model.InterviewID && e.OwnerID == _userId);

                model.PrimaryInterviewer = entity.PrimaryInterviewer;
                model.SecondaryInterviewer = entity.SecondaryInterviewer;
                model.InterviewTimeDateUtc = entity.InterviewTimeDateUtc;
                model.InterviewerLink = entity.InterviewerLink;
                model.Notes = entity.Notes;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
