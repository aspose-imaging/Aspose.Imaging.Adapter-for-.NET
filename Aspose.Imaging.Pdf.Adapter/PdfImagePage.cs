// -----------------------------------------------------------------------------------------------------------
//   <copyright file="PdfImagePage.cs" company="Aspose Pty Ltd" author="" date="13.03.2024 13:41">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Pdf.Adapter
{
    using System;
    using System.IO;
    using Aspose.Pdf;
    using Imaging.ImageOptions;
    using Color = Imaging.Color;
    using Rectangle = Imaging.Rectangle;

    /// <summary>
    /// The Pdf image page of <see href="https://reference.aspose.com/imaging/net/aspose.imaging/vectorimage/">VectorImage</see>
    /// </summary>
    internal class PdfImagePage : VectorImage
    {
        #region Fields

        /// <summary>
        /// The page
        /// </summary>
        private Page page;

        /// <summary>
        /// The page number
        /// </summary>
        private int pageNumber;

        /// <summary>
        /// The parent
        /// </summary>
        private PdfImage parent;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfImagePage"/> class.
        /// </summary>
        /// <param name="pdfpage"><see href="https://reference.aspose.com/pdf/net/aspose.pdf/page/">The pdfpage.</see></param>
        /// <param name="parent">The parent.</param>
        /// <param name="pageNumber">The page number.</param>
        public PdfImagePage(Page pdfpage, PdfImage parent, int pageNumber)
        {
            this.page = pdfpage;
            this.parent = parent;
            this.pageNumber = pageNumber;
        }

        #endregion

        #region Properties


        /// <summary>
        /// Gets a value indicating whether this instance is cached.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is cached; otherwise, <c>false</c>.
        /// </value>
        public override bool IsCached { get; }

        /// <summary>
        /// Gets the bits per pixel.
        /// </summary>
        /// <value>
        /// The bits per pixel.
        /// </value>
        public override int BitsPerPixel { get; }

        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public override int Width => (int)this.page.PageInfo.Width;

        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        public override int Height => (int)this.page.PageInfo.Height;

        #endregion

        #region Methods

        /// <summary>
        /// Caches the data.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public override void CacheData()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Page resize.
        /// </summary>
        /// <param name="newWidth">The new width.</param>
        /// <param name="newHeight">The new height.</param>
        /// <param name="resizeType"><see href="https://reference.aspose.com/imaging/net/aspose.imaging/resizetype/">Type of the resize.</see></param>
        /// <exception cref="System.NotImplementedException"></exception>
        public override void Resize(int newWidth, int newHeight, ResizeType resizeType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Page resize.
        /// </summary>
        /// <param name="newWidth">The new width.</param>
        /// <param name="newHeight">The new height.</param>
        /// <param name="settings">The <see href="https://reference.aspose.com/imaging/net/aspose.imaging/imageresizesettings/">settings.</see></param>
        /// <exception cref="System.NotImplementedException"></exception>
        public override void Resize(int newWidth, int newHeight, ImageResizeSettings settings)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Rotate and flip pages.
        /// </summary>
        /// <param name="rotateFlipType"><see href="https://reference.aspose.com/imaging/net/aspose.imaging/rotatefliptype/">Type of the rotate flip.</see></param>
        /// <exception cref="System.NotImplementedException"></exception>
        public override void RotateFlip(RotateFlipType rotateFlipType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the palette.
        /// </summary>
        /// <param name="palette">The <see href="https://reference.aspose.com/imaging/net/aspose.imaging/icolorpalette/">palette.</see></param>
        /// <param name="updateColors">if set to <c>true</c> [update colors].</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public override void SetPalette(IColorPalette palette, bool updateColors)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the serialized stream.
        /// </summary>
        /// <param name="imageOptions"><see href="https://reference.aspose.com/imaging/net/aspose.imaging/imageoptionsbase/">The image options.</see></param>
        /// <param name="clippingRectangle"><see href="https://reference.aspose.com/imaging/net/aspose.imaging/rectangle/">The clipping rectangle.</see></param>
        /// <param name="pageNumber">The page number.</param>
        /// <returns></returns>
        public override Stream GetSerializedStream(ImageOptionsBase imageOptions, Rectangle clippingRectangle, out int pageNumber)
        {
            if (!this.parent.IsCached)
            {
                this.parent.CacheData();
            }

            imageOptions.VectorRasterizationOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Color.White
            };

            pageNumber = this.pageNumber;
            this.parent.Cache.Position = 0;
            return this.parent.Cache;
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override void SaveData(Stream stream)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}