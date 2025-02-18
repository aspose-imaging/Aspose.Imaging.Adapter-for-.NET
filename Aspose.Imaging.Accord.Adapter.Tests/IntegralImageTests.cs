// -----------------------------------------------------------------------------------------------------------
//   <copyright file="IntegralImageTest.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="18.11.2024 16:09">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------
namespace Aspose.Imaging.Accord.Adapter.Tests
{
    public class IntegralImageTests : AccordTestsBase
    {
        [Test]
        public void IntegralImageTest()
        {
            var fileName = "lena512.bmp";
            var inputFileName = Path.Combine(this.ImagesPath, fileName);
            using (var image = (RasterImage)Image.Load(inputFileName))
            {
                var integralImage = image.GetIntegralImage(image.Bounds, true);
                var expectedSum = 1759544;
                var expectedSum2 = 229295032;
                var expectedSumT = -594313;
                var sum = integralImage.GetSum(34, 50, 94, 155);
                var sum2 = integralImage.GetSum2(34, 50, 94, 155);
                var sumT = integralImage.GetSumT(34, 50, 94, 155);

                Assert.AreEqual(expectedSum, sum);
                Assert.AreEqual(expectedSum2, sum2);
                Assert.AreEqual(expectedSumT, sumT);
            }

        }
    }
}