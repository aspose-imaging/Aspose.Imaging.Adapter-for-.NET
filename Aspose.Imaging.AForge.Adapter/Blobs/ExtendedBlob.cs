// -----------------------------------------------------------------------------------------------------------
//   <copyright file="ExtendedBlob.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="28.08.2024 13:35">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.AForge.Adapter.Blobs
{
    using System.Collections.Generic;
    using FileFormats.Png;
    using Openize.AForge.Imaging.NetStandard;

    /// <summary>
    /// The extended blob
    /// </summary>
    public class ExtendedBlob
    {
        #region Fields

        /// <summary>
        /// The source image
        /// </summary>
        private RasterImage srcImage;

        /// <summary>
        /// The BLOB counter
        /// </summary>
        private BlobCounter blobCounter;

        /// <summary>
        /// The source BLOB
        /// </summary>
        private Blob srcBlob;

        /// <summary>
        /// The rectangle
        /// </summary>
        private Rectangle srcRectangle;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedBlob" /> class.
        /// </summary>
        /// <param name="sourceBlob">The source.</param>
        /// <param name="sourceImage">The source image.</param>
        /// <param name="bc">The bc.</param>
        /// <param name="rectangle">The rectangle.</param>
        internal ExtendedBlob(Blob sourceBlob, RasterImage sourceImage, BlobCounter bc, Rectangle rectangle)
        {
            this.Area = sourceBlob.Area;
            this.CenterOfGravity = new PointF(sourceBlob.CenterOfGravity.X, sourceBlob.CenterOfGravity.Y);
            this.ColorMean = Color.FromArgb(sourceBlob.ColorMean.ToArgb());
            this.ColorStdDev = Color.FromArgb(sourceBlob.ColorStdDev.ToArgb());
            this.Fullness = sourceBlob.Fullness;
            this.Id = sourceBlob.ID;
            this.OriginalSize = sourceBlob.OriginalSize;
            this.Rectangle = new Rectangle(sourceBlob.Rectangle.X, sourceBlob.Rectangle.Y, sourceBlob.Rectangle.Width, sourceBlob.Rectangle.Height);
            this.srcImage = sourceImage;
            this.blobCounter = bc;
            this.srcBlob = sourceBlob;
            this.srcRectangle = rectangle;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the rectangle.
        /// </summary>
        /// <value>
        /// The rectangle.
        /// </value>
        public Rectangle Rectangle { get; }

        /// <summary>
        /// Gets the area.
        /// </summary>
        /// <value>
        /// The area.
        /// </value>
        public int Area { get; }

        /// <summary>
        /// Gets the center of gravity.
        /// </summary>
        /// <value>
        /// The center of gravity.
        /// </value>
        public PointF CenterOfGravity { get; }

        /// <summary>
        /// Gets the color mean.
        /// </summary>
        /// <value>
        /// The color mean.
        /// </value>
        public Color ColorMean { get; }

        /// <summary>
        /// Gets the color standard dev.
        /// </summary>
        /// <value>
        /// The color standard dev.
        /// </value>
        public Color ColorStdDev { get; }

        /// <summary>
        /// Gets the fullness.
        /// </summary>
        /// <value>
        /// The fullness.
        /// </value>
        public double Fullness { get; }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; }

        /// <summary>
        /// Gets a value indicating whether [original size].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [original size]; otherwise, <c>false</c>.
        /// </value>
        public bool OriginalSize { get; }

        #endregion

        #region Methods

        /// <summary>
        ///     Gets the image.
        /// </summary>
        /// <returns></returns>
        public RasterImage GetImage(bool extractInOriginalSize)
        {
            var pixels = this.srcImage.LoadArgb32Pixels(this.srcRectangle);
            using (var unmanagedImage = PixelExport.PixelDataToImage(pixels, this.srcRectangle.Width, this.srcRectangle.Height))
            {
                this.blobCounter.ExtractBlobsImage(unmanagedImage, this.srcBlob, extractInOriginalSize);
                using (this.srcBlob.Image)
                {
                    pixels = PixelExport.ImageToPixelData(this.srcBlob.Image);
                    var image = new PngImage(this.srcBlob.Image.Width, this.srcBlob.Image.Height);
                    image.SaveArgb32Pixels(image.Bounds, pixels);
                    return image;
                }
            }
        }

        /// <summary>
        /// Gets the edge points.
        /// </summary>
        /// <returns></returns>
        public List<Point> GetEdgePoints()
        {
            var edgePoints = this.blobCounter.GetBlobsEdgePoints(this.srcBlob);
            var points = new List<Point>();
            for (int i = 0; i < edgePoints.Count; i++)
            {
                var edgePoint = edgePoints[i];
                points.Add(new Point(edgePoint.X, edgePoint.Y));
            }

            return points;
        }

        #endregion
    }
}