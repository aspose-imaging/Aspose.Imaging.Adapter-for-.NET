// -----------------------------------------------------------------------------------------------------------
//   <copyright file="PdfTestsBase.cs" company="Aspose Pty Ltd" author="" date="13.03.2024 13:40">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Pdf.Adapter.Tests;

using System.Reflection;
using NUnit.Framework;

/// <summary>
/// The test base
/// </summary>
public class PdfTestsBase
{
    #region Constants

    /// <summary>
    /// The test project name
    /// </summary>
    private const string TestProjectName = "Aspose.Imaging.Pdf.Adapter.Tests";

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes the <see cref="PdfTestsBase"/> class.
    /// </summary>
    static PdfTestsBase()
    {
        TestDataPath = Path.Combine(TestPath, "TestData");
        ImagesPath = Path.Combine(TestDataPath, "Images");
        StandardsPath = Path.Combine(TestDataPath, "Standards");
        BuildOutPath = Path.Combine(TestPath, "build-out");
        LicensePath = Path.Combine(TestDataPath, "License", "Aspose.Total.Product.Family.lic");
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the test path.
    /// </summary>
    /// <value>
    /// The test path.
    /// </value>
    public static string TestPath { get; } = GetTestPath();

    /// <summary>
    /// Gets the test data path.
    /// </summary>
    /// <value>
    /// The test data path.
    /// </value>
    public static string TestDataPath { get; }

    /// <summary>
    /// Gets the images path.
    /// </summary>
    /// <value>
    /// The images path.
    /// </value>
    public static string ImagesPath { get; }

    /// <summary>
    /// Gets the standards path.
    /// </summary>
    /// <value>
    /// The standards path.
    /// </value>
    public static string StandardsPath { get; }

    /// <summary>
    /// Gets the build out path.
    /// </summary>
    /// <value>
    /// The build out path.
    /// </value>
    public static string BuildOutPath { get; }

    /// <summary>
    /// Gets the license path.
    /// </summary>
    /// <value>
    /// The license path.
    /// </value>
    private static string LicensePath { get; }

    /// <summary>
    /// Gets the name of the method.
    /// </summary>
    /// <value>
    /// The name of the method.
    /// </value>
    private static string? MethodName => TestContext.CurrentContext.Test.MethodName;

    /// <summary>
    /// Gets a value indicating whether this instance is licensed.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is licensed; otherwise, <c>false</c>.
    /// </value>
    public static bool IsLicensed { get; private set; }

    #endregion

    #region Methods

    /// <summary>
    /// Setups this instance.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        var testName = MethodName;
        var buildOutDir = Path.Combine(BuildOutPath, testName);
        if (!Directory.Exists(buildOutDir))
        {
            Directory.CreateDirectory(buildOutDir);
        }

        SetLicense();
    }

    /// <summary>
    /// Gets the name of the out file.
    /// </summary>
    /// <param name="fileName">Name of the file.</param>
    /// <returns></returns>
    public static string GetOutFileName(string fileName)
    {
        var testName = MethodName;
        return Path.Combine(BuildOutPath, testName, fileName);
    }

    /// <summary>
    /// Gets the name of the standard file.
    /// </summary>
    /// <param name="fileName">Name of the file.</param>
    /// <returns></returns>
    public static string GetStandardFileName(string fileName)
    {
        var testName = MethodName;
        var nonLicensed = !IsLicensed ? "NonLicensed" : "";
        return Path.Combine(StandardsPath,nonLicensed, testName, fileName);
    }

    /// <summary>
    /// Sets the license.
    /// </summary>
    public static void SetLicense()
    {
        if (!File.Exists(LicensePath))
        {
            Console.WriteLine("License file not exists");
            return;
        }

        PdfImage.SetLicense(LicensePath);
        IsLicensed = true;
    }


    /// <summary>
    /// Removes the file.
    /// </summary>
    /// <param name="fileName">Name of the file.</param>
    /// <returns></returns>
    public static bool RemoveFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            try
            {
                File.Delete(fileName);
                return true;
            }
            catch
            {
            }
        }

        return false;
    }

    /// <summary>
    /// Gets the root path.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <returns></returns>
    private static string GetRootPath(string path)
    {
        var check = !(path == null || Directory.Exists(Path.Combine(path, TestProjectName)));
        while (check)
        {
            path = Path.GetDirectoryName(path);
            check = !(path == null || Directory.Exists(Path.Combine(path, TestProjectName)));
        }

        return path;
    }

    /// <summary>
    /// Gets the test path.
    /// </summary>
    /// <returns></returns>
    private static string GetTestPath()
    {
        var uri = new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase);
        var currentDir = Path.Combine(GetRootPath(uri.LocalPath), TestProjectName);
        return Path.Combine(currentDir, "Test");
    }

    #endregion
}