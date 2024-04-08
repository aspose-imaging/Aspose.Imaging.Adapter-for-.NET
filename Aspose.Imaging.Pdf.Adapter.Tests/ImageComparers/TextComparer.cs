// -----------------------------------------------------------------------------------------------------------
//   <copyright file="TextComparer.cs" company="Aspose Pty Ltd" author="" date="13.03.2024 13:40">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Pdf.Adapter.Tests.ImageComparers
{
    using System.Text;
    using SeekOrigin = System.IO.SeekOrigin;

    /// <summary>
    /// The text comparer
    /// </summary>
    /// <seealso cref="Aspose.Imaging.Pdf.Adapter.Tests.ImageComparers.BaseComparer" />
    internal class TextComparer : BaseComparer
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
        public TextComparer(List<string> excludeLines)
        {
            this.excludeLines = excludeLines;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Compares the streams.
        /// </summary>
        /// <param name="compareStream">The compare stream.</param>
        /// <param name="etalonStream">The etalon stream.</param>
        /// <returns>The compare result</returns>
        public override CompareResult CompareStreams(Stream compareStream, Stream etalonStream)
        {
            // it is dangerous to compare SVG as text because it can contain the whole image as single line. Need to be done partialy using fixed buffers.

            compareStream.Seek(0, SeekOrigin.Begin);
            etalonStream.Seek(0, SeekOrigin.Begin);

            var output = new StreamReader(compareStream, Encoding.UTF8);
            var reference = new StreamReader(etalonStream, Encoding.UTF8);
            var lineId = 1;
            Exception error = null;
            while (error == null)
            {
                var outputLine = output.ReadLine();
                var referenceLine = reference.ReadLine();
                if (outputLine != null && referenceLine != null)
                {
                    error = this.CompareLines(outputLine, referenceLine, lineId);
                }
                else
                {
                    if (outputLine == null && referenceLine != null)
                    {
                        if (referenceLine.Trim() != "")
                        {
                            error = new Exception($"There are more lines in a reference text than in compare text, line:{lineId}");
                        }
                    }

                    if (outputLine != null && referenceLine == null)
                    {
                        if (outputLine.Trim() != "")
                        {
                            error = new Exception($"There are more lines in a compare text than in reference text, line:{lineId}");
                        }
                    }

                    break;
                }

                lineId++;
            }

            return new CompareResult(error == null, error == null ? "" : error.Message);
        }

        /// <summary>
        ///     Compares the lines.
        /// </summary>
        /// <param name="outputLine">The output line.</param>
        /// <param name="referenceLine">The reference line.</param>
        /// <param name="lineId">The line identifier.</param>
        /// <returns></returns>
        private Exception CompareLines(string outputLine, string referenceLine, int lineId)
        {
            Exception error = null;
            outputLine = outputLine.Trim();
            referenceLine = referenceLine.Trim();
            if (outputLine.Length != referenceLine.Length)
            {
                error = new Exception($"Output length: {outputLine.Length}, Reference length: {referenceLine.Length}, line:{lineId}");
            }
            else
            {
                for (var j = 0; j < outputLine.Length; j++)
                {
                    if (referenceLine[j] != outputLine[j])
                    {
                        error = new Exception($"Output: {outputLine[j]}, Reference: {referenceLine[j]}, line:{lineId}, col: {j + 1}");
                        break;
                    }
                }
            }

            if (error != null)
            {
                var result = this.excludeLines.Any(l => outputLine.Contains(l));
                if (result)
                {
                    result = this.excludeLines.Any(l => referenceLine.Contains(l));
                    if (result)
                    {
                        return null;
                    }
                }
            }

            return error;
        }

        /// <summary>
        ///     Filters the specified SVG line.
        /// </summary>
        /// <param name="svgLine">The SVG line.</param>
        /// <param name="filtered">The filtered.</param>
        /// <returns></returns>
        private static StringBuilder Filter(string svgLine, StringBuilder filtered)
        {
            filtered.Length = 0;
            foreach (var c in svgLine)
            {
                if (!char.IsWhiteSpace(c))
                {
                    filtered.Append(c);
                }
            }

            return filtered;
        }

        #endregion
    }
}