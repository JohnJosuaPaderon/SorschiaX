using Prism.Regions;
using System.Linq;

namespace Sorschia
{
    partial class ViewModelBase
    {
        protected void Navigate(NavigationModel model)
        {
            if (model == default)
            {
                throw new SorschiaWPFException("model cannot be set to it's default value");
            }

            if (string.IsNullOrWhiteSpace(model.Region))
            {
                throw new SorschiaWPFException("Region cannot be null or whitespace");
            }

            if (string.IsNullOrWhiteSpace(model.Target))
            {
                throw new SorschiaWPFException("Target cannot be null or whitespace");
            }

            RegionManager.RequestNavigate(model.Region, model.Target, model.Callback ?? NavigateCallback, model.GetNavigationParameters());
        }

        protected virtual void NavigateCallback(NavigationResult result)
        {
            var activeView = result.Context.NavigationService.Region.ActiveViews.FirstOrDefault();

            if (activeView == null || Equals(activeView.GetType(), typeof(object)))
            {
                var parameters = new NavigationParameters
                {
                    { NavigationConstants.NotFound_Region, result.Context.NavigationService.Region.Name },
                    { NavigationConstants.NotFound_Target, result.Context.Uri.ToString() }
                };

                RegionManager.RequestNavigate(result.Context.NavigationService.Region.Name, NavigationConstants.NotFound, parameters);
            }
        }
    }
}
