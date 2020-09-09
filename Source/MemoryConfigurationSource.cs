﻿using System;
using System.Collections.Generic;
using System.Text;
using ConfigurationDemo.Abstraction;

namespace ConfigurationDemo.Source
{
    public class MemoryConfigurationSource : IConfigurationSource
    {
        /// <summary>
        /// The initial key value configuration pairs.
        /// </summary>
        public IEnumerable<KeyValuePair<string, string>> InitialData { get; set; }

        /// <summary>
        /// Builds the <see cref="MemoryConfigurationProvider"/> for this source.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/>.</param>
        /// <returns>A <see cref="MemoryConfigurationProvider"/></returns>
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new MemoryConfigurationProvider(this);
        }
    }
}
