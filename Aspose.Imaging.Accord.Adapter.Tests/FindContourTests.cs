// -----------------------------------------------------------------------------------------------------------
//   <copyright file="FindContourTest.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="13.11.2024 14:28">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

using Aspose.Imaging.Pdf.Adapter.Tests.ImageComparers;

namespace Aspose.Imaging.Accord.Adapter.Tests
{
    using Adatpter.Tests.Core.ImageComparers;

    /// <summary>
    /// The find contour test
    /// </summary>
    public class FindContourTests :AccordTestsBase
    {
        #region Methods

        /// <summary>
        /// Finds the contour test.
        /// </summary>
        [Test]
        public void FindContourTest()
        {
            var fileName = "sample-black.bmp";
            var inputFileName = Path.Combine(this.ImagesPath, fileName);
            var outFileName = this.GetOutFileName($"{fileName}.png");
            var standardFileName = this.GetStandardFileName($"{fileName}.png");
            using (var image = (RasterImage)Image.Load(inputFileName))
            {
                var points = image.FindContour(image.Bounds);
                DrawHelper.AddPointsToImage(image, points);
                image.Save(outFileName);
            }

            var comparer = new BinaryComparer();
            CompareHelper.Compare(comparer, outFileName, standardFileName);
            RemoveFile(outFileName);
        }

        #endregion
    }
}