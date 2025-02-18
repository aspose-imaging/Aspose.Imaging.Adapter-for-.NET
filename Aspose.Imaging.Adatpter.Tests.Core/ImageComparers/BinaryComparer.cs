// -----------------------------------------------------------------------------------------------------------
//   <copyright file="BinaryComparer.cs" company="Aspose Pty Ltd" author="" date="13.03.2024 13:40">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Pdf.Adapter.Tests.ImageComparers;

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;

/// <summary>
/// The binary comparer
/// </summary>
/// <seealso cref="Aspose.Imaging.Pdf.Adapter.Tests.ImageComparers.BaseComparer" />
public class BinaryComparer : BaseComparer
{
    #region Properties

    /// <summary>
    /// Gets or sets a value indicating whether [check length].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [check length]; otherwise, <c>false</c>.
    /// </value>
    public bool CheckLength { get; set; }

    #endregion

    #region Methods

    /// <summary>
    /// Compares the streams.
    /// </summary>
    /// <param name="stream1">The stream1.</param>
    /// <param name="stream2">The stream2.</param>
    /// <returns></returns>
    public override CompareResult CompareStreams(Stream stream1, Stream stream2)
    {
        const int BytesToRead = 4096;

        if (this.CheckLength)
        {
            if (stream1.Length != stream2.Length)
            {
                return new CompareResult(false, $"Stream lengths do not match. stream1.Length={stream1.Length}, stream2.Length={stream2.Length}");
            }
        }

        var one = new byte[BytesToRead];
        var two = new byte[BytesToRead];

        var canRead = true;
        while (canRead)
        {
            var bytes1 = stream1.Read(one, 0, BytesToRead);
            var bytes2 = stream2.Read(two, 0, BytesToRead);

            var vOne = MemoryMarshal.Cast<byte, Vector512<byte>>(one);
            var vTwo = MemoryMarshal.Cast<byte, Vector512<byte>>(two);

            if (!vTwo.SequenceEqual(vOne))
            {
                return new CompareResult(false, "Data in streams does not match");
            }

            canRead = bytes1 == BytesToRead && bytes2 == BytesToRead;
        }


        return new CompareResult();
    }

    #endregion
}