// -----------------------------------------------------------------------------------------------------------
//   <copyright file="ZipComparer.cs" company="Aspose Pty Ltd" author="" date="13.03.2024 13:40">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Pdf.Adapter.Tests.ImageComparers
{
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;

    /// <summary>
    /// The zip comparer
    /// </summary>
    /// <seealso cref="Aspose.Imaging.Pdf.Adapter.Tests.ImageComparers.BaseComparer" />
    public class ZipComparer : BaseComparer
    {
        #region Fields

        /// <summary>
        ///     The exclude lines
        /// </summary>
        private readonly List<string> excludeLines;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="TextComparer" /> class.
        /// </summary>
        /// <param name="excludeLines">The exclude lines.</param>
        public ZipComparer(List<string> excludeLines)
        {
            this.excludeLines = excludeLines;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Compares the streams.
        /// </summary>
        /// <param name="stream1">The stream1.</param>
        /// <param name="stream2">The stream2.</param>
        /// <returns></returns>
        public override CompareResult CompareStreams(Stream stream1, Stream stream2)
        {
            var binaryComparer = new BinaryComparer();
            var xmlComparer = new XmlComparer(this.excludeLines);
            binaryComparer.CheckLength = false;
            using (var archive1 = new ZipArchive(stream1))
            using (var archive2 = new ZipArchive(stream2))
            {
                foreach (var entry in archive1.Entries)
                {
                    var name = entry.FullName;
                    using (var strm1 = entry.Open())
                    using (var strm2 = this.OpenFileFromArchive(archive2, name))
                    {
                        BaseComparer comparer = Path.GetExtension(name) == ".xml" ? xmlComparer : binaryComparer;
                        var result = comparer.CompareStreams(strm1, strm2);
                        if (!result.Successfull)
                        {
                            result.Message += $"\n file name in archive: {name}";
                            return result;
                        }
                    }
                }
            }

            return new CompareResult();
        }

        /// <summary>
        /// Opens the file from archive.
        /// </summary>
        /// <param name="archive">The archive.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        private Stream OpenFileFromArchive(ZipArchive archive, string fileName)
        {
            var entry = archive.Entries.FirstOrDefault(e => e.FullName == fileName);
            if (entry != null)
            {
                return entry.Open();
            }

            return null;
        }

        #endregion
    }
}