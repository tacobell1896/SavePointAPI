namespace test;

using SavePointAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using SavePointAPI.Models;
using Microsoft.EntityFrameworkCore;

public class RequestTests
{
    [Fact]
    public void TestPostNote()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<SavePointContext>()
            .UseInMemoryDatabase(databaseName: "SavePointNotes")
            .Options;
        var context = new SavePointContext(options);
        var controller = new SavePointNotesController(context);

        // Mocking the SavePointNoteDTO object
        var savePointNoteDTO = new SavePointNoteDTO
        {
            SavePointNoteId = 1,
            Note = "Test Note",
            GameName = "Test Game"
        };
        // Act
        var result = controller.PostSavePointNote(savePointNoteDTO);

        // Assert
        Assert.IsType<CreatedAtActionResult>(result);
    }
    [Fact]
    public void TestGetNote()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<SavePointContext>()
            .UseInMemoryDatabase(databaseName: "SavePointNotes")
            .Options;
        var context = new SavePointContext(options);
        var controller = new SavePointNotesController(context);

        // Act
        var result = controller.GetSavePointNotes();

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void TestGetNoteById()
    {
        var options = new DbContextOptionsBuilder<SavePointContext>()
            .UseInMemoryDatabase(databaseName: "SavePointNotes")
            .Options;
        var context = new SavePointContext(options);
        var controller = new SavePointNotesController(context);

        // Act
        var result = controller.GetSavePointNote(1);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void TestPutNote()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<SavePointContext>()
            .UseInMemoryDatabase(databaseName: "SavePointNotes")
            .Options;
        var context = new SavePointContext(options);
        var controller = new SavePointNotesController(context);

        // Act
        var result = controller.PutSavePointNote(1, new SavePointNoteDTO());

        // Assert
        Assert.IsType<OkResult>(result);
    }

}