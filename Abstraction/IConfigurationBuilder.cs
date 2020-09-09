using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigurationDemo.Abstraction
{
    public interface IConfigurationBuilder
    {
        IDictionary<string, string> Properties { get; }

        IList<IConfigurationSource> Sources { get; }

        IConfigurationBuilder Add(IConfigurationSource source);

        IConfigurationRoot Build();

    }
}
