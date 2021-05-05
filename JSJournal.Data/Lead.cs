using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSJournal.Data
{
    public class Lead
    {
        [Key]
        public int LeadID { get; set; }
        public Guid OwnerID { get; set; }

        public string Role { get; set; }

        public string Company { get; set; }

        [ForeignKey("Status")]
        public int StatusID { get; set; }
        public virtual StatusType Status { get; set; }

        [ForeignKey("Source")]
        public int SourceID { get; set; }
        public virtual SourceType Source { get; set; }

        public string JobDescriptionLink { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

        virtual public List<Interview> Interviews { get; set; }

        virtual public List<FollowUp> FollowUps { get; set; }

        [ForeignKey("ResumeUsed")]
        public int? ResumeID { get; set; }
        public virtual Artifact ResumeUsed { get; set; }

        [ForeignKey("CoverUsed")]
        public int? CoverID { get; set; }

        public virtual Artifact CoverUsed { get; set; }

        [ForeignKey("OtherArtifactUsed")]
        public int? OtherArtifactID { get; set; }

        public virtual Artifact OtherArtifactUsed { get; set; }
    }
}
