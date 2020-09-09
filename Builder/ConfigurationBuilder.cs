using ConfigurationDemo.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigurationDemo.Builder
{
    public class ConfigurationBuilder : IConfigurationBuilder
    {
        public IDictionary<string, string> Properties { get; } = new Dictionary<string, string>();

        public IList<IConfigurationSource> Sources { get; } = new List<IConfigurationSource>();

        public IConfigurationBuilder Add(IConfigurationSource source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            Sources.Add(source);
            return this;
        }

        public IConfigurationRoot Build()
        {
            var providers = new List<IConfigurationProvider>();
            foreach(IConfigurationSource source in Sources)
            {
                IConfigurationProvider provider = source.Build(this);
                providers.Add(provider);
            }
            return new ConfigurationRoot(providers);
        }
    }
}
