using JSJournal.Data;
using JSJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSJournal.Services
{
    public class ArtifactService
    {
        private readonly Guid _userId;

        public ArtifactService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreateArtifact(ArtifactCreate model)
        {
            var entity =
                new Artifact()
                {
                    OwnerId = _userId,
                    ArtifactType = model.ArtifactType,
                    ShortLabel = model.ShortLabel,
                    Description = model.Description,
                    Link = model.Link,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Artifacts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ArtifactListItem> GetArtifact()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Artifacts
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ArtifactListItem
                                {
                                    ArtifactID = e.ArtifactID,
                                    ArtifactType = e.ArtifactType,
                                    ShortLabel = e.ShortLabel,
                                    Description = e.Description,
                                    Link = e.Link,
                                    CreatedUtc = e.CreatedUtc,
                                    ModifiedUtc = e.ModifiedUtc
                                }
                        );

                return query.ToArray();
            }
        }
        public ArtifactEdit GetArtifactById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Artifacts
                        .Single(e => e.ArtifactID == id && e.OwnerId == _userId);
                return
                    new ArtifactEdit
                    {
                        ArtifactID = id,
                        ArtifactType = entity.ArtifactType,
                        ShortLabel = entity.ShortLabel,
                        Description = entity.Description,
                        Link = entity.Link,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool DeleteArtifact(int ArtifactId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Artifacts
                        .Single(e => e.ArtifactID == ArtifactId && e.OwnerId == _userId);

                ctx.Artifacts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateArtifact(ArtifactEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Artifacts
                        .Single(e => e.ArtifactID == model.ArtifactID && e.OwnerId == _userId);

                entity.ArtifactType = model.ArtifactType;
                entity.ShortLabel = model.ShortLabel;
                entity.Description = model.Description;
                entity.Link = model.Link;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
