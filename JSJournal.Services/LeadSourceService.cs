using JSJournal.Data;
using JSJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSJournal.Services
{
    public class LeadSourceService
    {
        private readonly Guid _userId;

        public LeadSourceService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreateSource(LeadSourceCreate model)
        {
            var entity =
                new SourceType()
                {
                    OwnerId = _userId,
                    Source = model.Source,
                    Description = model.Description,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.SourceTypes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LeadSourceListItem> GetLeadSource()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .SourceTypes
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new LeadSourceListItem
                                {
                                    SourceTypeID = e.SourceTypeID,
                                    Source = e.Source,
                                    Description = e.Description
                                }
                        );

                return query.ToArray();
            }
        }
        public LeadSourceEdit GetLeadSourceById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .SourceTypes
                        .Single(e => e.SourceTypeID == id && e.OwnerId == _userId);
                return
                    new LeadSourceEdit
                    {
                        SourceTypeID = id,
                        Source = entity.Source,
                        Description = entity.Description
                    };
            }
        }

        public bool DeleteSourceType(int SourceTypeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .SourceTypes
                        .Single(e => e.SourceTypeID == SourceTypeId && e.OwnerId == _userId);

                ctx.SourceTypes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateLeadSource(LeadSourceEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .SourceTypes
                        .Single(e => e.SourceTypeID == model.SourceTypeID && e.OwnerId == _userId);

                entity.Source = model.Source;
                entity.Description = model.Description;
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
