﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigurationDemo.Abstraction
{
    public interface IConfigurationSection : IConfiguration
    {
        /// <summary>
        /// Gets the key this section occupies in its parent.
        /// </summary>
        string Key { get; }

        /// <summary>
        /// Gets the full path to this section within the <see cref="IConfiguration"/>.
        /// </summary>
        string Path { get; }

        /// <summary>
        /// Gets or sets the section value.
        /// </summary>
        string Value { get; set; }
    }
}
