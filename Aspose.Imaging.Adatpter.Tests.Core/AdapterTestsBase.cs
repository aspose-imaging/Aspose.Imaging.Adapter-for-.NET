// -----------------------------------------------------------------------------------------------------------
//   <copyright file="PdfTestsBase.cs" company="Aspose Pty Ltd" author="Stanislav Popov" date="19.04.2024 16:09">
//      Copyright (c) 2001-2024 Aspose Pty Ltd. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------------------------------------

namespace Aspose.Imaging.Adatpter.Tests.Core;

using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;

/// <summary>
///     The test base
/// </summary>
public abstract class AdapterTestsBase
{
    #region Constants

    /// <summary>
    ///     The test project name
    /// </summary>
    protected string testProjectName = "Aspose.Imaging.Pdf.Adapter.Tests";

    #endregion

    #region Constructors

    /// <summary>
    ///     Initializes the <see cref="AdapterTestsBase" /> class.
    /// </summary>
    /// "Aspose.Imaging.Pdf.Adapter.Tests"
    /// "Aspose.Total.Product.Family.lic"
    protected AdapterTestsBase(string testProjectName, string licenseName)
    {
        TestPath = GetTestPath(testProjectName);
        TestDataPath = Path.Combine(TestPath, "TestData");
        ImagesPath = Path.Combine(TestDataPath, "Images");
        StandardsPath = Path.Combine(TestDataPath, "Standards");
        BuildOutPath = Path.Combine(TestPath, "build-out");
        LicensePath = Path.Combine(TestDataPath, "License", licenseName);
    }

    #endregion

    #region Properties

    /// <summary>
    ///     Gets the test path.
    /// </summary>
    /// <value>
    ///     The test path.
    /// </value>
    public string TestPath { get; private set; } 

    /// <summary>
    ///     Gets the test data path.
    /// </summary>
    /// <value>
    ///     The test data path.
    /// </value>
    public string TestDataPath { get; }

    /// <summary>
    ///     Gets the images path.
    /// </summary>
    /// <value>
    ///     The images path.
    /// </value>
    public string ImagesPath { get; }

    /// <summary>
    ///     Gets the standards path.
    /// </summary>
    /// <value>
    ///     The standards path.
    /// </value>
    public string StandardsPath { get; }

    /// <summary>
    ///     Gets the build out path.
    /// </summary>
    /// <value>
    ///     The build out path.
    /// </value>
    public string BuildOutPath { get; }

    /// <summary>
    ///     Gets a value indicating whether this instance is licensed.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance is licensed; otherwise, <c>false</c>.
    /// </value>
    public bool IsLicensed { get; private set; }

    /// <summary>
    ///     Gets the license path.
    /// </summary>
    /// <value>
    ///     The license path.
    /// </value>
    private string LicensePath { get; }

    /// <summary>
    ///     Gets the name of the method.
    /// </summary>
    /// <value>
    ///     The name of the method.
    /// </value>
    private string? MethodName => TestContext.CurrentContext.Test.MethodName;

    #endregion

    #region Methods

    /// <summary>
    ///     Setups this instance.
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
    ///     Gets the name of the out file.
    /// </summary>
    /// <param name="fileName">Name of the file.</param>
    /// <returns></returns>
    public string GetOutFileName(string fileName)
    {
        var testName = MethodName;
        return Path.Combine(BuildOutPath, testName, fileName);
    }

    /// <summary>
    ///     Gets the name of the standard file.
    /// </summary>
    /// <param name="fileName">Name of the file.</param>
    /// <returns></returns>
    public string GetStandardFileName(string fileName)
    {
        var testName = MethodName;
        var nonLicensed = !IsLicensed ? "NonLicensed" : "";
        return Path.Combine(StandardsPath, nonLicensed, testName, fileName);
    }

    /// <summary>
    ///     Sets the license.
    /// </summary>
    public void SetLicense()
    {
        if (!File.Exists(LicensePath))
        {
            Console.WriteLine("License file not exists");
            return;
        }


        this.ApplyLicense(LicensePath);
        IsLicensed = true;
    }

    protected abstract void ApplyLicense(string licensePath);
    

    /// <summary>
    ///     Removes the file.
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
    ///     Gets the root path.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <returns></returns>
    private static string GetRootPath(string path, string testProjectName)
    {
        var check = !(path == null || Directory.Exists(Path.Combine(path, testProjectName)));
        while (check)
        {
            path = Path.GetDirectoryName(path);
            check = !(path == null || Directory.Exists(Path.Combine(path, testProjectName)));
        }

        return path;
    }

    /// <summary>
    ///     Gets the test path.
    /// </summary>
    /// <param name="testProjectName1"></param>
    /// <returns></returns>
    private static string GetTestPath(string testProjectName)
    {
        var uri = new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase);
        var currentDir = Path.Combine(GetRootPath(uri.LocalPath, testProjectName), testProjectName);
        return Path.Combine(currentDir, "Test");
    }

    #endregion
}