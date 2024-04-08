// -----------------------------------------------------------------------------------------------------------
//   <copyright file="PdfTests.cs" company="Aspose Pty Ltd" author="" date="13.03.2024 13:40">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Pdf.Adapter.Tests;

using Aspose.Pdf;
using ImageComparers;
using ImageOptions;
using Imaging.ImageOptions;
using NUnit.Framework;
using Color = Imaging.Color;
using Image = Imaging.Image;

/// <summary>
/// The pdf tests
/// </summary>
/// <seealso cref="Aspose.Imaging.Pdf.Adapter.Tests.PdfTestsBase" />
public class Tests : PdfTestsBase
{
    #region Fields

    /// <summary>
    /// The ms exclude
    /// </summary>
    private readonly List<string> msExclude = new()
    {
        "<dcterms:modified"
    };

    #endregion

    #region Methods

    /// <summary>
    /// The files
    /// </summary>
    public static string[] Files =
    {
        "1.dng", "ball.png", "Animation.gif", "Animation.webp", "MultiframePage1.dicom", "sample.tif", "sample.djvu", "MultiPage.cdr",
        "MultiPage.cmx", "sample.odg", "sample.otg", "Sample.eps", "eye.wmf", "Input.jp2", "Sample.svg",
        "TestEmfPlusFigures.emf", "testMedium.j2k", "tiger.bmp", "elephant.png"
    };

    /// <summary>
    /// Exports to PDF.
    /// </summary>
    /// <param name="fileName">Name of the file.</param>
    [Test]
    [TestCaseSource(typeof(Tests), nameof(Files))]
    public void ExportToPdf(string fileName)
    {
        if (!IsLicensed)
        {
            var excludes = new List<string>()
            {
                "Animation.gif",
                "Animation.webp",
                "MultiframePage1.dicom",
                "sample.djvu",
                "elephant.png"
            };

            if (excludes.Any(n => n == fileName))
            {
                return;
            }
        }
        this.Export(fileName, new TextComparer(CompareHelper.PdfExcludeList), new ImageOptionsExt<PdfSaveOptionsExt>
        {
            SaveOptions = new PdfSaveOptionsExt
            {
                FormatConversionOptions = new PdfFormatConversionOptions(PdfFormat.PDF_A_1A)
            }
        }, "pdf");
    }

    /// <summary>
    /// Exports to HTML.
    /// </summary>
    /// <param name="fileName">Name of the file.</param>
    [Test]
    [TestCaseSource(typeof(Tests), nameof(Files))]
    public void ExportToHtml(string fileName)
    {
        this.Export(fileName, new TextComparer(new List<string>()), new ImageOptionsExt<HtmlSaveOptions>
        {
            SaveOptions = new HtmlSaveOptions
            {
                RasterImagesSavingMode = HtmlSaveOptions.RasterImagesSavingModes.AsEmbeddedPartsOfPngPageBackground,
                FontSavingMode = HtmlSaveOptions.FontSavingModes.DontSave,
                PartsEmbeddingMode = HtmlSaveOptions.PartsEmbeddingModes.EmbedAllIntoHtml
            }
        }, "html");
    }

    /// <summary>
    /// Exports to document.
    /// </summary>
    /// <param name="fileName">Name of the file.</param>
    [Test]
    [TestCaseSource(typeof(Tests), nameof(Files))]
    public void ExportToDoc(string fileName)
    {
        this.Export(fileName, new ZipComparer(this.msExclude), new ImageOptionsExt<DocSaveOptions>
        {
            SaveOptions = new DocSaveOptions
            {
                Format = DocSaveOptions.DocFormat.DocX
            }
        }, "docx");
    }

    /// <summary>
    /// Exports to excel.
    /// </summary>
    /// <param name="fileName">Name of the file.</param>
    [Test]
    [TestCaseSource(typeof(Tests), nameof(Files))]
    public void ExportToExcel(string fileName)
    {
        this.Export(fileName, new ZipComparer(this.msExclude), new ImageOptionsExt<ExcelSaveOptions>(), "xlsx");
    }

    /// <summary>
    /// Exports to PPTX.
    /// </summary>
    /// <param name="fileName">Name of the file.</param>
    [Test]
    [TestCaseSource(typeof(Tests), nameof(Files))]
    public void ExportToPptx(string fileName)
    {
        this.Export(fileName, new ZipComparer(this.msExclude), new ImageOptionsExt<PptxSaveOptions>(), "pptx");
    }

    /// <summary>
    /// Imports from PDF.
    /// </summary>
    /// <param name="fileFormat">The file format.</param>
    /// <exception cref="System.Exception"></exception>
    [Test]
    [TestCase(FileFormat.Svg)]
    //  [TestCase(FileFormat.Dxf)]
    //  [TestCase(FileFormat.Emf)]
    [TestCase(FileFormat.Wmf)]
    [TestCase(FileFormat.Tiff)]
    [TestCase(FileFormat.Png)]
    public void ImportFromPdf(FileFormat fileFormat)
    {
        var fileName = "test.pdf";
        var options = FileOptions.Instance.GetFileOption(fileFormat);
        var inputFileName = Path.Combine(ImagesPath, fileName);
        var outFileName = GetOutFileName(fileName + options.FileExt);
        var standardFileName = GetStandardFileName(fileName + options.FileExt);

        using (var image = Image.Load(inputFileName, PdfLoadOptions.Create()))
        {
            
            image.Save(outFileName, options.ImageOptions);
        }


        if (fileFormat == FileFormat.Wmf)
        {
            using (var image = Image.Load(outFileName))
            {
                image.Save(outFileName+".png", new PngOptions());
            }

            RemoveFile(outFileName);
            outFileName += ".png";
            standardFileName += ".png";
        }

        BaseComparer comparer = fileFormat==FileFormat.Svg? new XmlComparer(new List<string>()): new BinaryComparer();
        CompareHelper.Compare(comparer, outFileName, standardFileName);
        RemoveFile(outFileName);
    }


    /// <summary>
    /// Exports the specified file name.
    /// </summary>
    /// <param name="fileName">Name of the file.</param>
    /// <param name="comparer">The comparer.</param>
    /// <param name="options">The options.</param>
    /// <param name="ext">The ext.</param>
    /// <exception cref="System.Exception"></exception>
    private void Export(string fileName, BaseComparer comparer, ImageOptionsBase options, string ext)
    {
        var inputFileName = Path.Combine(ImagesPath, fileName);
        var outFileName = GetOutFileName($"{fileName}.{ext}");
        var standardFileName = GetStandardFileName($"{fileName}.{ext}");
        using (var image = Image.Load(inputFileName))
        {
            if (image is VectorImage)
            {
                options.VectorRasterizationOptions =
                    (VectorRasterizationOptions)image.GetDefaultOptions(new object[] { Color.White, image.Width, image.Height });
            }

            image.Save(outFileName, options);
        }

        CompareHelper.Compare(comparer, outFileName, standardFileName);
        RemoveFile(outFileName);
    }
    
    #endregion
}