// -----------------------------------------------------------------------------------------------------------
//   <copyright file="PdfImageLoader.cs" company="Aspose Pty Ltd" author="" date="13.03.2024 13:41">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Pdf.Adapter.Loader
{
    /// <summary>
    /// The Pdf image loader
    /// </summary>
    /// <seealso cref="Aspose.Imaging.IImageLoader" />
    public class PdfImageLoader : IImageLoader
    {
        /// <summary>
        /// Loads the specified stream container.
        /// </summary>
        /// <param name="streamContainer">The stream container.</param>
        /// <param name="loadOptions">The load options.</param>
        /// <returns></returns>
        public Aspose.Imaging.Image Load(StreamContainer streamContainer, LoadOptions loadOptions)
        {
            return new PdfImage(streamContainer.Stream);
        }
    }
}