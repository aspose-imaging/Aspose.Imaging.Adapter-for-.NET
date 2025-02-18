// -----------------------------------------------------------------------------------------------------------
//   <copyright file="ExhaustiveBlockMatchingSettings.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="29.08.2024 12:07">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.AForge.Adapter.ImageMatch
{
    public class ExhaustiveBlockMatchingSettings
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the difference threshold.
        /// </summary>
        /// <value>
        ///     The difference threshold.
        /// </value>
        public int DifferenceThreshold { get; set; } = 30;

        /// <summary>
        ///     Gets or sets the geometric threshold.
        /// </summary>
        /// <value>
        ///     The geometric threshold.
        /// </value>
        public int GeometricThreshold { get; set; } = 18;

        /// <summary>
        ///     Gets or sets the size of the block.
        /// </summary>
        /// <value>
        ///     The size of the block.
        /// </value>
        public int BlockSize { get; set; } = 8;

        /// <summary>
        ///     Gets or sets the search radius.
        /// </summary>
        /// <value>
        ///     The search radius.
        /// </value>
        public int SearchRadius { get; set; } = 12;

        #endregion
    }
}