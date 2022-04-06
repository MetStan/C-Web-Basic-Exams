using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Git.Data.DataConstants;

namespace Git.Data.Models
{
    public class Commit
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(CommitDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedOn { get; init; } = DateTime.UtcNow;

        [ForeignKey(nameof(Creator))]
        public string CreatorId { get; set; }
        public User Creator { get; set; }


        [ForeignKey(nameof(Repository))]
        public string RepositoryId { get; set; }
        public Repository Repository { get; set; }
    }
}
