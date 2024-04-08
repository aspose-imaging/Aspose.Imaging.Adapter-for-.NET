// -----------------------------------------------------------------------------------------------------------
//   <copyright file="PdfImage.cs" company="Aspose Pty Ltd" author="" date="13.03.2024 13:45">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Pdf.Adapter
{
    using System.Runtime.CompilerServices;
    using Aspose.Pdf;
    using ImageExporter;
    using ImageOptions;
    using Loader;
    using License = Imaging.License;

    /// <summary>
    ///     The pdf image
    /// </summary>
    /// <seealso cref="Aspose.Imaging.VectorMultipageImage" />
    public class PdfImage : VectorMultipageImage
    {
        #region Fields

        /// <summary>
        ///     The document
        /// </summary>
        private Document doc;

        /// <summary>
        ///     The page count
        /// </summary>
        private int pageCount;

        /// <summary>
        ///     The pages
        /// </summary>
        private PdfImagePage[] pages;

        /// <summary>
        /// The registered
        /// </summary>
        private static bool registered = false;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PdfImage" /> class.
        /// </summary>
        /// <param name="pdfDocument">The PDF document.</param>
        public PdfImage(Document pdfDocument)
        {
            this.doc = pdfDocument;
            this.RebuildPages();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PdfImage" /> class.
        /// </summary>
        /// <param name="stream">The stream.</param>
        public PdfImage(Stream stream) : this(new Document(stream))
        {
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the page count.
        /// </summary>
        /// <value>
        ///     The page count.
        /// </value>
        public override int PageCount => this.pageCount;

        /// <summary>
        ///     Gets the width.
        /// </summary>
        /// <value>
        ///     The width.
        /// </value>
        public override int Width => (int)this.doc.PageInfo.Width;

        /// <summary>
        ///     Gets the height.
        /// </summary>
        /// <value>
        ///     The height.
        /// </value>
        public override int Height => (int)this.doc.PageInfo.Height;

        /// <summary>
        ///     Gets the pages.
        /// </summary>
        /// <value>
        ///     The pages.
        /// </value>
        public override Imaging.Image[] Pages => this.pages;

        /// <summary>
        ///     Gets the default page.
        /// </summary>
        /// <value>
        ///     The default page.
        /// </value>
        public override Imaging.Image DefaultPage => this.pages[0];

        /// <summary>
        ///     Gets a value indicating whether this instance is cached.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is cached; otherwise, <c>false</c>.
        /// </value>
        public override bool IsCached { get; }

        /// <summary>
        ///     Gets the bits per pixel.
        /// </summary>
        /// <value>
        ///     The bits per pixel.
        /// </value>
        public override int BitsPerPixel { get; }

        /// <summary>
        /// Gets the PDF document.
        /// </summary>
        /// <value>
        /// The PDF document.
        /// </value>
        public Document PdfDocument => this.doc;

        /// <summary>
        ///     Gets the cache.
        /// </summary>
        /// <value>
        ///     The cache.
        /// </value>
        internal Stream Cache { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        ///     Sets the license.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public static void SetLicense(string fileName)
        {
            var pdfLic = new Aspose.Pdf.License();
            pdfLic.SetLicense(fileName);

            var imgLic = new License();
            imgLic.SetLicense(fileName);
        }

        /// <summary>
        ///     Sets the license.
        /// </summary>
        /// <param name="stream">The stream.</param>
        public static void SetLicense(Stream stream)
        {
            var pdfLic = new Aspose.Pdf.License();
            pdfLic.SetLicense(stream);

            var imgLic = new License();
            imgLic.SetLicense(stream);
        }

        /// <summary>
        /// Initializations this instance.
        /// </summary>
        [ModuleInitializer]
        public static void Register()
        {
            if (registered)
            {
                return;
            }

            ImageLoadersRegistry.Register(new PdfLoaderDescriptor());
            ImageExportersRegistry.Register(new ImageExporterDescriptor<PdfSaveOptionsExt>());
            ImageExportersRegistry.Register(new ImageExporterDescriptor<HtmlSaveOptions>());
            ImageExportersRegistry.Register(new ImageExporterDescriptor<DocSaveOptions>());
            ImageExportersRegistry.Register(new ImageExporterDescriptor<ExcelSaveOptions>());
            ImageExportersRegistry.Register(new ImageExporterDescriptor<PptxSaveOptions>());
            registered = true;
        }

        /// <summary>
        ///     Caches the data.
        /// </summary>
        public override void CacheData()
        {
            var stream = new MemoryStream();
            this.doc.Save(stream, new ApsSaveOptions());
            this.Cache = stream;
        }

        /// <summary>
        ///     Resizes the specified new width.
        /// </summary>
        /// <param name="newWidth">The new width.</param>
        /// <param name="newHeight">The new height.</param>
        /// <param name="resizeType">Type of the resize.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public override void Resize(int newWidth, int newHeight, ResizeType resizeType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Resizes the specified new width.
        /// </summary>
        /// <param name="newWidth">The new width.</param>
        /// <param name="newHeight">The new height.</param>
        /// <param name="settings">The settings.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public override void Resize(int newWidth, int newHeight, ImageResizeSettings settings)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Rotates the flip.
        /// </summary>
        /// <param name="rotateFlipType">Type of the rotate flip.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public override void RotateFlip(RotateFlipType rotateFlipType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Sets the palette.
        /// </summary>
        /// <param name="palette">The palette.</param>
        /// <param name="updateColors">if set to <c>true</c> [update colors].</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public override void SetPalette(IColorPalette palette, bool updateColors)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Rebuilds the pages.
        /// </summary>
        private void RebuildPages()
        {
            this.pages = new PdfImagePage[this.doc.Pages.Count];
            var i = 0;
            foreach (var page in this.doc.Pages)
            {
                this.pages[i] = new PdfImagePage(page, this, i);
                i++;
            }

            this.pageCount = this.pages.Length;
        }

        #endregion
    }
}