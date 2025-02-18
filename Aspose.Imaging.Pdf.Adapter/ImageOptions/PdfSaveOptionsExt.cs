// -----------------------------------------------------------------------------------------------------------
//   <copyright file="PdfSaveOptionsExt.cs" company="Aspose Pty Ltd" author="" date="13.03.2024 13:41">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Pdf.Adapter.ImageOptions
{
    using Aspose.Pdf;

    /// <summary>
    /// The Pdf save options extended
    /// <seealso cref="Aspose.Pdf.PdfSaveOptions" />
    /// </summary>
    public class PdfSaveOptionsExt : PdfSaveOptions
    {
        #region Properties

        /// <summary>
        /// Gets or sets <see href="https://reference.aspose.com/pdf/net/aspose.pdf/pdfformatconversionoptions/pdfformatconversionoptions/">PdfConversionOptions</see>.
        /// </summary>
        /// <value>
        /// The format conversion options.
        /// </value>
        public PdfFormatConversionOptions FormatConversionOptions { get; set; }

        #endregion
    }
}