// -----------------------------------------------------------------------------------------------------------
//   <copyright file="FastRetinaKeypointDetector.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="13.11.2024 11:20">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Accord.Adapter.Tests
{
    using ComputerVision.Corners;

    public class FastRetinaKeypointDetectorTests : AccordTestsBase
    {
        #region Methods

        [Test]
        public void FreakTest()
        {
            var fileName = "polygons.cdr.png";
            var inputFileName = Path.Combine(this.ImagesPath, fileName);
            var expectedCount = 201;
            var expectedBase64Point0 = "BSiEkACIAAERSBgAASECEBEACICAQJUACEAhgQDAQAIAAkAYBWEwEAS1AERCBQAQAQECABRSGAHZJGNIDAEBAg==";
            ;
            using (var image = (RasterImage)Image.Load(inputFileName))
            {
                var points = image.FastRetinaKeypointDetector(image.Bounds, new HarrisCornersDetectorProperties());
                Assert.AreEqual(expectedCount, points.Count);
                Assert.AreEqual(expectedBase64Point0, points[0].ToBase64());
            }
        }

        #endregion
    }
}