// -----------------------------------------------------------------------------------------------------------
//   <copyright file="AForgeTestsBase.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="27.08.2024 12:54">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.AForge.Adapter.Tests
{
    using Adatpter.Tests.Core;

    /// <summary>
    ///     The forge tests base class
    /// </summary>
    /// <seealso cref="Aspose.Imaging.Adatpter.Tests.Core.AdapterTestsBase" />
    public class AForgeTestsBase : AdapterTestsBase
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="AForgeTestsBase" /> class.
        /// </summary>
        public AForgeTestsBase() : base("Aspose.Imaging.AForge.Adapter.Tests", "Aspose.Total.Product.Family.lic")
        {
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Applies the license.
        /// </summary>
        /// <param name="licensePath">The license path.</param>
        protected override void ApplyLicense(string licensePath)
        {
            var licImaging = new License();
            licImaging.SetLicense(licensePath);
        }

        #endregion
    }
}