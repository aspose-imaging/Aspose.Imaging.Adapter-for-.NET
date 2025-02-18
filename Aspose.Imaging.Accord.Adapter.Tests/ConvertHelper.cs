// -----------------------------------------------------------------------------------------------------------
//   <copyright file="ConvertHelper.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="13.11.2024 13:02">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Accord.Adapter.Tests
{
    public static class ConvertHelper
    {
        #region Methods

        public static void DoubleArrayToStream(double[] data, Stream stream)
        {
            for (var i = 0; i < data.Length; i++)
            {
                var bytes = BitConverter.GetBytes(data[i]);
                stream.Write(bytes);
            }
        }

        #endregion
    }
}