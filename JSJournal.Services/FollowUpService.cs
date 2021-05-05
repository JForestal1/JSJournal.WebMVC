using JSJournal.Data;
using JSJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSJournal.Services
{
    public class FollowUpService
    {
        private readonly Guid _userId;

        public FollowUpService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreateFollowUp(FollowUpCreate model)
        {
            var entity =
                new FollowUp()
                {
                    OwnerId = _userId,
                    LeadID = model.LeadID,
                    ShortDescription = model.ShortDescription,
                    FollowUpStatusID = model.FollowUpStatusID,
                    Notes = model.Notes,
                    CreatedUtc = DateTimeOffset.Now,
                    DueUtc = model.DueUtc
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.FollowUps.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FollowUpListItem> GetFollowUps()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .FollowUps
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new FollowUpListItem
                                {
                                    ShortDescription = e.ShortDescription,
                                    LeadID = e.LeadID,
                                    FollowUpID = e.FollowUpID,
                                    FollowUpStatus = e.Status.Status,
                                    Notes = e.Notes,
                                    ModifiedUtc = e.ModifiedUtc,
                                    CreatedUtc = e.CreatedUtc,
                                    DueUtc = (DateTimeOffset)e.DueUtc
                                }
                        );

                return query.ToArray();
            }
        }
        public FollowUpEdit GetFollowUpById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .FollowUps
                        .Single(e => e.FollowUpID == id && e.OwnerId == _userId);
                return
                    new FollowUpEdit
                    {
                        FollowUpID = id,
                        ShortDescription = entity.ShortDescription,
                        FollowUpStatusID = entity.FollowUpStatusID,
                        Notes = entity.Notes,
                        ModifiedUtc = entity.ModifiedUtc,
                        CreatedUtc = entity.CreatedUtc,
                        DueUtc = (DateTimeOffset)entity.DueUtc
                    };
            }
        }

        public bool DeleteFollowUp(int FollowUpId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .FollowUps
                        .Single(e => e.FollowUpID == FollowUpId && e.OwnerId == _userId);

                ctx.FollowUps.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateFollowUp(FollowUpEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .FollowUps
                        .Single(e => e.FollowUpID == model.FollowUpID && e.OwnerId == _userId);

                entity.ShortDescription = entity.ShortDescription;
                entity.FollowUpStatusID = entity.FollowUpStatusID;
                entity.Notes = entity.Notes;
                entity.ModifiedUtc = entity.ModifiedUtc;
                entity.DueUtc = (DateTimeOffset)entity.DueUtc;


                return ctx.SaveChanges() == 1;
            }
        }
    }
}
