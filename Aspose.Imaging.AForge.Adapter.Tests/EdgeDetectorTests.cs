// -----------------------------------------------------------------------------------------------------------
//   <copyright file="EdgeDetectorTests.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="27.08.2024 14:16">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

using Aspose.Imaging.AForge.Adapter.Edge;
using Aspose.Imaging.Pdf.Adapter.Tests.ImageComparers;

namespace Aspose.Imaging.AForge.Adapter.Tests
{
    using Adatpter.Tests.Core.ImageComparers;

    /// <summary>
    /// The Edge detector tests
    /// </summary>
    /// <seealso cref="Aspose.Imaging.AForge.Adapter.Tests.AForgeTestsBase" />
    internal class EdgeDetectorTests : AForgeTestsBase
    {
        #region Methods

        /// <summary>
        /// Edge Detector Test
        /// </summary>
        [Test]
        [TestCase(EdgeDetectorType.Homogenity)]
        [TestCase(EdgeDetectorType.Difference)]
        [TestCase(EdgeDetectorType.Canny)]
        [TestCase(EdgeDetectorType.Sobel)]
        public void EdgeDetectorTest(EdgeDetectorType type)
        {
            this.EdgeDetector(false, type);
        }

        /// <summary>
        /// Edges the detector half size test.
        /// </summary>
        /// <param name="type">The type.</param>
        [Test]
        [TestCase(EdgeDetectorType.Homogenity)]
        [TestCase(EdgeDetectorType.Difference)]
        [TestCase(EdgeDetectorType.Canny)]
        [TestCase(EdgeDetectorType.Sobel)]
        public void EdgeDetectorHalfSizeTest(EdgeDetectorType type)
        {
            this.EdgeDetector(true, type);
        }

        /// <summary>
        /// Edges the detector.
        /// </summary>
        /// <param name="halfSize">if set to <c>true</c> [half size].</param>
        /// <param name="type">The type.</param>
        public void EdgeDetector (bool halfSize, EdgeDetectorType type)
        {
            var fileName = "polygons.cdr.png";
            var inputFileName = Path.Combine(this.ImagesPath, fileName);
            var outFileName = this.GetOutFileName($"{fileName}_{type}.png");
            var standardFileName = this.GetStandardFileName($"{fileName}_{type}.png");
            using (var image = (RasterImage)Image.Load(inputFileName))
            {
                var bounds = halfSize ? new Rectangle(0, 0, image.Width, image.Height / 2):image.Bounds;
                image.EdgeDetector(bounds, type);
                image.Save(outFileName);
            }

            var comparer = new BinaryComparer();
            CompareHelper.Compare(comparer, outFileName, standardFileName);
            RemoveFile(outFileName);
        }

        #endregion
    }
}