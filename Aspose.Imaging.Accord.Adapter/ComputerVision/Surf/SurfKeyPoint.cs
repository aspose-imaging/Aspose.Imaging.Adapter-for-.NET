// -----------------------------------------------------------------------------------------------------------
//   <copyright file="SurfKeyPoint.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="13.11.2024 11:36">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Accord.Adapter.ComputerVision.Surf
{
    /// <summary>
    ///     The Surf key point
    /// </summary>
    /// <seealso cref="Aspose.Imaging.Accord.Adapter.ComputerVision.KeyPoint" />
    public class SurfKeyPoint : KeyPoint
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SurfKeyPoint"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="orientation">The orientation.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="descriptor">The descriptor.</param>
        public SurfKeyPoint(double x, double y, double orientation, double scale, double[] descriptor) : base(x, y, orientation, scale)
        {
            this.Descritor = descriptor;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the descritor.
        /// </summary>
        /// <value>
        ///     The descritor.
        /// </value>
        public double[] Descritor { get; set; }

        #endregion
    }
}