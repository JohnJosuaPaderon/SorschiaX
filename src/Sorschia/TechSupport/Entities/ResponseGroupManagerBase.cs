namespace Sorschia.TechSupport.Entities
{
    public abstract class ResponseGroupManagerBase
    {
        public long Id { get; set; }
        public int ResponseGroupId { get; set; }
        public int ManagerId { get; set; }
    }
}
