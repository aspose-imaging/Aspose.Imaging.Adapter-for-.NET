// -----------------------------------------------------------------------------------------------------------
//   <copyright file="DocumentSkewCheckerTests.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="04.09.2024 11:43">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

using Aspose.Imaging.Pdf.Adapter.Tests.ImageComparers;

namespace Aspose.Imaging.AForge.Adapter.Tests
{
    using Adatpter.Tests.Core.ImageComparers;

    /// <summary>
    /// The document skew checker tests
    /// </summary>
    /// <seealso cref="Aspose.Imaging.AForge.Adapter.Tests.AForgeTestsBase" />
    public class DocumentSkewCheckerTests : AForgeTestsBase
    {
        /// <summary>
        /// Documents the skew checker test.
        /// </summary>
        [Test]
        [Ignore(("SkewChecker already has an imaging"))]
        public void DocumentSkewCheckerTest()
        {
            var fileName = "document.png";
            var inputFileName = Path.Combine(this.ImagesPath, fileName);
            var outFileName = this.GetOutFileName("document_skew.png");
            var standardFileName = this.GetStandardFileName("document_skew.png");
            using (var image = (RasterImage)Image.Load(inputFileName))
            {
               // var angle = image.DocumentSkewChecker(image.Bounds);
               // image.Rotate((float)angle, true, Color.White);
                image.Save(outFileName);
            }

            var comparer = new BinaryComparer();
            CompareHelper.Compare(comparer, outFileName, standardFileName);
            RemoveFile(outFileName);
        }
    }
}