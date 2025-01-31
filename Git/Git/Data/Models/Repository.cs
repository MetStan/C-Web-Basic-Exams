﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Git.Data.DataConstants;

namespace Git.Data.Models
{
    public class Repository
    {
        public Repository()
        {
            this.Commits = new HashSet<Commit>();
        }

        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(RepositoryNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public DateTime CreatedOn { get; init; } = DateTime.UtcNow;

        [Required]
        public bool IsPublic { get; set; }

        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; }
        public User Owner { get; set; }

        public ICollection<Commit> Commits { get; set; }
    }
}
