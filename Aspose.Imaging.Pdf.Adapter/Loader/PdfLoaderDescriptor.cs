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
    /// <seealso href="https://reference.aspose.com/imaging/net/aspose.imaging/iimageloaderdescriptor/" />
    public class PdfLoaderDescriptor : IImageLoaderDescriptor
    {
        /// <summary>
        /// Gets the <see href="https://reference.aspose.com/imaging/net/aspose.imaging/fileformat/">supported format.</see>
        /// </summary>
        /// <value>
        /// The supported format.
        /// </value>
        public FileFormat SupportedFormat => FileFormat.Pdf;

        /// <summary>
        /// Determines whether this instance can load the specified stream container.
        /// </summary>
        /// <param name="streamContainer"><see href="https://reference.aspose.com/imaging/net/aspose.imaging/streamcontainer/">The stream container.</see></param>
        /// <param name="loadOptions"><see href="https://reference.aspose.com/imaging/net/aspose.imaging/loadoptions/">The load options.</see></param>
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
        /// <returns>
        ///<see href="https://reference.aspose.com/imaging/net/aspose.imaging/iimageloader/">Aspose.Imaging.IImageLoader</see>
        /// </returns>
        public IImageLoader CreateInstance()
        {
            return new PdfImageLoader();
        }
    }
}