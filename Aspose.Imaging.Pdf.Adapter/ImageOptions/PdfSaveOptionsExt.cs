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
    /// </summary>
    /// <seealso cref="Aspose.Pdf.PdfSaveOptions" />
    public class PdfSaveOptionsExt : PdfSaveOptions
    {
        #region Properties

        /// <summary>
        /// Gets or sets the format conversion options.
        /// </summary>
        /// <value>
        /// The format conversion options.
        /// </value>
        public PdfFormatConversionOptions FormatConversionOptions { get; set; }

        #endregion
    }
}