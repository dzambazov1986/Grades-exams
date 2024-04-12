using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class GradesTests
{
    [Test]
    public void Test_GetBestStudents_ReturnsBestThreeStudents()
    {
        // Arrange
        var grades = new Dictionary<string, int>
    {
        { "Dimityr", 95 },
        { "Ivan", 90 },
        { "Svetlin", 85 },
        { "Daqna", 80 },
        { "Eli", 75 }
    };

        var expected = "Dimityr with average grade 95.00\nIvan with average grade 90.00\nSvetlin with average grade 85.00";

        // Act
        var result = Grades.GetBestStudents(grades);
        result = result.Replace("\r\n", "\n");
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetBestStudents_EmptyGrades_ReturnsEmptyString()
    {
        // Arrange
        var grades = new Dictionary<string, int>();

        var expected = string.Empty;

        // Act
        var result = Grades.GetBestStudents(grades);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetBestStudents_LessThanThreeStudents_ReturnsAllStudents()
    {
        // Arrange
        var grades = new Dictionary<string, int>
    {
        { "Dimityr", 95 },
        { "Ivan", 90 }
    };

        var expected = "Dimityr with average grade 95.00\nIvan with average grade 90.00";

        // Act
        var result = Grades.GetBestStudents(grades);

        // Normalize newlines in the result
        result = result.Replace("\r\n", "\n");

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetBestStudents_SameGrade_ReturnsInAlphabeticalOrder()
    {
        // Arrange
        var grades = new Dictionary<string, int>
    {
        { "Dimityr", 90 },
        { "Ivan", 90 },
        { "Svetlin", 90 }
    };

        var expected = "Dimityr with average grade 90.00\nIvan with average grade 90.00\nSvetlin with average grade 90.00";

        // Act
        var result = Grades.GetBestStudents(grades);

        // Normalize newlines in the result
        result = result.Replace("\r\n", "\n");

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
