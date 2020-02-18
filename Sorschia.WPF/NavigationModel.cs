using Prism.Regions;
using System;
using System.Collections.Generic;

namespace Sorschia
{
    public class NavigationModel
    {
        public string Region { get; set; }
        public string Target { get; set; }
        public Action<NavigationResult> Callback { get; set; }
        public IDictionary<string, object> Parameters { get; } = new Dictionary<string, object>();

        public NavigationModel AddParameter(string key, object value)
        {
            Parameters.Add(key, value);
            return this;
        }

        public NavigationParameters GetNavigationParameters()
        {
            var result = new NavigationParameters();

            foreach (var pair in Parameters)
            {
                result.Add(pair.Key, pair.Value);
            }

            return result;
        }
    }
}
