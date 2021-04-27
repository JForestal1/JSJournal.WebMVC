using JSJournal.Data;
using JSJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSJournal.Services
{
    public class LeadStatusService
    {
        private readonly Guid _userId;

        public LeadStatusService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreateStatus(LeadStatusCreate model)
        {
            var entity =
                new StatusType()
                {
                    OwnerId = _userId,
                    Status = model.Status,
                    Description = model.Description,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.StatusTypes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LeadStatusListItem> GetLeadStatus()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .StatusTypes
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new LeadStatusListItem
                                {
                                    StatusTypeID = e.StatusTypeID,
                                    Status = e.Status,
                                    Description = e.Description
                                }
                        );

                return query.ToArray();
            }
        }
        public LeadStatusEdit GetLeadStatusById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .StatusTypes
                        .Single(e => e.StatusTypeID == id && e.OwnerId == _userId);
                return
                    new LeadStatusEdit
                    {
                        StatusTypeID = id,
                        Status = entity.Status,
                        Description = entity.Description
                    };
            }
        }

        public bool DeleteStatusType(int StatusTypeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .StatusTypes
                        .Single(e => e.StatusTypeID == StatusTypeId && e.OwnerId == _userId);

                ctx.StatusTypes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateLeadStatus(LeadStatusEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .StatusTypes
                        .Single(e => e.StatusTypeID == model.StatusTypeID && e.OwnerId == _userId);

                entity.Status = model.Status;
                entity.Description = model.Description;
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
