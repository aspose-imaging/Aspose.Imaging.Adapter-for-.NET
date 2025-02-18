// -----------------------------------------------------------------------------------------------------------
//   <copyright file="CornersDetectorTests.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="04.09.2024 10:33">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.AForge.Adapter.Tests
{
    using Adatpter.Tests.Core.ImageComparers;
    using Corners;
    using Pdf.Adapter.Tests.ImageComparers;

    /// <summary>
    ///     The Corners detector tests
    /// </summary>
    /// <seealso cref="Aspose.Imaging.AForge.Adapter.Tests.AForgeTestsBase" />
    public class CornersDetectorTests : AForgeTestsBase
    {
        #region Methods

        /// <summary>
        ///     Cornerses the detector test.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        [Test]
        [TestCase(CornerDetecorType.Susan)]
        [TestCase(CornerDetecorType.Moravec)]
        public void CornersDetectorTest(CornerDetecorType type)
        {
            this.CornersDetector(false, type);
        }

        [Test]
        [TestCase(CornerDetecorType.Susan)]
        [TestCase(CornerDetecorType.Moravec)]
        public void CornersDetectorTestHalfSize(CornerDetecorType type)
        {
            this.CornersDetector(true, type);
        }

        /// <summary>
        ///     Cornerses the detector.
        /// </summary>
        /// <param name="halfSize">if set to <c>true</c> [half size].</param>
        /// <param name="type">The type.</param>
        private void CornersDetector(bool halfSize, CornerDetecorType type)
        {
            var fileName = "polygons.cdr.png";
            var inputFileName = Path.Combine(this.ImagesPath, fileName);
            var outFileName = this.GetOutFileName($"{fileName}_{type}.png");
            var standardFileName = this.GetStandardFileName($"{fileName}_{type}.png");
            using (var image = (RasterImage)Image.Load(inputFileName))
            {
                var bounds = halfSize ? new Rectangle(0, 0, image.Width, image.Height / 2) : image.Bounds;
                ICornersDetectorSettings settings =
                    type == CornerDetecorType.Susan ? new SusanCornersDetectorSettings(30, 7) : new MoravecCornerDetectorSettings();
                var points = image.CornersDetector(bounds, settings);
                this.AddCornersToImage(image, points);
                image.Save(outFileName);
            }

            var comparer = new BinaryComparer();
            CompareHelper.Compare(comparer, outFileName, standardFileName);
            RemoveFile(outFileName);
        }

        /// <summary>
        ///     Adds the corners to image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="points">The points.</param>
        private void AddCornersToImage(RasterImage image, List<Point> points)
        {
            var graphics = new Graphics(image);
            var pen = new Pen(Color.Red, 1);
            for (var i = 0; i < points.Count; i++)
            {
                var point = points[i];
                var rect = new Rectangle(point.X - 1, point.Y - 1, 2, 2);
                graphics.DrawArc(pen, rect, 0, 360);
            }
        }

        /// <summary>
        /// The Corner detector type
        /// </summary>
        public enum CornerDetecorType
        {
            /// <summary>
            ///     The moravec
            /// </summary>
            Moravec,

            /// <summary>
            ///     The susan
            /// </summary>
            Susan
        }

        #endregion
    }
}