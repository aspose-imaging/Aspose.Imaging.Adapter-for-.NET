// -----------------------------------------------------------------------------------------------------------
//   <copyright file="CompareHelper.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="15.03.2024 09:28">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Adatpter.Tests.Core.ImageComparers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Pdf.Adapter.Tests.ImageComparers;

    /// <summary>
    ///     The compare helper
    /// </summary>
    public static class CompareHelper
    {
        /// <summary>
        /// The PDF exclude list
        /// </summary>
        public static readonly List<string> PdfExcludeList = new List<string>()
        {
            "<</CreationDate",
            "<xmp:CreateDate>",
            "<xmp:ModifyDate>",
            "<</Root",
            "<</Type/Font/Subtype",
            "<</Filter/FlateDecode/Length"
        };


        #region Methods

        /// <summary>
        /// Compares the specified comparer.
        /// </summary>
        /// <param name="comparer">The comparer.</param>
        /// <param name="compareFilePath">The compare file path.</param>
        /// <param name="standardFilePath">The standard file path.</param>
        /// <exception cref="System.Exception"></exception>
        public static void Compare(BaseComparer comparer, string compareFilePath, string standardFilePath)
        {
            if (!(comparer is BinaryComparer))
            {
                var bc = new BinaryComparer();
                var res = bc.CompareFiles(compareFilePath, standardFilePath);
                if (res.Successfull)
                {
                    return;
                }
            }

            var result = comparer.CompareFiles(compareFilePath, standardFilePath);
            if (!result.Successfull)
            {
                var fallbacks = GetFallbacks(standardFilePath);
                foreach (var fallback in fallbacks)
                {
                    result = comparer.CompareFiles(compareFilePath, fallback);
                    if (result.Successfull)
                    {
                        return;
                    }
                }

                if (!result.Successfull)
                {
                    throw new Exception(result.Message);
                }
            }
        }

  
        /// <summary>
        /// Checks the fallback.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        private static string[] GetFallbacks(string fileName)
        {
            var filePath = Path.GetDirectoryName(fileName);
            var name = Path.GetFileNameWithoutExtension(fileName);
            var ext = Path.GetExtension(fileName);
            return Directory.GetFiles(filePath, $"{name}_v*{ext}");
        }

        #endregion
    }
}