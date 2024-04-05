// -----------------------------------------------------------------------------------------------------------
//   <copyright file="ImageExporterDescriptor.cs" company="Aspose Pty Ltd" author="" date="13.03.2024 13:41">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Pdf.Adapter.ImageExporter
{
    using Aspose.Pdf;
    using ImageOptions;
    using Image = Imaging.Image;

    /// <summary>
    /// The image exporter descriptor
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Aspose.Imaging.IImageExporterDescriptor" />
    internal class ImageExporterDescriptor<T> : IImageExporterDescriptor where T : SaveOptions
    {
        /// <summary>
        /// Gets the supported format.
        /// </summary>
        /// <value>
        /// The supported format.
        /// </value>
        public FileFormat SupportedFormat { get; }

        /// <summary>
        /// Determines whether this instance can export the specified image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="optionsBase">The options base.</param>
        /// <returns>
        ///   <c>true</c> if this instance can export the specified image; otherwise, <c>false</c>.
        /// </returns>
        public bool CanExport(Image image, ImageOptionsBase optionsBase)
        {
            return optionsBase is ImageOptionsExt<T>;
        }

        /// <summary>
        /// Creates the instance.
        /// </summary>
        /// <returns></returns>
        public IImageExporter CreateInstance()
        {
            return new ImageExporter<T>();
        }
    }
}