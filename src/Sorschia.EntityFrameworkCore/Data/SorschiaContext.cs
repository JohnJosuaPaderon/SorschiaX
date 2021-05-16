using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Sorschia.Audit;
using System.Diagnostics.CodeAnalysis;

namespace Sorschia.Data
{
    public class SorschiaContext : DbContext
    {
        private bool _isCurrentFootprintLoaded = false;
        private IFootprint _currentFootprint;

        public IFootprint CurrentFootprint
        {
            get
            {
                if (!_isCurrentFootprintLoaded)
                {
                    _currentFootprint = this.GetService<ICurrentFootprintProvider>().Current;
                    _isCurrentFootprintLoaded = true;
                }

                return _currentFootprint;
            }
        }

        public SorschiaContext([NotNull] DbContextOptions options) : base(options)
        {
        }
    }
}
