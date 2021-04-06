namespace Sorschia.TechSupport.Entities
{
    public class ResponseGroupRespondent : ResponseGroupRespondentBase
    {
        public ResponseGroup ResponseGroup { get; set; }
        public Respondent Respondent { get; set; }
    }
}
