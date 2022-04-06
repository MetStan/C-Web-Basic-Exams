using System.Collections.Generic;

namespace Git.Services.Contracts
{
    public interface IValidatorService
    {
        ICollection<string> ValidateModel(object model);
    }
}
