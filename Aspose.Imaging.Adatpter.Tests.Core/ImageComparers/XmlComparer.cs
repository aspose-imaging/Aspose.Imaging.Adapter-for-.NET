// -----------------------------------------------------------------------------------------------------------
//   <copyright file="XmlComparer.cs" company="Aspose Pty Ltd" author="" date="13.03.2024 13:40">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Pdf.Adapter.Tests.ImageComparers;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

/// <summary>
/// The Xml comparer
/// </summary>
/// <seealso cref="Aspose.Imaging.Pdf.Adapter.Tests.ImageComparers.BaseComparer" />
public class XmlComparer : BaseComparer
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
    public XmlComparer(List<string> excludeLines)
    {
        this.excludeLines = excludeLines;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Compares the streams.
    /// </summary>
    /// <param name="compareStream">The compare stream.</param>
    /// <param name="etalonStream">The etalon stream.</param>
    /// <returns></returns>
    public override CompareResult CompareStreams(Stream compareStream, Stream etalonStream)
    {
        var lineId = 1;
        using (var reader1 = XmlReader.Create(etalonStream))
        using (var reader2 = XmlReader.Create(compareStream))
        {
            while (!reader1.Read())
            {
                var line1 = reader1.ReadOuterXml();
                if (!reader2.Read())
                {
                    return new CompareResult(false, $"There are more lines in a standard xml than in compared xml, line:{lineId}");
                }

                var line2 = reader2.ReadOuterXml();
                if (line1 != line2)
                {
                    var result = this.excludeLines.Any(l => line1.Contains(l));
                    if (result)
                    {
                        result = this.excludeLines.Any(l => line2.Contains(l));
                        if (result)
                        {
                            continue;
                        }
                    }

                    return new CompareResult(false, $"lines are not equal, line:{lineId}\n standard:\n {line1} \n compared:\n{line2}");
                }

                lineId++;
            }
        }

        return new CompareResult();
    }

    #endregion
}