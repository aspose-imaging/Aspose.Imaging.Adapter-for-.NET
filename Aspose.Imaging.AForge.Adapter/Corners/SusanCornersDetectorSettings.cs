// -----------------------------------------------------------------------------------------------------------
//   <copyright file="SusanCornersDetectorSettings.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="04.09.2024 11:05">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.AForge.Adapter.Corners
{
    /// <summary>
    ///     The  Susan corners detector settings
    /// </summary>
    public class SusanCornersDetectorSettings : ICornersDetectorSettings
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="SusanCornersDetectorSettings" /> class.
        /// </summary>
        public SusanCornersDetectorSettings()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SusanCornersDetectorSettings" /> class.
        /// </summary>
        /// <param name="differenceThreshold">The difference threshold.</param>
        /// <param name="geometricalThreshold">The geometrical threshold.</param>
        public SusanCornersDetectorSettings(int differenceThreshold, int geometricalThreshold)
        {
            this.DifferenceThreshold = differenceThreshold;
            this.GeometricalThreshold = geometricalThreshold;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the geometrical threshold.
        /// </summary>
        /// <value>
        ///     The geometrical threshold.
        /// </value>
        public int GeometricalThreshold { get; set; }

        #endregion

        /// <summary>
        ///     Gets or sets the difference threshold.
        /// </summary>
        /// <value>
        ///     The difference threshold.
        /// </value>
        public int DifferenceThreshold { get; set; }
    }
}