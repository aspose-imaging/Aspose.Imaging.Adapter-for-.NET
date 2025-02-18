// -----------------------------------------------------------------------------------------------------------
//   <copyright file="IThresholdProperties.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="14.11.2024 14:40">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Accord.Adapter.FiltersProperties
{
    /// <summary>
    ///     The threshold properties interface
    /// </summary>
    public interface IThresholdProperties : IFilterProperties
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the k.
        /// </summary>
        /// <value>
        ///     The k.
        /// </value>
        double K { get; set; }

        /// <summary>
        ///     Gets or sets the radius.
        /// </summary>
        /// <value>
        ///     The radius.
        /// </value>
        int Radius { get; set; }

        #endregion
    }
}