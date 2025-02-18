// -----------------------------------------------------------------------------------------------------------
//   <copyright file="ImageExporter.cs" company="Aspose Pty Ltd" author="" date="13.03.2024 13:41">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Pdf.Adapter.ImageExporter
{
    using System;
    using System.IO;
    using Aspose.Pdf;
    using ImageOptions;
    using Image = Imaging.Image;
    using Rectangle = Imaging.Rectangle;

    /// <summary>
    /// The Image exporter
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Aspose.Imaging.IImageExporter" />
    internal class ImageExporter<T> : IImageExporter where T : SaveOptions
    {
        #region Methods

        /// <summary>
        /// Exports the specified input stream.
        /// </summary>
        /// <param name="inputStream">The input stream.</param>
        /// <param name="outputStream">The output stream.</param>
        /// <param name="saveOptions">The save options.</param>
        protected void Export(Stream inputStream, Stream outputStream, SaveOptions saveOptions)
        {
            using (var doc = new Document(inputStream, new ApsLoadOptions()))
            {
                if (saveOptions is PdfSaveOptionsExt)
                {
                    var pdfSveOptions = (saveOptions as PdfSaveOptionsExt);
                    if (pdfSveOptions != null && pdfSveOptions.FormatConversionOptions != null)
                    {
                        doc.Convert(pdfSveOptions.FormatConversionOptions);
                    }
                }

                doc.Save(outputStream, saveOptions);
            }
        }

        #endregion

        /// <summary>
        /// Exports the specified image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="stream">The stream.</param>
        /// <param name="optionsBase">The options base.</param>
        public void Export(Image image, Stream stream, ImageOptionsBase optionsBase)
        {
            this.Export(image, stream, optionsBase, Rectangle.Empty);
        }

        /// <summary>
        /// Exports the specified image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="stream">The stream.</param>
        /// <param name="optionsBase">The options base.</param>
        /// <param name="boundsRectangle">The bounds rectangle.</param>
        public void Export(Image image, Stream stream, ImageOptionsBase optionsBase, Rectangle boundsRectangle)
        {
            var saveOptions = (optionsBase as ImageOptionsExt<T>)?.SaveOptions ?? Activator.CreateInstance<T>();
            int pagenumber;
            using (var ms = image.GetSerializedStream(optionsBase, Rectangle.Empty, out pagenumber))
            {
                ms.Position = 0;
                this.Export(ms, stream, saveOptions);
            }
        }
    }
}