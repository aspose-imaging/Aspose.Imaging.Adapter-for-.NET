// -----------------------------------------------------------------------------------------------------------
//   <copyright file="ImageOptions.cs" company="Aspose Pty Ltd" author="" date="13.03.2024 13:41">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Pdf.Adapter.ImageOptions
{
    using Aspose.Pdf;

    /// <summary>
    /// The extended image options of <see href="https://reference.aspose.com/imaging/net/aspose.imaging.imageoptions/">ImageOptionsBase</see>
    /// </summary>
    /// <typeparam name="T">T is <see href="https://reference.aspose.com/pdf/net/aspose.pdf.facades/form/saveoptions/">SaveOptions from Aspose.Pdf library</see></typeparam>
    /// <seealso href="https://reference.aspose.com/imaging/net/aspose.imaging.imageoptions/" />
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
        /// Gets or sets the <see href="https://reference.aspose.com/pdf/net/aspose.pdf.facades/form/saveoptions/">SaveOptions</see>.
        /// </summary>
        /// <value>
        /// The save options from Aspose.Pdf library.
        /// </value>
        public T SaveOptions { get; set; }

        #endregion
    }
}