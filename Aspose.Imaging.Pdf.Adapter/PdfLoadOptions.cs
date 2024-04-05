// -----------------------------------------------------------------------------------------------------------
//   <copyright file="PdfLoadOptions.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="20.03.2024 13:58">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Pdf.Adapter
{
    /// <summary>
    ///     The Pdf load options
    /// </summary>
    /// <seealso cref="Aspose.Imaging.LoadOptions" />
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
        /// <returns></returns>
        public static PdfLoadOptions Create()
        {
            return instance ?? (instance = new PdfLoadOptions());
        }

        /// <summary>
        ///     The instance
        /// </summary>
        private static PdfLoadOptions instance;

        #endregion
    }
}