// -----------------------------------------------------------------------------------------------------------
//   <copyright file="AccordImage.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="11.11.2024 11:45">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Accord.Adapter
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using Openize.Accord.Imaging.Interest_Points.FREAK;
    using Openize.Accord.Imaging.AForge.Imaging;
    using Openize.Accord.Imaging.Interest_Points;
    using Openize.Accord.Imaging.Interest_Points.Base;
    using Aspose.Imaging.Accord.Adapter.Surf;
    using ComputerVision.Corners;
    using Openize.Accord.Imaging.Interest_Points.SURF;
    using ComputerVision.Freak;
    using ComputerVision.Glcm;
    using ComputerVision.Surf;
    using Openize.Accord.Imaging;
    using Openize.Accord.Imaging.AForge.Imaging.Filters.Color_Filters;
    using Openize.Accord.Core.AForge.Core;
    using Openize.Accord.Imaging.Contour;
    using Point = Imaging.Point;
    using Openize.Accord.Imaging.Filters;
    using Rectangle = Imaging.Rectangle;
    using System.Drawing.Imaging;
    using FiltersProperties;
    using Openize.Accord.Imaging.AForge.Imaging.Filters.Base_classes;
    using System.Runtime.InteropServices;
    using Openize.Accord.Imaging.Interest_Points.Haralick;
    using Aspose.Imaging.Accord.Adapter.ComputerVision.FeatureExtractor;

    /// <summary>
    /// The Accord image
    /// </summary>
    public static class AccordImage
    {
        /// <summary>
        /// Corners the detector.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="properties">The properties.</param>
        /// <returns></returns>
        public static List<Point> CornerDetector(this RasterImage image, Rectangle rectangle, ICornersDetectorProperties properties)
        {
            using var unmanagedImage = ToAForgeImage(image, rectangle);
            var cornersDetector = GetCornersDetector(properties);
            var corners = cornersDetector.ProcessImage(unmanagedImage);
            return corners.Select(c => new Point(c.X, c.Y)).ToList();
        }

        /// <summary>
        /// Fasts the retina keypoint detector.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="properties">The properties.</param>
        /// <returns></returns>
        public static List<FreakKeyPoint> FastRetinaKeypointDetector(this RasterImage image, Rectangle rectangle, ICornersDetectorProperties properties)
        {
            var cornersDetector = GetCornersDetector(properties);
            var freak = new FastRetinaKeypointDetector(cornersDetector);
            using var unmanagedImage = ToAForgeImage(image, rectangle);
            var points = freak.Transform(unmanagedImage);
                
            return points.Select(p => new FreakKeyPoint(p.X, p.Y, p.Orientation, p.Scale, p.Descriptor)).ToList();
        }

        /// <summary>
        /// Speededs up robust features detector.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="properties">The properties.</param>
        /// <returns></returns>
        public static List<SurfKeyPoint> SpeededUpRobustFeaturesDetector(this RasterImage image, Rectangle rectangle, SpeededUpRobustFeaturesDetectorProperties properties)
        {
            using var unmanagedImage = ToAForgeImage(image, rectangle);
            var surf = new SpeededUpRobustFeaturesDetector(properties.Threshold, properties.Octaves, initial: properties.Step);
            var points = surf.Transform(unmanagedImage);
            return points.Select(p => new SurfKeyPoint(p.X, p.Y, p.Orientation, p.Scale, p.Descriptor)).ToList();
        }

        /// <summary>
        /// Grays the level cooccurrence matrix.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="properties">The properties.</param>
        /// <returns></returns>
        public static double[,] GrayLevelCooccurrenceMatrix(this RasterImage image, Rectangle rectangle, GrayLevelCooccurrenceMatrixProperties properties)
        {
            using var unmanagedImage = ToAForgeGrayscaleImage(image, rectangle);
            var glcm = new GrayLevelCooccurrenceMatrix(properties.Distance, properties.Degree, properties.Normalize, properties.AutoGray);
            return glcm.Compute(unmanagedImage);
        }

        /// <summary>
        /// Finds the contour.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="threshold">The threshold.</param>
        /// <returns></returns>
        public static List<Point> FindContour(this RasterImage image, Rectangle rectangle, byte threshold = 0)
        {
            using var unmanagedImage = ToAForgeGrayscaleImage(image, rectangle);
            BorderFollowing bf = new BorderFollowing(threshold);
            List<IntPoint> contour = bf.FindContour(unmanagedImage);
            return contour.Select(c => new Point(c.X, c.Y)).ToList();
        }

        /// <summary>
        /// Gets the integral image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="computeTilted">if set to <c>true</c> [compute tilted].</param>
        /// <returns></returns>
        public static IntegralImage.IntegralImage GetIntegralImage(this RasterImage image, Rectangle rectangle, bool computeTilted)
        {
            using var unmanagedImage = ToAForgeImage(image, rectangle);
            IntegralImage2 ii = Openize.Accord.Imaging.IntegralImage2.FromBitmap(unmanagedImage, computeTilted);
            return new IntegralImage.IntegralImage(ii);
        }

        /// <summary>
        /// Features the extracor.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="properties">The properties.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">properties</exception>
        public static List<double[]> FeatureExtracor(this RasterImage image, Rectangle rectangle, IFeatureExtractorProperties properties)
        {
            BaseFeatureExtractor<FeatureDescriptor> featureExtractor;
            using var unmanagedImage = ToAForgeImage(image, rectangle);
            switch (properties)
            {
                case HaralickProperties haralickProperties:
                    Haralick haralick = new Haralick()
                    {
                        Mode = haralickProperties.Mode,
                        CellSize = haralickProperties.CellSize
                    };

                    featureExtractor = haralick;
                    break;
                case HistogramsOfOrientedGradientsProperties histogramsOfOrientedGradientsProperties:
                    var hog = new HistogramsOfOrientedGradients(histogramsOfOrientedGradientsProperties.NumberOfBins, histogramsOfOrientedGradientsProperties.BlockSize, histogramsOfOrientedGradientsProperties.CellSize);
                    featureExtractor = hog;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(properties));
            }

            return featureExtractor.Transform(unmanagedImage).Select(s => s.Descriptor).ToList();
        }

        /// <summary>
        /// Applies the filter.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="properties">The properties.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">properties</exception>
        public static void ApplyFilter(this RasterImage image, Rectangle rectangle, IFilterProperties properties)
        {
            BaseFilter filter;
            using var unmanagedImage = ToAForgeImage(image, rectangle, PixelFormat.Format24bppRgb);
            switch (properties)
            {
                case NiblackThresholdProperties niblackThresholdProperties:
                    var niblack = new NiblackThreshold();
                    niblack.K = niblackThresholdProperties.K;
                    niblack.C = niblackThresholdProperties.C;
                    niblack.Radius = niblackThresholdProperties.Radius;
                    filter = niblack;
                    break;
                case SaulovaThresholdProperties saulovaThresholdProperties:
                    var sauvola = new SauvolaThreshold();
                    sauvola.K = saulovaThresholdProperties.K;
                    sauvola.R = saulovaThresholdProperties.R;
                    sauvola.Radius = saulovaThresholdProperties.Radius;
                    filter = sauvola;
                    break;
                case GaborFilterProperties gaborFilterProperties:
                    var gabor = new GaborFilter();
                    gabor.Sigma = gaborFilterProperties.Sigma;
                    gabor.Gamma = gaborFilterProperties.Gamma;
                    gabor.Lambda = gaborFilterProperties.Lambda;
                    gabor.Psi = gaborFilterProperties.Psi;
                    gabor.Theta = gaborFilterProperties.Theta;
                    gabor.Size = gaborFilterProperties.Size;
                    filter = gabor;
                    break;
                case DifferenceOfGaussiansProperties dogProperties:
                    var doG = new DifferenceOfGaussians(dogProperties.WindowSize1, dogProperties.WindowSize2, dogProperties.Sigma1,
                        dogProperties.Sigma2);
                    doG.ApplyInPlace(unmanagedImage);
                    FromAForgeImage(image, unmanagedImage, rectangle);
                    return;
                default:
                    throw new ArgumentOutOfRangeException(nameof(properties));
            }

            using var result = filter.Apply(unmanagedImage);
            FromAForgeImage(image, result, rectangle);
        }

        /// <summary>
        /// Gets the corners detector.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">properties</exception>
        private static BaseCornersDetector GetCornersDetector(ICornersDetectorProperties properties)
        {
            switch (properties)
            {
                case FastCornersDetectorProperties fastCornersDetectorProperties:
                    FastCornersDetector fast = new FastCornersDetector()
                    {
                        Suppress = fastCornersDetectorProperties.Suppress, // suppress non-maximum points
                        Threshold = fastCornersDetectorProperties.Threshold// less leads to more corners
                    };

                    return fast;

                case HarrisCornersDetectorProperties harrisCornersDetectorProperties:
                    HarrisCornersDetector hcd =
                        new HarrisCornersDetector(harrisCornersDetectorProperties.Measure, harrisCornersDetectorProperties.Threshold, harrisCornersDetectorProperties.Sigma, harrisCornersDetectorProperties.Suppression);
                    hcd.K = harrisCornersDetectorProperties.K;
                    return hcd;
                default:
                    throw new ArgumentOutOfRangeException(nameof(properties));
            }
        }

        /// <summary>
        /// Converts to aforgeimage.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns></returns>
        private static UnmanagedImage ToAForgeImage(this RasterImage image, Aspose.Imaging.Rectangle rectangle, PixelFormat pixelFormat = PixelFormat.Format32bppArgb)
        {
            var data = image.LoadArgb32Pixels(rectangle);
            return PixelDataToImage(data, rectangle.Width, rectangle.Height, pixelFormat);
        }

        /// <summary>
        /// Froms a forge image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="aForgeImage">a forge image.</param>
        /// <param name="rectangle">The rectangle.</param>
        private static void FromAForgeImage(this RasterImage image, UnmanagedImage aForgeImage, Aspose.Imaging.Rectangle rectangle)
        {
            var data = ImageToPixelData(aForgeImage);
            image.SaveArgb32Pixels(rectangle, data);
        }

        /// <summary>
        /// Images to pixel data.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <returns></returns>
        private static unsafe int[] ImageToPixelData(UnmanagedImage image)
        {
            int num = image.Width * image.Height;
            int[] array = new int[num];
            using Bitmap bitmap = image.ToManagedImage();
            BitmapData bitmapData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            try
            {
                int* ptr = (int*)bitmapData.Scan0.ToPointer();
                fixed (int* ptr2 = array)
                {
                    for (int i = 0; i < num; i++)
                    {
                        ptr2[i] = ptr[i];
                    }

                    return array;
                }
            }
            finally
            {
                bitmap.UnlockBits(bitmapData);
            }
        }

        /// <summary>
        /// Pixels the data to image.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <returns></returns>
        private static unsafe UnmanagedImage PixelDataToImage(int[] data, int width, int height, PixelFormat pixelFormat)
        {
            if (pixelFormat == PixelFormat.Format32bppArgb)
            {
                fixed (int* ptr = data)
                {
                    return new UnmanagedImage((IntPtr)ptr, width, height, width * 4, pixelFormat);
                }
            }

            if (pixelFormat == PixelFormat.Format24bppRgb)
            {
                var byteArray = MemoryMarshal.Cast<int, byte>(data);
                var newByteArray = new Span<byte>(new byte[(byteArray.Length * 3)/4]);
                for (int i = 0, k = 0; i < byteArray.Length; i += 4, k += 3)
                {
                    newByteArray[k] = byteArray[i];
                    newByteArray[k + 1] = byteArray[i + 1];
                    newByteArray[k + 2] = byteArray[i + 2];
                }

                var result = MemoryMarshal.Cast<byte, int>(newByteArray);
                fixed (int* ptr = result)
                {
                    return new UnmanagedImage((IntPtr)ptr, width, height, width * 3, pixelFormat);
                }
            }

            throw new ArgumentException($"The PixelFormat = {pixelFormat} not supported");
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
    }
}