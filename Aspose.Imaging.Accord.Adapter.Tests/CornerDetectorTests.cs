using Aspose.Imaging.Pdf.Adapter.Tests.ImageComparers;

namespace Aspose.Imaging.Accord.Adapter.Tests
{
    using Adatpter.Tests.Core.ImageComparers;
    using ComputerVision.Corners;

    public class CornerDetectorTests: AccordTestsBase
    {

        /// <summary>
        /// Cornerses the detector harris test.
        /// </summary>
        [Test]
        public void CornersDetectorHarrisTest()
        {
           CornersDetectorTest(new HarrisCornersDetectorProperties(),"harris");
        }

        /// <summary>
        /// Cornerses the detector fast test.
        /// </summary>
        [Test]
        public void CornersDetectorFastTest()
        {
            CornersDetectorTest(new FastCornersDetectorProperties(), "fast");
        }

        /// <summary>
        /// Cornerses the detector test.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <param name="additionalName">Name of the additional.</param>
        public void CornersDetectorTest(ICornersDetectorProperties properties, string additionalName)
        {
            var fileName = "polygons.cdr.png";
            var inputFileName = Path.Combine(this.ImagesPath, fileName);
            var outFileName = this.GetOutFileName($"{fileName}_{additionalName}.png");
            var standardFileName = this.GetStandardFileName($"{fileName}_{additionalName}.png");
            using (var image = (RasterImage)Image.Load(inputFileName))
            {
                var points = image.CornerDetector(image.Bounds, properties);
                DrawHelper.AddPointsToImage(image, points);
                image.Save(outFileName);
            }

            var comparer = new BinaryComparer();
            CompareHelper.Compare(comparer, outFileName, standardFileName);
            RemoveFile(outFileName);
        }

       
    }
}