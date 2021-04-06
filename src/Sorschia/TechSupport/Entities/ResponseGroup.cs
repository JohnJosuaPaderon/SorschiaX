using System.Collections.Generic;

namespace Sorschia.TechSupport.Entities
{
    public class ResponseGroup : ResponseGroupBase
    {
        public IEnumerable<ResponseGroupRespondent> ResponseGroupRespondents { get; set; }
    }
}
