// -----------------------------------------------------------------------------------------------------------
//   <copyright file="HistogramsOfOrientedGradientsProperties.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="18.11.2024 17:30">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Accord.Adapter.ComputerVision.FeatureExtractor
{
    /// <summary>
    /// The histograms of oriented gradients properties
    /// </summary>
    public class HistogramsOfOrientedGradientsProperties : IFeatureExtractorProperties
    {
        /// <summary>
        /// Gets or sets the size of the block.
        /// </summary>
        /// <value>
        /// The size of the block.
        /// </value>
        public int BlockSize { get; set; } = 3;

        /// <summary>
        /// Gets or sets the size of the cell.
        /// </summary>
        /// <value>
        /// The size of the cell.
        /// </value>
        public int CellSize { get; set; } = 6;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="HistogramsOfOrientedGradientsProperties"/> is normalize.
        /// </summary>
        /// <value>
        ///   <c>true</c> if normalize; otherwise, <c>false</c>.
        /// </value>
        public bool Normalize { get; set; } = true;

        /// <summary>
        /// Gets or sets the number of bins.
        /// </summary>
        /// <value>
        /// The number of bins.
        /// </value>
        public int NumberOfBins { get; set; } = 9;


    }
}