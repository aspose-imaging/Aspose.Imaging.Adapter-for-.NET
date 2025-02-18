// -----------------------------------------------------------------------------------------------------------
//   <copyright file="PdfLoadOptions.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="20.03.2024 13:58">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Pdf.Adapter
{
    /// <summary>
    ///     The Pdf load options of <see href="https://reference.aspose.com/imaging/net/aspose.imaging/loadoptions/">LoadOptions</see>
    /// </summary>

    public class PdfLoadOptions : LoadOptions
    {
        #region Constructors

        /// <summary>
        /// Initializes the <see cref="PdfLoadOptions"/> class.
        /// </summary>
        static PdfLoadOptions()
        {
            PdfImage.Register();
        }

        /// <summary>
        ///     Prevents a default instance of the <see cref="PdfLoadOptions" /> class from being created.
        /// </summary>
        private PdfLoadOptions()
        {
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns><see cref="PdfLoadOptions"/>The Pdf load options</returns>
        public static PdfLoadOptions Create()
        {
            return instance ?? (instance = new PdfLoadOptions());
        }

        /// <summary>
        ///     <see cref="PdfLoadOptions">The instance</see>
        /// </summary>
        private static PdfLoadOptions instance;

        #endregion
    }
}