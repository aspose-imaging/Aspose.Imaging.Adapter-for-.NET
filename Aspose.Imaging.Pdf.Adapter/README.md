# Aspose.Imaging.Pdf.Adapter for .NET

**Aspose.Imaging.Pdf.Adapter for .NET** Combines 2 Aspose products [Aspose.Imaging for .NET](https://products.aspose.com/imaging/net/) and [Aspose.Pdf for .NET](https://products.aspose.com/pdf/net/), this allows you to use the functions of both libraries as a single whole and expand conversion between formats. This adapter supports conversion emf, wmf, cdr, psd, tiff, webp, [etc.](https://docs.aspose.com/imaging/net/supported-file-formats/)  formats to formats supported by the **Aspose.Pdf** library, such as pdf (with more advanced settings), docx, xlsx, html, pptx.
And also conversion PDF format to all formats supported by the **Aspose.Imaging** library, such as Emf, Wmf, J2k, Webp, Tiff, [etc.](https://docs.aspose.com/imaging/net/supported-file-formats/) 

## Platform Independence

Aspose.Imaging.Pdf.Adapter for .NET can be used to develop applications on Windows Desktop (x86, x64), Windows Server (x86, x64), Windows Azure, Windows Embedded (CE 6.0 R2), as well as Linux x64. The supported platforms include Net7.0.

## New Features & Enhancements in Version 24.4

First release!

## Getting Started with Aspose.Imaging.Pdf.Adapter for .NET

Are you ready to give Aspose.Imaging.Pdf.Adapter for .NET a try? Simply execute 

```
Install-Package Aspose.Imaging.Pdf.Adapter
```

from Package Manager Console in Visual Studio to fetch the NuGet package. If you already have Aspose.Imaging.Pdf.Adapter for .NET and want to upgrade the version, please execute 

```
Update-Package Aspose.Imaging.Pdf.Adapter
```

 to get the latest version.

## Usage example

### Conversion Cdr file to Pdf format(Pdf1A) (Aspose.Imaging->Aspose.Pdf)

```csharp
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Pdf.Adapter;
using Aspose.Imaging.Pdf.Adapter.ImageOptions;
using Aspose.Pdf;

// Register adapter - must be called once to initialize the library
// it is possible not to explicitly call registration if there were previous calls
// PdfImage.SetLicense, PdfLoadOptions.Create, ImageOptionsExt
PdfImage.Register();

//if you have a license
PdfImage.SetLicense("license.lic");

using var image = Aspose.Imaging.Image.Load(@"example.cdr");
image.Save("result.pdf", new ImageOptionsExt<PdfSaveOptionsExt>()
{
    SaveOptions = new PdfSaveOptionsExt() {FormatConversionOptions = new PdfFormatConversionOptions(PdfFormat.PDF_A_1A)},
    VectorRasterizationOptions = new CdrRasterizationOptions()
    {
        PageSize = image.Size
    }
});
```


### Conversion Cdr file to Docx format (Aspose.Imaging->Aspose.Pdf)

```csharp
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Pdf.Adapter;
using Aspose.Imaging.Pdf.Adapter.ImageOptions;
using Aspose.Pdf;

// Register adapter - must be called once to initialize the library
// it is possible not to explicitly call registration if there were previous calls
// PdfImage.SetLicense, PdfLoadOptions.Create, ImageOptionsExt
PdfImage.Register();

//if you have a license
PdfImage.SetLicense("license.lic");
using var image = Aspose.Imaging.Image.Load(@"example.cdr");
image.Save(@"result.docx", new ImageOptionsExt<DocSaveOptions>
{
    SaveOptions = new DocSaveOptions
    {
        Format = DocSaveOptions.DocFormat.DocX
    },
    VectorRasterizationOptions = new CdrRasterizationOptions
    {
        PageSize = image.Size
    }
});
```

### Conversion Pdf file to webp format (Aspose.Pdf->Aspose.Imaging)

```csharp
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Pdf.Adapter;

// Register adapter - must be called once to initialize the library
// it is possible not to explicitly call registration if there were previous calls
// PdfImage.SetLicense, PdfLoadOptions.Create, ImageOptionsExt
PdfImage.Register();

//if you have a license
PdfImage.SetLicense("license.lic");
using var image = Aspose.Imaging.Image.Load("example.pdf"));
image.Save("result.webp", new WebPOptions());
```