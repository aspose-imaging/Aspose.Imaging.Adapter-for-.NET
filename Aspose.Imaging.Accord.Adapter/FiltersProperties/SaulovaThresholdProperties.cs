// -----------------------------------------------------------------------------------------------------------
//   <copyright file="SaulovaThresholdProperties.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="14.11.2024 14:39">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Accord.Adapter.FiltersProperties
{
    /// <summary>
    /// The Saulova threshold properties
    /// </summary>
    /// <seealso cref="IThresholdProperties" />
    public class SaulovaThresholdProperties : IThresholdProperties
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the dynamic range of the standard deviation, R
        /// </summary>
        /// <value>
        ///     The R.
        /// </value>
        public double R { get; set; } = 128;

        #endregion

        /// <summary>
        ///     Gets or sets the k.
        /// </summary>
        /// <value>
        ///     The k.
        /// </value>
        public double K { get; set; } = 0.5;

        /// <summary>
        ///     Gets or sets the radius.
        /// </summary>
        /// <value>
        ///     The radius.
        /// </value>
        public int Radius { get; set; } = 15;
    }
}