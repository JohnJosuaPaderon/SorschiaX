namespace Sorschia.TechSupport.Entities
{
    public class ResponseGroupManager : ResponseGroupManagerBase
    {
        public ResponseGroup ResponseGroup { get; set; }
        public Respondent Manager { get; set; }
    }
}
