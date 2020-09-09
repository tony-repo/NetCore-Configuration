using ConfigurationDemo.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace ConfigurationDemo
{
    public class ConfigurationRoot : IConfigurationRoot, IDisposable
    {
        private readonly IList<IConfigurationProvider> _providers;
        private readonly IList<IDisposable> _changeTokenRegistrations;
        //private ConfigurationReloadToken _changeToken = new ConfigurationReloadToken();


        public ConfigurationRoot(IList<IConfigurationProvider> providers)
        {
            if (providers == null)
            {
                throw new ArgumentException(nameof(providers));
            }

            _providers = providers;
            foreach(IConfigurationProvider p  in providers)
            {
                p.Load();
            }
        }

        public string this[string key]
        {
            get
            {
                for (int i = _providers.Count - 1; i >= 0; i--)
                {
                    IConfigurationProvider provider = _providers[i];

                    if (provider.TryGet(key, out string value))
                    {
                        return value;
                    }
                }

                return null;
            }
            set
            {
                if (!_providers.Any())
                {
                   // throw new InvalidOperationException(SR.Error_NoSources);
                }

                foreach (IConfigurationProvider provider in _providers)
                {
                    provider.Set(key, value);
                }
            }
        }

        public IEnumerable<IConfigurationProvider> Providers => _providers;

        public IEnumerable<IConfigurationSection> GetChildren() => this.GetChildrenImplementation(null);

        public IConfigurationSection GetSection(string key)
         => new ConfigurationSection(this, key);

        public void Reload()
        {
            foreach (IConfigurationProvider provider in _providers)
            {
                provider.Load();
            }
            RaiseChanged();
        }

        private void RaiseChanged()
        {
         //   ConfigurationReloadToken previousToken = Interlocked.Exchange(ref _changeToken, new ConfigurationReloadToken());
            //previousToken.OnReload();
        }
        public void Dispose()
        {
            // dispose change token registrations
            foreach (IDisposable registration in _changeTokenRegistrations)
            {
                registration.Dispose();
            }

            // dispose providers
            foreach (IConfigurationProvider provider in _providers)
            {
                (provider as IDisposable)?.Dispose();
            }
        }
    }
}
