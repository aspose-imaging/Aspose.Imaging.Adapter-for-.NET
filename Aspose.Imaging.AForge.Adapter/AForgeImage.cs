// -----------------------------------------------------------------------------------------------------------
//   <copyright file="AForgeImage.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="27.08.2024 11:05">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.AForge.Adapter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Blobs;
    using Corners;
    using Edge;
    using FileFormats.Png;
    using Openize.AForge.Core.NetStandard;
    using Openize.AForge.Imaging.NetStandard;
    using Openize.AForge.Imaging.NetStandard.Filters;
    using Openize.AForge.Imaging.NetStandard.Filters.Color_Filters;
    using Openize.AForge.Imaging.NetStandard.Filters.Edge_Detectors;
    using Openize.AForge.Imaging.NetStandard.Filters.Other;
    using ImageMatch;
    using BlockMatch = ImageMatch.BlockMatch;
    using Point = Imaging.Point;

    /// <summary>
    /// The AForge image adapter
    /// </summary>
    public static class AForgeImage
    {
        #region Methods

        /// <summary>
        /// Edges the detector.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="type">The type.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">type - null</exception>
        public static void EdgeDetector(this RasterImage image, Aspose.Imaging.Rectangle rectangle, EdgeDetectorType type)
        {
            var data = image.LoadArgb32Pixels(rectangle);
            using (var unmanagedImage = ToAForgeGrayscaleImage(image, rectangle))
            {
                IInPlaceFilter edgeFilter;
                switch (type)
                {
                    case EdgeDetectorType.Homogenity:
                        edgeFilter = new HomogenityEdgeDetector();
                        break;
                    case EdgeDetectorType.Difference:
                        edgeFilter = new DifferenceEdgeDetector();
                        break;
                    case EdgeDetectorType.Sobel:
                        edgeFilter = new SobelEdgeDetector();
                        break;
                    case EdgeDetectorType.Canny:
                        edgeFilter = new CannyEdgeDetector();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(type), type, null);
                }

                    edgeFilter.ApplyInPlace(unmanagedImage);
                    FromAForgeImage(image, unmanagedImage, rectangle);
            }
        }

        /// <summary>
        /// Detects the blobs.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns></returns>
        public static List<ExtendedBlob> DetectBlobs(this RasterImage image, BlobCounterSettings settings, Aspose.Imaging.Rectangle rectangle)
        {
            var bc = new BlobCounter();
            bc.FilterBlobs = settings.FilterBlobs;
            bc.MinWidth = settings.MinWidth;
            bc.MinHeight = settings.MinHeight;
            bc.ObjectsOrder = (ObjectsOrder)settings.Order;
            bc.MaxWidth = settings.MaxWidth;
            bc.MaxHeight = settings.MaxHeight;
            bc.CoupledSizeFiltering = settings.CoupledSizeFiltering;

            using (var unmanagedImage = ToAForgeImage(image, rectangle))
            {
                bc.ProcessImage(unmanagedImage);
                var blobs = bc.GetObjectsInformation();
                var exBlobs = blobs.Select(b => new ExtendedBlob(b, image, bc, rectangle)).ToList();
                return exBlobs;
            }
        }

        /// <summary>
        /// Extracts the biggest BLOB.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns></returns>
        public static Aspose.Imaging.Image ExtractBiggestBlob(this RasterImage image, Aspose.Imaging.Rectangle rectangle)
        {
            using (var unmanagedImage = ToAForgeImage(image, rectangle))
            {
                ExtractBiggestBlob filter = new ExtractBiggestBlob();
                using (var filtered = filter.Apply(unmanagedImage.ToManagedImage()))
                {
                    var data = PixelExport.ImageToPixelData(UnmanagedImage.FromManagedImage(filtered));
                    var result = new PngImage(filtered.Width, filtered.Height);
                    result.SaveArgb32Pixels(result.Bounds, data);
                    return result;
                }
            }
        }

        /// <summary>
        /// Blobses the filtering.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="rectangle">The rectangle.</param>
        public static void BlobsFiltering(this RasterImage image, BlobCounterSettings settings, Aspose.Imaging.Rectangle rectangle)
        {
            var bc = new BlobsFiltering();
            bc.MinWidth = settings.MinWidth;
            bc.MinHeight = settings.MinHeight;
            bc.MaxWidth = settings.MaxWidth;
            bc.MaxHeight = settings.MaxHeight;
            bc.CoupledSizeFiltering = settings.CoupledSizeFiltering;

            using (var unmanagedImage = ToAForgeImage(image, rectangle))
            {
                bc.ApplyInPlace(unmanagedImage);
                FromAForgeImage(image, unmanagedImage, rectangle);
            }
        }

        /// <summary>
        /// Exhaustives the template matching.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="threshold">The threshold.</param>
        /// <param name="template">The template.</param>
        /// <returns></returns>
        public static float ExhaustiveTemplateMatching(this RasterImage image, float threshold, RasterImage template)
        {
            using (var img = ToAForgeGrayscaleImage(image, image.Bounds))
            {
                using (var tmp = ToAForgeGrayscaleImage(template, template.Bounds))
                {
                    var tm = new ExhaustiveTemplateMatching(threshold);
                    var matchings = tm.ProcessImage(img, tmp);
                    if (matchings.Length > 0)
                    {
                        return matchings[0].Similarity;
                    }
                }
            }

            return 0;
        }

        /// <summary>
        /// Exhaustives the block matching.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="searchImage">The template.</param>
        /// <returns></returns>
        public static List<Aspose.Imaging.AForge.Adapter.ImageMatch.BlockMatch> ExhaustiveBlockMatching(this RasterImage image, RasterImage searchImage, ExhaustiveBlockMatchingSettings settings)
        {
            using (var img = ToAForgeGrayscaleImage(image, image.Bounds))
            using (var srch = ToAForgeGrayscaleImage(searchImage, image.Bounds))
            {
                var scd = new SusanCornersDetector(settings.DifferenceThreshold, settings.GeometricThreshold);
                var points = scd.ProcessImage(img);
                var bm = new ExhaustiveBlockMatching(settings.BlockSize, settings.SearchRadius);
                var matches = bm.ProcessImage(img, points, srch).Select(m => new BlockMatch(m)).ToList();
                return matches;
            }
        }

        /// <summary>
        /// Corners the detector.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="settings">The settings.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">nameof(type), type, null</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">type - null</exception>
        public static List<Point> CornersDetector(this RasterImage image, Rectangle rectangle, ICornersDetectorSettings settings)
        {
            List<IntPoint> corners = null;
            using (var grayscaleImage = ToAForgeGrayscaleImage(image, rectangle))
            {
                if (settings is MoravecCornerDetectorSettings)
                {
                    var mcd = new MoravecCornersDetector();
                    var mSettings = (MoravecCornerDetectorSettings)settings;
                    if (mSettings.DifferenceThreshold != 0)
                    {
                        mcd.Threshold = mSettings.DifferenceThreshold;
                    }

                    if (mSettings.WindowSize != 0)
                    {
                        mcd.WindowSize = mSettings.WindowSize;
                    }

                    corners = mcd.ProcessImage(grayscaleImage);
                }
                else if (settings is SusanCornersDetectorSettings)
                {
                    var scd = new SusanCornersDetector();
                    var sSettings = (SusanCornersDetectorSettings)settings;
                    if (sSettings.DifferenceThreshold != 0)
                    {
                        scd.DifferenceThreshold = sSettings.DifferenceThreshold;
                    }

                    if (sSettings.GeometricalThreshold != 0)
                    {
                        scd.GeometricalThreshold = sSettings.GeometricalThreshold;
                    }

                    corners = scd.ProcessImage(grayscaleImage);
                }
                else
                {
                    throw new NotSupportedException($"The '{settings.GetType()}' settings are not supported.");
                }
            }

            if (corners != null)
            {
                return corners.Select(c => new Point(c.X, c.Y)).ToList();
            }

            return new List<Point>();
        }


        /// <summary>
        /// Documents the skew checker.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="maxSkew">The maximum skew.</param>
        /// <returns></returns>
        public static double DocumentSkewChecker(this RasterImage image, Rectangle rectangle, int maxSkew)
        {
            using (var grayscaleImage = ToAForgeGrayscaleImage(image, rectangle))
            {
                var skewChecker = new DocumentSkewChecker();
                skewChecker.MaxSkewToDetect = maxSkew;
                return skewChecker.GetSkewAngle(grayscaleImage);
            }
        }

        /// <summary>
        /// Documents the skew checker.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns></returns>
        /// SkewChecker already has an imaging
        private static double DocumentSkewChecker(this RasterImage image, Rectangle rectangle)
        {
            return DocumentSkewChecker(image, rectangle, 30);
        }

        /// <summary>
        /// Converts to aforgeimage.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns></returns>
        private static UnmanagedImage ToAForgeImage(this RasterImage image, Aspose.Imaging.Rectangle rectangle)
        {
            var data = image.LoadArgb32Pixels(rectangle);
            return PixelExport.PixelDataToImage(data, rectangle.Width, rectangle.Height);
        }

        /// <summary>
        /// Froms a forge image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="aForgeImage">a forge image.</param>
        /// <param name="rectangle">The rectangle.</param>
        private static void FromAForgeImage(this RasterImage image, UnmanagedImage aForgeImage, Aspose.Imaging.Rectangle rectangle)
        {
            var data = PixelExport.ImageToPixelData(aForgeImage);
            image.SaveArgb32Pixels(rectangle, data);
        }

        /// <summary>
        /// Converts to aforgegrayscaleimage.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns></returns>
        private static UnmanagedImage ToAForgeGrayscaleImage(this RasterImage image, Aspose.Imaging.Rectangle rectangle)
        {
            using (var img = ToAForgeImage(image, rectangle))
            {
                var grayscaleFilter = new Grayscale(0.2126, 0.7152, 0.0722);
                return grayscaleFilter.Apply(img);
            }
        }

        #endregion
    }
}