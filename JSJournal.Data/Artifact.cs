using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSJournal.Data
{
    public class Artifact
    {
        public enum ArtifactTypes
        {
            CoverLetter,
            Resume,
            WorkExample,
            Portfolio,
            ReferralLetter,
            Other
        }

        [Key]
        public int ArtifactID { get; set; }

        public ArtifactTypes ArtifactType { get; set; }

        public string ShortLabel { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }
    }
}
