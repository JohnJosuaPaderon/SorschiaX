using Sorschia.Entities;
using System.Collections.Generic;

namespace Sorschia.TechSupport.Entities
{
    public class Respondent : RespondentBase, IFullNameHolder
    {
        public IEnumerable<ResponseGroupRespondent> ResponseGroupRespondents { get; set; }
    }
}
