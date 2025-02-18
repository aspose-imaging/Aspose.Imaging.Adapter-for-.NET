// -----------------------------------------------------------------------------------------------------------
//   <copyright file="DrawHelper.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="13.11.2024 14:35">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Accord.Adapter.Tests
{
    public static class DrawHelper
    {
        #region Methods

        /// <summary>
        ///     Adds the corners to image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="points">The points.</param>
        public static void AddPointsToImage(RasterImage image, List<Point> points)
        {
            var graphics = new Graphics(image);
            var pen = new Pen(Color.Red, 1);
            for (var i = 0; i < points.Count; i++)
            {
                var point = points[i];
                var rect = new Rectangle(point.X - 1, point.Y - 1, 2, 2);
                graphics.DrawArc(pen, rect, 0, 360);
            }
        }

        #endregion
    }
}