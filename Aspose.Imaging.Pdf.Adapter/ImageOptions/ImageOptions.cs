// -----------------------------------------------------------------------------------------------------------
//   <copyright file="ImageOptions.cs" company="Aspose Pty Ltd" author="" date="13.03.2024 13:41">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Pdf.Adapter.ImageOptions
{
    using Aspose.Pdf;

    /// <summary>
    /// The image options extended
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Aspose.Imaging.ImageOptionsBase" />
    public class ImageOptionsExt<T> : ImageOptionsBase where T : SaveOptions
    {
        /// <summary>
        /// Initializes the <see cref="ImageOptionsExt{T}"/> class.
        /// </summary>
        static ImageOptionsExt()
        {
            PdfImage.Register();
        }

        #region Properties

        /// <summary>
        /// Gets or sets the save options.
        /// </summary>
        /// <value>
        /// The save options.
        /// </value>
        public T SaveOptions { get; set; }

        #endregion
    }
}