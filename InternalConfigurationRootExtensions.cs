using ConfigurationDemo.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigurationDemo
{
    public static class InternalConfigurationRootExtensions
    {
        internal static IEnumerable<IConfigurationSection> GetChildrenImplementation(this IConfigurationRoot root, string path)
        {
            return root.Providers
                .Aggregate(Enumerable.Empty<string>(),
                    (seed, source) => source.GetChildKeys(seed, path))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .Select(key => root.GetSection(path == null ? key : ConfigurationPath.Combine(path, key)));
        }
    }
}
