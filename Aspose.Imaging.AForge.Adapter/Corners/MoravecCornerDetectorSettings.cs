// -----------------------------------------------------------------------------------------------------------
//   <copyright file="MoravecCornerDetectorSettings.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="04.09.2024 11:06">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.AForge.Adapter.Corners
{
    /// <summary>
    ///     Moravec corner detector settings
    /// </summary>
    public class MoravecCornerDetectorSettings : ICornersDetectorSettings
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MoravecCornerDetectorSettings" /> class.
        /// </summary>
        /// <param name="differenceThreshold">The difference threshold.</param>
        /// <param name="windowSize">Size of the window.</param>
        public MoravecCornerDetectorSettings(int differenceThreshold, int windowSize)
        {
            this.WindowSize = windowSize;
            this.DifferenceThreshold = differenceThreshold;
        }

        public MoravecCornerDetectorSettings(int differenceThreshold) : this(differenceThreshold, 0)
        {
        }

        public MoravecCornerDetectorSettings()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the size of the window.
        /// </summary>
        /// <value>
        ///     The size of the window.
        /// </value>
        public int WindowSize { get; set; }

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