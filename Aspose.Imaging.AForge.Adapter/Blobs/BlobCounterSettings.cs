// -----------------------------------------------------------------------------------------------------------
//   <copyright file="BlobCounterSettings.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="28.08.2024 11:30">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.AForge.Adapter.Blobs
{
    /// <summary>
    /// The blob counter settings
    /// </summary>
    public class BlobCounterSettings
    {
        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether [filter blobs].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [filter blobs]; otherwise, <c>false</c>.
        /// </value>
        public bool FilterBlobs { get; set; }

        /// <summary>
        /// Gets or sets the minimum width.
        /// </summary>
        /// <value>
        /// The minimum width.
        /// </value>
        public int MinWidth { get; set; }

        /// <summary>
        /// Gets or sets the minimum height.
        /// </summary>
        /// <value>
        /// The minimum height.
        /// </value>
        public int MinHeight { get; set; }

        /// <summary>
        /// Gets or sets the maximum width.
        /// </summary>
        /// <value>
        /// The maximum width.
        /// </value>
        public int MaxWidth { get; set; } = int.MaxValue;

        /// <summary>
        /// Gets or sets the maximum height.
        /// </summary>
        /// <value>
        /// The maximum height.
        /// </value>
        public int MaxHeight { get; set; } = int.MaxValue;

        /// <summary>
        /// Gets or sets a value indicating whether [coupled size filtering].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [coupled size filtering]; otherwise, <c>false</c>.
        /// </value>
        public bool CoupledSizeFiltering { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        public BlobsOrder Order { get; set; }

        #endregion
    }
}