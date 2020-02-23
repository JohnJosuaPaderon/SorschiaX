﻿namespace Sorschia.SystemBase.Security.ParameterProviders
{
    internal sealed class DeleteUserModuleParameterProvider
    {
        public string Id { get; } = "@Id";
        public string DeletedBy { get; } = "@DeletedBy";
    }
}