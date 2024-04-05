// -----------------------------------------------------------------------------------------------------------
//   <copyright file="PdfLoaderDescriptor.cs" company="Aspose Pty Ltd" author="" date="13.03.2024 13:41">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Pdf.Adapter.Loader
{
    using Aspose.Pdf.Facades;

    /// <summary>
    /// The pdf loader descriptor
    /// </summary>
    /// <seealso cref="Aspose.Imaging.IImageLoaderDescriptor" />
    public class PdfLoaderDescriptor : IImageLoaderDescriptor
    {
        /// <summary>
        /// Gets the supported format.
        /// </summary>
        /// <value>
        /// The supported format.
        /// </value>
        public FileFormat SupportedFormat => FileFormat.Pdf;

        /// <summary>
        /// Determines whether this instance can load the specified stream container.
        /// </summary>
        /// <param name="streamContainer">The stream container.</param>
        /// <param name="loadOptions">The load options.</param>
        /// <returns>
        ///   <c>true</c> if this instance can load the specified stream container; otherwise, <c>false</c>.
        /// </returns>
        public bool CanLoad(StreamContainer streamContainer, LoadOptions loadOptions)
        {
            var pos = streamContainer.Stream.Position;
            var pdfFileInfo = new PdfFileInfo(streamContainer.Stream);
            streamContainer.Stream.Position = pos;
            return pdfFileInfo.IsPdfFile;
        }

        /// <summary>
        /// Creates the instance.
        /// </summary>
        /// <returns></returns>
        public IImageLoader CreateInstance()
        {
            return new PdfImageLoader();
        }
    }
}