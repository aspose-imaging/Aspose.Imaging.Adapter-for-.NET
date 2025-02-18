// -----------------------------------------------------------------------------------------------------------
//   <copyright file="AccordTestsBase.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="11.11.2024 14:17">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Accord.Adapter.Tests
{
    using Adatpter.Tests.Core;

    /// <summary>
    /// The Accord test base
    /// </summary>
    /// <seealso cref="Aspose.Imaging.Adatpter.Tests.Core.AdapterTestsBase" />
    public class AccordTestsBase : AdapterTestsBase
    {
        #region Constructors

        public AccordTestsBase() : base("Aspose.Imaging.Accord.Adapter.Tests", "Aspose.Total.Product.Family.lic")
        {
        }

        #endregion

        #region Methods

        protected override void ApplyLicense(string licensePath)
        {
            var licImaging = new License();
            licImaging.SetLicense(licensePath);

            var licDrawing = new System.Drawing.AsposeDrawing.License();
            licDrawing.SetLicense(licensePath);
        }

        #endregion
    }
}