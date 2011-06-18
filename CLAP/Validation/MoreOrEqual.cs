﻿using System;

namespace CLAP.Validation
{
    /// <summary>
    /// More Or Equal-To validation
    /// </summary>
    [Serializable]
    public sealed class MoreOrEqualToAttribute : NumberValidationAttribute
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MoreOrEqualToAttribute(int number)
            : base(new MoreOrEqualToValidator(number))
        {

        }

        public override string Description
        {
            get
            {
                return "More or equal to {0}".FormatWith(Number);
            }
        }

        /// <summary>
        /// More Or Equal-To validator
        /// </summary>
        private class MoreOrEqualToValidator : NumberValidator
        {
            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="number"></param>
            public MoreOrEqualToValidator(int number)
                : base(number)
            {
            }

            /// <summary>
            /// Validate
            /// </summary>
            /// <param name="value"></param>
            public override void Validate(object value)
            {
                if ((int)value < Number)
                {
                    throw new ValidationException("{0} is not more or equal to {1}".FormatWith(value, Number));
                }
            }
        }
    }
}