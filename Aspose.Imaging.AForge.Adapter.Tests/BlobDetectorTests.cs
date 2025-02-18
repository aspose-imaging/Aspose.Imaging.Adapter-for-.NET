// -----------------------------------------------------------------------------------------------------------
//   <copyright file="BlobDetectorTests.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="28.08.2024 15:08">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.AForge.Adapter.Tests
{
    using Adatpter.Tests.Core.ImageComparers;
    using Blobs;
    using FileFormats.Png;
    using Pdf.Adapter.Tests.ImageComparers;

    /// <summary>
    /// The blob detector test
    /// </summary>
    /// <seealso cref="Aspose.Imaging.AForge.Adapter.Tests.AForgeTestsBase" />
    internal class BlobDetectorTests : AForgeTestsBase
    {
        #region Methods

        /// <summary>
        /// BLOBs the detector test.
        /// </summary>
        [Test]
        public void BlobDetectorTest()
        {
            var fileName = "sample2.jpg";
            var inputFileName = Path.Combine(this.ImagesPath, fileName);
            var outFileName = this.GetOutFileName("blob.png");
            var standardFileName = this.GetStandardFileName("blob.png");
            using (var image = (RasterImage)Image.Load(inputFileName))
            {
                var settings = new BlobCounterSettings
                {
                    FilterBlobs = true,
                    MinHeight = 10,
                    MinWidth = 10,
                    Order = BlobsOrder.Size
                };

                var blobs = image.DetectBlobs(settings, image.Bounds);
                var expectedCount = 4;
                Assert.AreEqual(expectedCount, blobs.Count);
                var blob = blobs[0];
                using (var b = blob.GetImage(false))
                {
                    b.Save(outFileName);
                }
            }

            var comparer = new BinaryComparer();
            CompareHelper.Compare(comparer, outFileName, standardFileName);
            RemoveFile(outFileName);
        }

        /// <summary>
        /// BLOBs the detector points test.
        /// </summary>
        [Test]
        public void BlobDetectorPointsTest()
        {
            var fileName = "sample2.jpg";
            var inputFileName = Path.Combine(this.ImagesPath, fileName);
            var outFileName = this.GetOutFileName("blob.png");
            var standardFileName = this.GetStandardFileName("blob.png");
            using (var image = (RasterImage)Image.Load(inputFileName))
            {
                var settings = new BlobCounterSettings
                {
                    FilterBlobs = true,
                    MinHeight = 10,
                    MinWidth = 10,
                    Order = BlobsOrder.Size
                };

                var blobs = image.DetectBlobs(settings, image.Bounds);
                var expectedCount = 4;
                Assert.AreEqual(expectedCount, blobs.Count);
                var blob = blobs[1];

                using (var png = new PngImage(image.Width, image.Height))
                {
                    var g = new Graphics(png);
                    g.DrawPolygon(new Pen(Color.Red, 3), blob.GetEdgePoints().ToArray());
                    png.Save(outFileName);
                }
            }

            var comparer = new BinaryComparer();
            CompareHelper.Compare(comparer, outFileName, standardFileName);
            RemoveFile(outFileName);
        }

        /// <summary>
        /// Extracts the biggest BLOB.
        /// </summary>
        [Test]
        public void ExtractBiggestBlob()
        {
            var fileName = "sample2.jpg";
            var inputFileName = Path.Combine(this.ImagesPath, fileName);
            var outFileName = this.GetOutFileName("blob.png");
            var standardFileName = this.GetStandardFileName("blob.png");
            using (var image = (RasterImage)Image.Load(inputFileName))
            {
                using (var blob = image.ExtractBiggestBlob(image.Bounds))
                {
                    blob.Save(outFileName);   
                }
            }

            var comparer = new BinaryComparer();
            CompareHelper.Compare(comparer, outFileName, standardFileName);
            RemoveFile(outFileName);
        }

        /// <summary>
        /// Blobses the filtering.
        /// </summary>
        [Test]
        public void BlobsFiltering()
        {
            var fileName = "sample2.jpg";
            var inputFileName = Path.Combine(this.ImagesPath, fileName);
            var outFileName = this.GetOutFileName("blob.png");
            var standardFileName = this.GetStandardFileName("blob.png");
            var settings = new BlobCounterSettings
            {
                MinHeight = 90,
                MinWidth = 90, 
                CoupledSizeFiltering = true
            };

            using (var image = (RasterImage)Image.Load(inputFileName))
            {
                image.BlobsFiltering(settings, image.Bounds);
                image.Save(outFileName);
            }

            var comparer = new BinaryComparer();
            CompareHelper.Compare(comparer, outFileName, standardFileName);
            RemoveFile(outFileName);
        }

        #endregion
    }
}