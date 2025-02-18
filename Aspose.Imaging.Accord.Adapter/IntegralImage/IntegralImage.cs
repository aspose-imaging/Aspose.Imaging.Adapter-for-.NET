// -----------------------------------------------------------------------------------------------------------
//   <copyright file="IntegralImageResults.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="18.11.2024 16:02">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Accord.Adapter.IntegralImage
{
    using Openize.Accord.Imaging;

    /// <summary>
    /// The integral image
    /// </summary>
    public class IntegralImage
    {
        /// <summary>
        /// The integral image2
        /// </summary>
        private IntegralImage2 integralImage2;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegralImage"/> class.
        /// </summary>
        /// <param name="ii">The ii.</param>
        internal IntegralImage(IntegralImage2 integralImage2)
        {
            this.integralImage2 = integralImage2;
        }

        /// <summary>
        /// Gets the sum.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <returns></returns>
        public long GetSum(int x, int y, int width, int height)
        {
            return this.integralImage2.GetSum(x, y, width, height);
        }

        /// <summary>
        /// Gets the sum2.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <returns></returns>
        public long GetSum2(int x, int y, int width, int height)
        {
            return this.integralImage2.GetSum2(x, y, width, height);
        }

        /// <summary>
        /// Gets the sum t.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <returns></returns>
        public long GetSumT(int x, int y, int width, int height)
        {
            return this.integralImage2.GetSumT(x, y, width, height);
        }
    }
}