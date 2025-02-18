// -----------------------------------------------------------------------------------------------------------
//   <copyright file="GaborFilterProperties.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="15.11.2024 11:10">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Accord.Adapter.FiltersProperties
{
    /// <summary>
    /// The Gabor filter properties
    /// </summary>
    public class GaborFilterProperties : IFilterProperties
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the aspect ratio for the filter. Default is 0.3.
        /// </summary>
        /// <value>
        ///     The gamma.
        /// </value>
        public double Gamma { get; set; } = 0.3;

        /// <summary>
        ///     Gets or sets the wavelength for the filter. Default is 4.0.
        /// </summary>
        /// <value>
        ///     The lambda.
        /// </value>
        public double Lambda { get; set; } = 4.0;

        /// <summary>
        ///     Gets or sets the phase offset for the filter. Default is 1.0.
        /// </summary>
        /// <value>
        ///     The psi.
        /// </value>
        public double Psi { get; set; } = 1.0;

        /// <summary>
        ///     Gets or sets the Gaussian variance for the filter.Default is 2.
        /// </summary>
        /// <value>
        ///     The sigma.
        /// </value>
        public double Sigma { get; set; } = 2.0;

        /// <summary>
        ///     Gets or sets the orientation for the filter, in radians. Default is 0.6.
        /// </summary>
        /// <value>
        ///     The theta.
        /// </value>
        public double Theta { get; set; } = 0.6;

        /// <summary>
        ///     Gets or sets the size of the filter. Default is 3.
        /// </summary>
        /// <value>
        ///     The size.
        /// </value>
        public int Size { get; set; } = 3;

        #endregion
    }
}