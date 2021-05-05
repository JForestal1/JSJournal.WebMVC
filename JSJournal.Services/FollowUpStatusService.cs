using JSJournal.Data;
using JSJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSJournal.Services
{
    public class FollowUpStatusService
    {
        private readonly Guid _userId;

        public FollowUpStatusService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreateFollowUpStatus(FollowUpStatusCreate model)
        {
            var entity =
                new FollowUpStatusType()
                {
                    OwnerId = _userId,
                    Status = model.Status,
                    Description = model.Description,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.FollowUpStatusTypes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FollowUpStatusListItem> GetFollowUpStatus()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .FollowUpStatusTypes
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new FollowUpStatusListItem
                                {
                                    FollowUpStatusTypeID = e.FollowUpStatusTypeID,
                                    Status = e.Status,
                                    Description = e.Description
                                }
                        );

                return query.ToArray();
            }
        }
        public FollowUpStatusEdit GetFollowUpStatusById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .FollowUpStatusTypes
                        .Single(e => e.FollowUpStatusTypeID == id && e.OwnerId == _userId);
                return
                    new FollowUpStatusEdit
                    {
                        FollowUpStatusTypeID = id,
                        Status = entity.Status,
                        Description = entity.Description
                    };
            }
        }

        public bool DeleteFollowUpStatusType(int FollowUpStatusTypeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .FollowUpStatusTypes
                        .Single(e => e.FollowUpStatusTypeID == FollowUpStatusTypeId && e.OwnerId == _userId);

                ctx.FollowUpStatusTypes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateFollowUpStatus(FollowUpStatusEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .FollowUpStatusTypes
                        .Single(e => e.FollowUpStatusTypeID == model.FollowUpStatusTypeID && e.OwnerId == _userId);

                entity.Status = model.Status;
                entity.Description = model.Description;
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
