﻿namespace Git.ViewModels.Repositories
{
    public class RepositoryViewModel
    {
       
        public string Id { get; init; } 

        public string Name { get; set; }

        public string CreatedOn { get; init; }

        public string Owner { get; init; }

        public int Commits { get; init; }
    }
}
