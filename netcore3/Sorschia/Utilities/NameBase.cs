namespace Sorschia.Utilities
{
    public abstract class NameBase
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string NameExtension { get; set; }
        public string FullName { get; private set; }

        public virtual string GetFullName(IFullNameBuilder builder)
        {
            var firstName = FirstName;
            var middleName = MiddleName;
            var lastName = LastName;
            var nameExtension = NameExtension;
            FullName = builder?.Build(firstName, middleName, lastName, nameExtension);
            return FullName;
        }
    }
}
