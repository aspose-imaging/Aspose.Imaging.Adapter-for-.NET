// -----------------------------------------------------------------------------------------------------------
//   <copyright file="NiblackThresholdProperties.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="14.11.2024 14:41">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Accord.Adapter.FiltersProperties
{
    /// <summary>
    /// The Niblack threshold properties
    /// </summary>
    /// <seealso cref="IThresholdProperties" />
    public class NiblackThresholdProperties : IThresholdProperties
    {
        /// <summary>
        /// Gets or sets the mean offset C. This value should be between 0 and 255. The default value is 0.
        /// </summary>
        /// <value>
        /// The c.
        /// </value>
        public double C { get; set; }

        /// <summary>
        /// Gets or sets the k.
        /// </summary>
        /// <value>
        /// The k.
        /// </value>
        public double K { get; set; } = 0.2;

        /// <summary>
        /// Gets or sets the radius.
        /// </summary>
        /// <value>
        /// The radius.
        /// </value>
        public int Radius { get; set; } = 15;
    }
}