using System.Collections.Generic;

namespace Sorschia.TechSupport.Entities
{
    public class Trouble : TroubleBase
    {
        public IEnumerable<ResponseGroup> ResponseGroups { get; set; }
        public IEnumerable<Respondent> Respondents { get; set; }
    }
}
