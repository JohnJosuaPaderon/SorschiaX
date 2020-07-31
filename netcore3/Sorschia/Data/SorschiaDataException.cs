using System;
using System.Runtime.Serialization;

namespace Sorschia.Data
{
    public class SorschiaDataException : SorschiaException
    {
        public SorschiaDataException(bool isMessageViewable = default) : base(isMessageViewable)
        {
        }

        public SorschiaDataException(string message, bool isMessageViewable = default) : base(message, isMessageViewable)
        {
        }

        public SorschiaDataException(string message, Exception innerException, bool isMessageViewable = default) : base(message, innerException, isMessageViewable)
        {
        }

        protected SorschiaDataException(SerializationInfo info, StreamingContext context, bool isMessageViewable = default) : base(info, context, isMessageViewable)
        {
        }

        public static new SorschiaDataException RepositoryIsNull<TRepository>() => new SorschiaDataException($"Repository of type {typeof(TRepository).FullName} is null");
        public static new SorschiaDataException DependencySettingsIsNull<TDependencySettings>() => new SorschiaDataException($"Dependency settings of type {typeof(TDependencySettings).FullName} is null");
        public static new SorschiaDataException VariableIsNull<TVariable>(string variableName) => new SorschiaDataException($"Variable of type {typeof(TVariable).FullName} with name '{variableName}' is null");
        public static new SorschiaDataException InvalidParameter<TParameter>(string parameterName) => new SorschiaDataException($"Parameter of type {typeof(TParameter).FullName} with name '{parameterName}' is invalid");
    }
}
