// -----------------------------------------------------------------------------------------------------------
//   <copyright file="PdfTestBase.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="27.08.2024 12:20">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Pdf.Adapter.Tests
{
    using Adatpter.Tests.Core;

    /// <summary>
    /// The Pdf Test base class
    /// </summary>
    /// <seealso cref="Aspose.Imaging.Adatpter.Tests.Core.AdapterTestsBase" />
    public class PdfTestsBase : AdapterTestsBase
    {
        #region Constructors

        public PdfTestsBase() : base("Aspose.Imaging.Pdf.Adapter.Tests", "Aspose.Total.Product.Family.lic")
        {
        }

        #endregion

        #region Methods

        protected override void ApplyLicense(string licensePath)
        {
            var licPdf = new Aspose.Pdf.License();
            licPdf.SetLicense(licensePath);
            var licImaging = new License();
            licImaging.SetLicense(licensePath);
        }

        #endregion
    }
}