// -----------------------------------------------------------------------------------------------------------
//   <copyright file="HarrisCornersDetectorProperties.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="11.11.2024 13:41">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Accord.Adapter.ComputerVision.Corners
{
    using Openize.Accord.Imaging.Interest_Points;

    /// <summary>
    /// The harris corner detector properties
    /// </summary>
    public class HarrisCornersDetectorProperties : ICornersDetectorProperties
    {
        #region Properties


        /// <summary>
        /// Gets or sets the measure.
        /// </summary>
        /// <value>
        /// The measure.
        /// </value>
        public HarrisCornerMeasure Measure { get; set; }

        /// <summary>
        /// Gets or sets the k.
        /// </summary>
        /// <value>
        /// The k.
        /// </value>
        public float K { get; set; } = 0.004f;

        /// <summary>
        /// Gets or sets the sigma.
        /// </summary>
        /// <value>
        /// The sigma.
        /// </value>
        public double Sigma { get; set; } = 1.2d;

        /// <summary>
        /// Gets or sets the supression.
        /// </summary>
        /// <value>
        /// The supression.
        /// </value>
        public int Suppression { get; set; } = 3;

        /// <summary>
        /// Gets or sets the threshold.
        /// </summary>
        /// <value>
        /// The threshold.
        /// </value>
        public float Threshold { get; set; } = 20000;


        #endregion
    }
}