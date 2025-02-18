using Aspose.Imaging.Pdf.Adapter.Tests.ImageComparers;


namespace Aspose.Imaging.Accord.Adapter.Tests
{
    using Adatpter.Tests.Core.ImageComparers;
    using ComputerVision.FeatureExtractor;
    using Openize.Accord.Imaging.Interest_Points.Haralick;

    /// <summary>
    /// The feature extractor tests
    /// </summary>
    /// <seealso cref="Aspose.Imaging.Accord.Adapter.Tests.AccordTestsBase" />
    public class FeatureExtractorTests : AccordTestsBase
    {
        /// <summary>
        /// Hogs the test.
        /// </summary>
        [Test]
        public void HogTest()
        {
            var fileName = "lena.jpg";
            var properties = new HistogramsOfOrientedGradientsProperties();
            FeatureExtractorTest(properties, fileName);
        }

        /// <summary>
        /// Haralicks the test.
        /// </summary>
        [Test]
        public void HaralickTest()
        {
            var fileName = "wood.bmp";
            var properties = new HaralickProperties
            {
                Mode = HaralickMode.AverageWithRange,
                CellSize = 0
            };

            FeatureExtractorTest(properties, fileName);
        }

        /// <summary>
        /// Features the extractor test.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <param name="fileName">Name of the file.</param>
        private void FeatureExtractorTest(IFeatureExtractorProperties properties, string fileName)
        {
       
            var inputFileName = Path.Combine(this.ImagesPath, fileName);
            var outFileName = this.GetOutFileName($"{fileName}.dat");
            var standardFileName = this.GetStandardFileName($"{fileName}.dat");
            using (var image = (RasterImage)Image.Load(inputFileName))
            {

                var descriptors = image.FeatureExtracor(image.Bounds, properties);
                this.SaveDescriptors(descriptors, outFileName);
            }

            var comparer = new BinaryComparer();
            CompareHelper.Compare(comparer, outFileName, standardFileName);
            RemoveFile(outFileName);
        }

        /// <summary>
        /// Saves the descriptors.
        /// </summary>
        /// <param name="descriptors">The descriptors.</param>
        /// <param name="fileName">Name of the file.</param>
        private void SaveDescriptors(List<double[]> descriptors, string fileName)
        {
            using var fs = File.Create(fileName);
            foreach (var descriptor in descriptors)
            {
                ConvertHelper.DoubleArrayToStream(descriptor, fs);
            }
        }
    }
}
