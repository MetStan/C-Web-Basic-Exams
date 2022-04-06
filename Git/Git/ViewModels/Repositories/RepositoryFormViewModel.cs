using System;
using System.ComponentModel.DataAnnotations;
using static Git.Data.DataConstants;

namespace Git.ViewModels.Repositories
{
    public class RepositoryFormViewModel
    {
        [Required]
        [StringLength(RepositoryNameMaxLength, MinimumLength = RepositoryNameMinLength, ErrorMessage = "{0} must be between {2} and {1} characters.")]
        public string Name { get; set; }

        public string RepositoryType { get; set; }
    }
}
