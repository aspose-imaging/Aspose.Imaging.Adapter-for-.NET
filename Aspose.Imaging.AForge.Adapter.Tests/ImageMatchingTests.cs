using Aspose.Imaging.Pdf.Adapter.Tests.ImageComparers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.Imaging.AForge.Adapter.Tests
{
    using ImageMatch;

    /// <summary>
    /// The image matching tests
    /// </summary>
    /// <seealso cref="Aspose.Imaging.AForge.Adapter.Tests.AForgeTestsBase" />
    internal class ImageMatchingTests : AForgeTestsBase
    {
        /// <summary>
        /// Exhaustives the template matching test.
        /// </summary>
        [Test]
        public void ExhaustiveTemplateMatchingTest()
        {
            var fileName = "polygons.cdr.png";
            var templateName = "template.png";
            var inputFileName = Path.Combine(this.ImagesPath, fileName);
            var inputTemplate = Path.Combine(this.ImagesPath, templateName);
            using (var image = (RasterImage)Image.Load(inputFileName))
            using (var tmp = (RasterImage)Image.Load(inputTemplate))
            {
               var similarity = image.ExhaustiveTemplateMatching(0.5f, tmp);
               Assert.GreaterOrEqual(similarity, 0.98f);
            }
        }

        /// <summary>
        /// Exhaustives the block matching test.
        /// </summary>
        [Test]
        public void ExhaustiveBlockMatchingTest()
        {
            var fileName = "polygons.cdr2.png";
            var templateName = "template3.png";
            var inputFileName = Path.Combine(this.ImagesPath, fileName);
            var inputTemplate = Path.Combine(this.ImagesPath, templateName);
            using (var image = (RasterImage)Image.Load(inputFileName))
            using (var tmp = (RasterImage)Image.Load(inputTemplate))
            {
                var settings = new ExhaustiveBlockMatchingSettings()
                {
                    DifferenceThreshold = 30,
                    GeometricThreshold = 18,
                    BlockSize = 1,
                    SearchRadius = 12
                };

                var matches = image.ExhaustiveBlockMatching(tmp, settings);
                var m = matches.MaxBy(m => m.Similarity);
                var expectedPoint = new Point(338, 531);
                Assert.NotNull(m);
                Assert.AreEqual(expectedPoint, m.SourcePoint);
            }
        }
    }
}
