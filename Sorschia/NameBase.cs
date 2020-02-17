namespace Sorschia
{
    public abstract class NameBase
    {
        private static IFullNameBuilder _fullNameBuilder = new FullNameBuilder();
        public static IFullNameBuilder FullNameBuilder
        {
            get => TryGet(_fullNameBuilder, nameof(FullNameBuilder));
            set => TrySet(ref _fullNameBuilder, value, nameof(FullNameBuilder));
        }

        private static IInformalFullNameBuilder _informalFullNameBuilder = new InformalFullNameBuilder();
        public static IInformalFullNameBuilder InformalFullNameBuilder
        {
            get => TryGet(_informalFullNameBuilder, nameof(InformalFullNameBuilder));
            set => TrySet(ref _informalFullNameBuilder, value, nameof(InformalFullNameBuilder));
        }

        private static IMiddleInitialsBuilder _middleInitialsBuilder = new MiddleInitialsBuilder();
        public static IMiddleInitialsBuilder MiddleInitialsBuilder
        {
            get => TryGet(_middleInitialsBuilder, nameof(MiddleInitialsBuilder));
            set => TrySet(ref _middleInitialsBuilder, value, nameof(MiddleInitialsBuilder));
        }

        private bool FullNameRefreshRequired;
        private bool InformalFullNameRefreshRequired;
        private bool MiddleInitialsRefreshRequired;

        private string _firstName;
        private string _middleName;
        private string _lastName;
        private string _nameExtension;
        private string _fullName;
        private string _informalFullName;
        private string _middleInitials;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    FullNameRefreshRequired = true;
                    InformalFullNameRefreshRequired = true;
                }
            }
        }

        public string MiddleName
        {
            get { return _middleName; }
            set
            {
                if (_middleName != value)
                {
                    _middleName = value;
                    FullNameRefreshRequired = true;
                    InformalFullNameRefreshRequired = true;
                    MiddleInitialsRefreshRequired = true;
                }
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    FullNameRefreshRequired = true;
                    InformalFullNameRefreshRequired = true;
                }
            }
        }

        public string NameExtension
        {
            get { return _nameExtension; }
            set
            {
                if (_nameExtension != value)
                {
                    _nameExtension = value;
                    FullNameRefreshRequired = true;
                    InformalFullNameRefreshRequired = true;
                }
            }
        }

        public string FullName
        {
            get
            {
                if (FullNameRefreshRequired)
                {
                    _fullName = FullNameBuilder.Build(this);
                    FullNameRefreshRequired = false;
                }

                return _fullName;
            }
        }

        public string InformalFullName
        {
            get
            {
                if (InformalFullNameRefreshRequired)
                {
                    _informalFullName = InformalFullNameBuilder.Build(this);
                    InformalFullNameRefreshRequired = false;
                }

                return _informalFullName;
            }
        }

        public string MiddleInitials
        {
            get
            {
                if (MiddleInitialsRefreshRequired)
                {
                    _middleInitials = MiddleInitialsBuilder.Build(this);
                    MiddleInitialsRefreshRequired = false;
                }

                return _middleInitials;
            }
        }

        private static T TryGet<T>(T backingField, string propertyName)
        {
            if (Equals(backingField, default(T)))
            {
                throw new SorschiaException($"Static property '{typeof(NameBase).FullName}.{propertyName}' was not set.");
            }
            else
            {
                return backingField;
            }
        }

        private static void TrySet<T>(ref T backingField, T value, string propertyName)
        {
            if (Equals(value, default(T)))
            {
                throw new SorschiaException($"Static property '{typeof(NameBase).FullName}.{propertyName}' cannot be set to its default value.");
            }
            else
            {
                backingField = value;
            }
        }
    }
}
