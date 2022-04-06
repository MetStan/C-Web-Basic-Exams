using System;
using System.ComponentModel.DataAnnotations;
using static Git.Data.DataConstants;

namespace Git.ViewModels.Commits
{
    public class CommitFormViewModel
    {
        public string Id { get; init; }

        [Required]
        [StringLength(CommitDescriptionMaxLength, MinimumLength = CommitDescriptionMinLength, ErrorMessage = "{0} must be between {2} and {1} characters.")]
        public string Description { get; init; }
    }
}
