using Aspose.Imaging.Accord.Adapter.ComputerVision.Surf;
using Aspose.Imaging.Accord.Adapter.Surf;
using Aspose.Imaging.Pdf.Adapter.Tests.ImageComparers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.Imaging.Accord.Adapter.Tests
{
    using Adatpter.Tests.Core.ImageComparers;
    using ComputerVision.Glcm;

    public class GrayLevelCooccurrenceMatrixTests : AccordTestsBase
    {
        [Test]
        public void GlcmTest()
        {
            var fileName = "polygons.cdr.png";
            var inputFileName = Path.Combine(this.ImagesPath, fileName);
            var outFileName = this.GetOutFileName($"{fileName}.dat");
            var standardFileName = this.GetStandardFileName($"{fileName}.dat");
            using (var image = (RasterImage)Image.Load(inputFileName))
            {
                var points = image.GrayLevelCooccurrenceMatrix(image.Bounds, new GrayLevelCooccurrenceMatrixProperties());
                this.SaveMatrix(points, outFileName);
            }

            var comparer = new BinaryComparer();
            CompareHelper.Compare(comparer, outFileName, standardFileName);
        }

        private void SaveMatrix(double[,] matrix, string fileName)
        {
            using var fs = File.Create(fileName);
            foreach (var value in matrix)
            {
                var bytes = BitConverter.GetBytes(value);
                fs.Write(bytes);
            }
        }
    }
}
