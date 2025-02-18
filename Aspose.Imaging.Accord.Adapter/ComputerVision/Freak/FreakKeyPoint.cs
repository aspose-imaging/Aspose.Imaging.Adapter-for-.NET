// -----------------------------------------------------------------------------------------------------------
//   <copyright file="FreakKeyPoint.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="13.11.2024 11:36">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Accord.Adapter.ComputerVision.Freak
{
    using System;
    using System.Linq;

    /// <summary>
    ///     The FREAK point
    /// </summary>
    public class FreakKeyPoint : KeyPoint
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="KeyPoint" /> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="orientation">The orientation.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="descriptor">The descriptor.</param>
        public FreakKeyPoint(double x, double y, double orientation, double scale, byte[] descriptor) : base(x, y, orientation, scale)
        {
            this.Descriptor = descriptor;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the descriptor.
        /// </summary>
        /// <value>
        ///     The descriptor.
        /// </value>
        public byte[] Descriptor { get; set; }

        #endregion

        #region Methods

        /// <summary>
        ///     Converts to hex.
        /// </summary>
        /// <returns></returns>
        public string ToHex()
        {
            return this.Descriptor.Select(d => d.ToString("x8")).Aggregate((current, next) => current + next);
        }

        /// <summary>
        ///     Converts to base64.
        /// </summary>
        /// <returns></returns>
        public string ToBase64()
        {
            return Convert.ToBase64String(this.Descriptor);
        }

        #endregion
    }
}