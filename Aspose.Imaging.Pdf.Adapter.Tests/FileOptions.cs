// -----------------------------------------------------------------------------------------------------------
//   <copyright file="FileOptions.cs" company="Aspose Pty Ltd" author="" date="13.03.2024 13:40">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Pdf.Adapter.Tests
{
    using FileFormats.Tiff.Enums;
    using Imaging.ImageOptions;

    /// <summary>
    /// The file options
    /// </summary>
    /// <seealso cref="System.Collections.Generic.List&lt;Aspose.Imaging.Pdf.Adapter.Tests.FileOption&gt;" />
    internal class FileOptions : List<FileOption>
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="FileOptions" /> class.
        /// </summary>
        public FileOptions()
        {
            this.Add(new FileOption(FileFormat.Webp, new WebPOptions(), ".webp"));
            this.Add(new FileOption(FileFormat.Gif, new GifOptions(), ".gif"));
            this.Add(new FileOption(FileFormat.Psd, new PsdOptions(), ".psd"));
            this.Add(new FileOption(FileFormat.Tiff, new TiffOptions(TiffExpectedFormat.TiffLzwRgb), ".tif"));
            this.Add(new FileOption(FileFormat.Bmp, new BmpOptions(), ".bmp"));
            this.Add(new FileOption(FileFormat.Dicom, new DicomOptions(), ".dcm"));

            this.Add(new FileOption(FileFormat.Jpeg, new JpegOptions(), ".jpg"));
            this.Add(new FileOption(FileFormat.Jpeg2000, new Jpeg2000Options(), ".j2k"));
            this.Add(new FileOption(FileFormat.Png, new PngOptions(), ".png"));
            this.Add(new FileOption(FileFormat.Apng, new ApngOptions
            {
                DefaultFrameTime = 300
            }, ".a.png"));
#if !COMPACT
            this.Add(new FileOption(FileFormat.Emf, new EmfOptions(), ".emf"));
            this.Add(new FileOption(FileFormat.Svg, new SvgOptions(), ".svg"));
            this.Add(new FileOption(FileFormat.Wmf, new WmfOptions(), ".wmf"));
            this.Add(new FileOption(FileFormat.Custom, new PdfOptions(), ".pdf")); //Pdf
#endif
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Gets the file option.
        /// </summary>
        /// <param name="fileFormat">The file format.</param>
        /// <returns></returns>
        public FileOption GetFileOption(FileFormat fileFormat)
        {
            return this.Find(o => o.FileFormat == fileFormat);
        }

        /// <summary>
        ///     The instance
        /// </summary>
        public static FileOptions Instance = new();

        #endregion
    }
}