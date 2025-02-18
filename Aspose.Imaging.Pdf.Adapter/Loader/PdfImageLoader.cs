// -----------------------------------------------------------------------------------------------------------
//   <copyright file="PdfImageLoader.cs" company="Aspose Pty Ltd" author="" date="13.03.2024 13:41">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Pdf.Adapter.Loader
{
    /// <summary>
    /// The Pdf image loader of <see href="https://reference.aspose.com/imaging/net/aspose.imaging/iimageloader/">IImageLoader</see>
    /// <br/>
    /// See also
    /// <seealso href="https://reference.aspose.com/imaging/net/aspose.imaging/iimageloader/" />
    /// </summary>
    public class PdfImageLoader : IImageLoader
    {
        /// <summary>
        /// Loads an image from the specified stream container.
        /// </summary>
        /// <param name="streamContainer"><see href="https://reference.aspose.com/imaging/net/aspose.imaging/streamcontainer/">The stream container.</see></param>
        /// <param name="loadOptions"><see href="https://reference.aspose.com/imaging/net/aspose.imaging/loadoptions/">The load options.</see></param>
        /// <returns>
        /// <see href="https://reference.aspose.com/imaging/net/aspose.imaging/image/">Aspose.Imaging.Image</see>
        /// </returns>
        public Aspose.Imaging.Image Load(StreamContainer streamContainer, LoadOptions loadOptions)
        {
            return new PdfImage(streamContainer.Stream);
        }

    }
}