// -----------------------------------------------------------------------------------------------------------
//   <copyright file="KeyPoint.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="13.11.2024 11:32">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Accord.Adapter.ComputerVision
{
    /// <summary>
    ///     The key point
    /// </summary>
    public class KeyPoint
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="KeyPoint" /> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="orientation">The orientation.</param>
        /// <param name="scale">The scale.</param>
        public KeyPoint(double x, double y, double orientation, double scale)
        {
            this.X = x;
            this.Y = y;
            this.Orientation = orientation;
            this.Scale = scale;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the x.
        /// </summary>
        /// <value>
        ///     The x.
        /// </value>
        public double X { get; set; }

        /// <summary>
        ///     Gets or sets the y.
        /// </summary>
        /// <value>
        ///     The y.
        /// </value>
        public double Y { get; set; }

        /// <summary>
        ///     Gets or sets the orientation.
        /// </summary>
        /// <value>
        ///     The orientation.
        /// </value>
        public double Orientation { get; set; }

        /// <summary>
        ///     Gets or sets the scale.
        /// </summary>
        /// <value>
        ///     The scale.
        /// </value>
        public double Scale { get; set; }

        #endregion
    }
}