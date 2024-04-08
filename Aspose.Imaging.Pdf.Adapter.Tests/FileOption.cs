// -----------------------------------------------------------------------------------------------------------
//   <copyright file="FileOption.cs" company="Aspose Pty Ltd" author="" date="13.03.2024 13:40">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Pdf.Adapter.Tests
{
    /// <summary>
    ///     File option
    /// </summary>
    public class FileOption
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="FileOption" /> class.
        /// </summary>
        /// <param name="fileFormat">The file format.</param>
        /// <param name="imageOptions">The image options.</param>
        /// <param name="ext">The ext.</param>
        public FileOption(FileFormat fileFormat, ImageOptionsBase imageOptions, string ext)
        {
            this.FileFormat = fileFormat;
            this.ImageOptions = imageOptions;
            this.FileExt = ext;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the image options.
        /// </summary>
        /// <value>
        ///     The image options.
        /// </value>
        public ImageOptionsBase ImageOptions { get; set; }

        /// <summary>
        ///     Gets or sets the file format.
        /// </summary>
        /// <value>
        ///     The file format.
        /// </value>
        public FileFormat FileFormat { get; set; }

        /// <summary>
        ///     Gets or sets the file ext.
        /// </summary>
        /// <value>
        ///     The file ext.
        /// </value>
        public string FileExt { get; set; }

        #endregion
    }
}