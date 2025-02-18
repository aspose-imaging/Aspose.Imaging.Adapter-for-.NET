// -----------------------------------------------------------------------------------------------------------
//   <copyright file="FastCornersDetectorProperties.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="12.11.2024 11:12">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Accord.Adapter.ComputerVision.Corners
{
    /// <summary>
    /// The fast corners detector properties
    /// </summary>
    /// <seealso cref="Aspose.Imaging.Accord.Adapter.ComputerVision.Corners.ICornersDetectorProperties" />
    public class FastCornersDetectorProperties : ICornersDetectorProperties
    {
        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="FastCornersDetectorProperties"/> is suppress.
        /// </summary>
        /// <value>
        ///   <c>true</c> if suppress; otherwise, <c>false</c>.
        /// </value>
        public bool Suppress { get; set; }

        /// <summary>
        /// Gets or sets the threshold.
        /// </summary>
        /// <value>
        /// The threshold.
        /// </value>
        public int Threshold { get; set; } = 20;

        #endregion
    }
}