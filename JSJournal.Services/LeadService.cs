using JSJournal.Data;
using JSJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSJournal.Services
{
    public class LeadService
    {
        private readonly Guid _userId;

        public LeadService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreateLead(LeadCreate model)
        {
            var entity =
                new Lead()
                {
                    OwnerID = _userId,
                    Company = model.Company,
                    Role = model.Role,
                    StatusID = model.StatusID,
                    SourceID = model.SourceID,
                    JobDescriptionLink = model.JobDescriptionLink,
                    ResumeID = model.ResumeID,
                    CoverID = model.CoverID,
                    OtherArtifactID = model.OtherArtifactUsedID,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Leads.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LeadListItem> GetLead()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Leads
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new LeadListItem
                                {
                                    LeadID = e.LeadID,
                                    Company = e.Company,
                                    Role = e.Role,
                                    Status = e.Status.Status,
                                    Source = e.Source.Source,
                                    JobDescriptionLink = e.JobDescriptionLink,
                                    FollowUpCount = e.FollowUps.Count(),
                                    InterviewCount = e.Interviews.Count(),
                                    ResumeUsed = e.ResumeUsed.ShortLabel,
                                    CoverUsed = e.CoverUsed.ShortLabel,
                                    OtherArtifactUsed = e.OtherArtifactUsed.ShortLabel,
                                    CreatedUtc = e.CreatedUtc,
                                    ModifiedUtc = e.ModifiedUtc
                                }
                        );

                return query.ToArray();
            }
        }
        public LeadEdit GetLeadById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Leads
                        .Single(e => e.LeadID == id && e.OwnerID == _userId);
                return
                    new LeadEdit
                    {
                        LeadID = id,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc,
                        Company = entity.Company,
                        Role = entity.Role,
                        FollowUpCount = entity.FollowUps.Count(),
                        InterviewCount = entity.Interviews.Count(),
                        SourceID = entity.SourceID,
                        StatusID = entity.StatusID,
                        JobDescriptionLink = entity.JobDescriptionLink,
                        ResumeID = entity.ResumeID,
                        CoverID = entity.CoverID,
                        OtherArtifactID = entity.OtherArtifactID
                    };
            }
        }

        public bool DeleteLead(int LeadId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Leads
                        .Single(e => e.LeadID == LeadId && e.OwnerID == _userId);

                ctx.Leads.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateLead(LeadEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Leads
                        .Single(e => e.LeadID == model.LeadID && e.OwnerID == _userId);

                entity.Company = model.Company;
                entity.Role = model.Role;
                entity.SourceID = model.SourceID;
                entity.StatusID = model.StatusID;
                entity.JobDescriptionLink = model.JobDescriptionLink;
                entity.ResumeID = model.ResumeID;
                entity.CoverID = model.CoverID;
                entity.OtherArtifactID = model.OtherArtifactID;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
