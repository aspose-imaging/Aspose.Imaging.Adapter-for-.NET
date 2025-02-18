// -----------------------------------------------------------------------------------------------------------
//   <copyright file="SpeededUpRobustFeaturesDetectorTest.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="13.11.2024 11:58">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Accord.Adapter.Tests
{
    using Adatpter.Tests.Core.ImageComparers;
    using ComputerVision.Surf;
    using Pdf.Adapter.Tests.ImageComparers;
    using Surf;

    public class SpeededUpRobustFeaturesDetectorTests : AccordTestsBase
    {
        #region Methods

        [Test]
        public void SurfTest()
        {
            var fileName = "polygons.cdr.png";
            var inputFileName = Path.Combine(this.ImagesPath, fileName);
            var outFileName = this.GetOutFileName($"{fileName}.dat");
            var standardFileName = this.GetStandardFileName($"{fileName}.dat");
            using (var image = (RasterImage)Image.Load(inputFileName))
            {
                var points = image.SpeededUpRobustFeaturesDetector(image.Bounds, new SpeededUpRobustFeaturesDetectorProperties());
                this.SaveDescriptors(points, outFileName);
            }

            var comparer = new BinaryComparer();
            CompareHelper.Compare(comparer, outFileName, standardFileName);
            RemoveFile(outFileName);
        }

        /// <summary>
        /// Saves the descriptors.
        /// </summary>
        /// <param name="keyPoints">The key points.</param>
        /// <param name="fileName">Name of the file.</param>
        private void SaveDescriptors(List<SurfKeyPoint> keyPoints, string fileName)
        {
            using var fs = File.Create(fileName);
            foreach (var keyPoint in keyPoints)
            {
                ConvertHelper.DoubleArrayToStream(keyPoint.Descritor, fs);
            }
        }

        #endregion
    }
}