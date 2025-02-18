// -----------------------------------------------------------------------------------------------------------
//   <copyright file="HaralickProperties.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="18.11.2024 16:31">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Accord.Adapter.ComputerVision.FeatureExtractor
{
    using Openize.Accord.Imaging.Interest_Points.Haralick;

    /// <summary>
    /// The Haralick properties
    /// </summary>
    public class HaralickProperties : IFeatureExtractorProperties
    {
        /// <summary>
        /// Gets or sets the mode.
        /// </summary>
        /// <value>
        /// The mode.
        /// </value>
        public HaralickMode Mode { get; set; }

        /// <summary>
        /// Gets or sets the size of the cell.
        /// </summary>
        /// <value>
        /// The size of the cell.
        /// </value>
        public int CellSize { get; set; }
    }
}