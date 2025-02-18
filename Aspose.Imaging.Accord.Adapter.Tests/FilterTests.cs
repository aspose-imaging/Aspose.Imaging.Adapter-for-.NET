// -----------------------------------------------------------------------------------------------------------
//   <copyright file="FilterTestcs.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="15.11.2024 11:22">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Accord.Adapter.Tests
{
    using Adatpter.Tests.Core.ImageComparers;
    using FiltersProperties;
    using Pdf.Adapter.Tests.ImageComparers;

    /// <summary>
    ///     The filter tests
    /// </summary>
    /// <seealso cref="Aspose.Imaging.Accord.Adapter.Tests.AccordTestsBase" />
    public class FilterTests : AccordTestsBase
    {
        #region Methods

        [Test]
        public void DoGTest()
        {
            this.FilterTest(new DifferenceOfGaussiansProperties(){WindowSize1 = 10, Sigma1 = 5.6, WindowSize2 = 1, Sigma2 = 0.7}, "lena.jpg");
        }

        /// <summary>
        ///     Niblacks the threshold test.
        /// </summary>
        [Test]
        public void NiblackThresholdTest()
        {
            this.FilterTest(new NiblackThresholdProperties(), "lena.jpg");
        }

        /// <summary>
        ///     Saulovas the threshold test.
        /// </summary>
        [Test]
        public void SaulovaThresholdTest()
        {
            this.FilterTest(new SaulovaThresholdProperties(), "lena.jpg");
        }

        [Test]
        public void GaborFilterTest()
        {
            this.FilterTest(new GaborFilterProperties(), "lines.png");
        }

        /// <summary>
        ///     Thresholds the test.
        /// </summary>
        /// <param name="properties">The properties.</param>
        private void FilterTest(IFilterProperties properties, string fileName)
        {
            var inputFileName = Path.Combine(this.ImagesPath, fileName);
            var outFileName = this.GetOutFileName($"{fileName}.png");
            var standardFileName = this.GetStandardFileName($"{fileName}.png");
            using (var image = (RasterImage)Image.Load(inputFileName))
            {
                image.ApplyFilter(image.Bounds, properties);
                image.Save(outFileName);
            }

            var comparer = new BinaryComparer();
            CompareHelper.Compare(comparer, outFileName, standardFileName);
            RemoveFile(outFileName);
        }

        #endregion
    }
}