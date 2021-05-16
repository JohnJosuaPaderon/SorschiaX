using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Sorschia.Audit;

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
    }
}
