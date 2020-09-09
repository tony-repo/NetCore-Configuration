using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigurationDemo.Abstraction
{
    public interface IConfiguration
    {
        string this[string key] { get; set; }

        IConfigurationSection GetSection(string key);

        IEnumerable<IConfigurationSection> GetChildren();
    }
}
