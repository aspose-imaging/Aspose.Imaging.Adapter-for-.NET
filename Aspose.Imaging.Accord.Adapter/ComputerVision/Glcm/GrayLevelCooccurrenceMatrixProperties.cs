// -----------------------------------------------------------------------------------------------------------
//   <copyright file="GrayLevelCooccurrenceMatrixProperties.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="13.11.2024 12:17">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Accord.Adapter.ComputerVision.Glcm
{
    using Openize.Accord.Imaging;

    /// <summary>
    /// The gray level cooccurrence matrix properties
    /// </summary>
    public class GrayLevelCooccurrenceMatrixProperties
    {
        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether [automatic gray].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [automatic gray]; otherwise, <c>false</c>.
        /// </value>
        public bool AutoGray { get; set; }

        /// <summary>
        /// Gets or sets the degree.
        /// </summary>
        /// <value>
        /// The degree.
        /// </value>
        public CooccurrenceDegree Degree { get; set; }

        /// <summary>
        /// Gets or sets the distance.
        /// </summary>
        /// <value>
        /// The distance.
        /// </value>
        public int Distance { get; set; } = 1;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GrayLevelCooccurrenceMatrixProperties"/> is normalize.
        /// </summary>
        /// <value>
        ///   <c>true</c> if normalize; otherwise, <c>false</c>.
        /// </value>
        public bool Normalize { get; set; }


        #endregion
    }
}