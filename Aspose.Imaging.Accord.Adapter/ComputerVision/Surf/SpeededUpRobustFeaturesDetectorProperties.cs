// -----------------------------------------------------------------------------------------------------------
//   <copyright file="SpeededUpRobustFeaturesDetectorProperties.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="13.11.2024 11:13">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Accord.Adapter.Surf
{
    /// <summary>
    /// The speeded-Up robust features detector properties
    /// </summary>
    public class SpeededUpRobustFeaturesDetectorProperties
    {
        #region Properties

        /// <summary>
        /// Gets or sets the octaves.
        /// </summary>
        /// <value>
        /// The octaves.
        /// </value>
        public int Octaves { get; set; } = 5;

        /// <summary>
        /// Gets or sets the step.
        /// </summary>
        /// <value>
        /// The step.
        /// </value>
        public int Step { get; set; } = 2;

        /// <summary>
        /// Gets or sets the threshold.
        /// </summary>
        /// <value>
        /// The threshold.
        /// </value>
        public double Threshold { get; set; } = 0.0002;

        #endregion
    }
}