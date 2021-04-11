using Microsoft.EntityFrameworkCore;
using Sorschia.Auditing;
using Sorschia.Data.Exceptions.Builders;
using System.Diagnostics.CodeAnalysis;

namespace Sorschia.Data
{
    public class SorschiaDbContext : DbContext
    {
        private readonly ICurrentFootprintProvider _currentFootprintProvider;

        private bool _isCurrentFootprintInjected = false;
        private Footprint? _currentFootprint;
        public Footprint? CurrentFootprint
        {
            get
            {
                if (!_isCurrentFootprintInjected)
                {
                    _currentFootprint = _currentFootprintProvider.Value;
                    _isCurrentFootprintInjected = true;
                }

                return _currentFootprint;
            }
        }
        public SorschiaDbContext([NotNull] DbContextOptions options, ICurrentFootprintProvider currentFootprintProvider) : base(options)
        {
            _currentFootprintProvider = currentFootprintProvider;
        }
    }
}
