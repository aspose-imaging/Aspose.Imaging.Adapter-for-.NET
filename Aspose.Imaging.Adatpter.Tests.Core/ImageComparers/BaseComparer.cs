// -----------------------------------------------------------------------------------------------------------
//   <copyright file="BaseComparer.cs" company="Aspose Pty Ltd" author="" date="13.03.2024 13:40">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Pdf.Adapter.Tests.ImageComparers
{
    using System.IO;

    /// <summary>
    /// The base comparer
    /// </summary>
    public abstract class BaseComparer
    {
        #region Methods

        /// <summary>
        /// Compares the files.
        /// </summary>
        /// <param name="compareFilePath">The compare file path.</param>
        /// <param name="standardFilePath">The standard file path.</param>
        /// <returns></returns>
        public CompareResult CompareFiles(string compareFilePath, string standardFilePath)
        {
            using (var fs1 = new FileStream(compareFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var fs2 = new FileStream(standardFilePath, FileMode.Open, FileAccess.Read))
                {
                    return this.CompareStreams(fs1, fs2);
                }
            }
        }

        /// <summary>
        /// Compares the streams.
        /// </summary>
        /// <param name="stream1">The stream1.</param>
        /// <param name="stream2">The stream2.</param>
        /// <returns></returns>
        public abstract CompareResult CompareStreams(Stream stream1, Stream stream2);

        #endregion
    }

    /// <summary>
    /// The compare Result
    /// </summary>
    public class CompareResult
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CompareResult"/> class.
        /// </summary>
        /// <param name="successfull">if set to <c>true</c> [successfull].</param>
        /// <param name="message">The message.</param>
        public CompareResult(bool successfull, string message)
        {
            this.Successfull = successfull;
            this.Message = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompareResult" /> class.
        /// </summary>
        public CompareResult()
        {
            this.Successfull = true;
            this.Message = string.Empty;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether this <see cref="CompareResult"/> is successfull.
        /// </summary>
        /// <value>
        ///   <c>true</c> if successfull; otherwise, <c>false</c>.
        /// </value>
        public bool Successfull { get; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }

        #endregion
    }
}