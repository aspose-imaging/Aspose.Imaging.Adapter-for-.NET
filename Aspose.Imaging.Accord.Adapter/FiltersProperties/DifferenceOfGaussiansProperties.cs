// -----------------------------------------------------------------------------------------------------------
//   <copyright file="DifferenceOfGaussiansProperties.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="15.11.2024 12:56">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Accord.Adapter.FiltersProperties
{
    /// <summary>
    ///     The difference Of Gaussians properties
    /// </summary>
    /// <seealso cref="Aspose.Imaging.Accord.Adapter.FiltersProperties.IFilterProperties" />
    public class DifferenceOfGaussiansProperties : IFilterProperties
    {
        #region Properties

        /// <summary>
        /// Gets or sets the window size1.
        /// </summary>
        /// <value>
        /// The window size1.
        /// </value>
        public int WindowSize1 { get; set; } = 5;


        /// <summary>
        /// Gets or sets the window size2.
        /// </summary>
        /// <value>
        /// The window size2.
        /// </value>
        public int WindowSize2 { get; set; } = 5;

        /// <summary>
        ///     Gets or sets the sigma1.
        /// </summary>
        /// <value>
        ///     The sigma1.
        /// </value>
        public double Sigma1 { get; set; } = 1.4;

        /// <summary>
        ///     Gets or sets the sigma2.
        /// </summary>
        /// <value>
        ///     The sigma2.
        /// </value>
        public double Sigma2 { get; set; } = 1.4;

        #endregion
    }
}