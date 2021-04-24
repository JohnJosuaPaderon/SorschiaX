using System.Collections.Generic;
using SystemBase.Entities;

namespace Sorschia.TechSupport.Entities
{
    public class Respondent : RespondentBase, IFullNameHolder
    {
        public IEnumerable<ResponseGroupRespondent> ResponseGroupRespondents { get; set; }
    }
}
