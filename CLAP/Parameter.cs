﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace CLAP
{
    /// <summary>
    /// A parameter descriptor
    /// </summary>
    [DebuggerDisplay("{ParameterInfo}")]
    public sealed class Parameter
    {
        #region Properties

        /// <summary>
        /// The default value
        /// </summary>
        public object Default { get; private set; }

        /// <summary>
        /// The default value provider
        /// </summary>
        public DefaultProvider DefaultProvider { get; private set; }

        /// <summary>
        /// Whether this parameter is required
        /// </summary>
        public Boolean Required { get; private set; }

        /// <summary>
        /// The names of the parameter, as defined by the Parameter attribute and the additional names
        /// </summary>
        public List<string> Names { get; private set; }

        /// <summary>
        /// The parameter description
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// The parameter array separator
        /// </summary>
        public string Separator { get; private set; }

        /// <summary>
        /// Name of an environment variable to get value from if not explicitly specified.
        /// </summary>
        public string EnvironmentVariableName { get; }

        /// <summary>
        /// Defines whether this parameter should be injected from <see cref="IServiceProvider"/> (if it was configured).
        /// </summary>
        public bool Inject { get; }

        /// <summary>
        /// The <see cref="ParameterInfo"/> this parameter describes
        /// </summary>
        public ParameterInfo ParameterInfo { get; private set; }

        #endregion Properties

        #region Constructors

        internal Parameter(ParameterInfo parameter)
        {
            Debug.Assert(parameter != null);

            Names = new List<string>();

            // Names are stored as lower-case.
            // The first available name is the parameters's original name.
            //
            Names.Add(parameter.Name.ToLowerInvariant());

            ParameterInfo = parameter;

            Required = parameter.HasAttribute<RequiredAttribute>();

            if (parameter.HasAttribute<DefaultValueAttribute>())
            {
                Default = parameter.GetAttribute<DefaultValueAttribute>().DefaultValue;
            }

            if (parameter.HasAttribute<DefaultProviderAttribute>())
            {
                DefaultProvider = (DefaultProvider)Activator.CreateInstance(
                    parameter.GetAttribute<DefaultProviderAttribute>().DefaultProviderType);
            }

            if (parameter.HasAttribute<DescriptionAttribute>())
            {
                Description = parameter.GetAttribute<DescriptionAttribute>().Description;
            }

            if (parameter.HasAttribute<AliasesAttribute>())
            {
                Names.AddRange(parameter.GetAttribute<AliasesAttribute>().Aliases.ToLowerInvariant().CommaSplit());
            }

            if (parameter.HasAttribute<SeparatorAttribute>())
            {
                Separator = parameter.GetAttribute<SeparatorAttribute>().Separator;
            }

            if (parameter.HasAttribute<EnvironmentAttribute>())
            {
                EnvironmentVariableName = parameter.GetAttribute<EnvironmentAttribute>().VariableName;
            }

            if (parameter.HasAttribute<InjectAttribute>())
            {
                Inject = true;
            }
        }

        #endregion Constructors
    }
}