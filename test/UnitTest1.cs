using SavePointAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using SavePointAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace test;


public class RequestTests
{
    [Fact]
    public async void TestPostNote()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<SavePointContext>()
            .UseInMemoryDatabase(databaseName: "SavePointList")
            .Options;
        var context = new SavePointContext(options);
        var controller = new SavePointNotesController(context);

        // Mocking the SavePointNoteDTO object
        var savePointNoteDTO = new SavePointNoteDTO
        {
            SavePointNoteId = 0,
            Note = "Test Note",
            GameName = "Test Game"
        };
        // Act
        var result = await controller.PostSavePointNote(savePointNoteDTO);

        // Assert
        Assert.IsAssignableFrom<ActionResult<SavePointNote>>(result);
    }
    [Fact]
    public async void TestGetNote()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<SavePointContext>()
            .UseInMemoryDatabase(databaseName: "SavePointNotes")
            .Options;
        var context = new SavePointContext(options);
        var controller = new SavePointNotesController(context);

        // Act
        var result = await controller.GetSavePointNotes();

        // Assert
        Assert.IsAssignableFrom<ActionResult<IEnumerable<SavePointNoteDTO>>>(result);
    }

    [Fact]
    public async void TestGetNoteById()
    {
        var options = new DbContextOptionsBuilder<SavePointContext>()
            .UseInMemoryDatabase(databaseName: "SavePointNotes")
            .Options;
        var context = new SavePointContext(options);
        var controller = new SavePointNotesController(context);

        // Act
        var result = await controller.GetSavePointNote(1);

        // Assert
        Assert.IsAssignableFrom<ActionResult<SavePointNoteDTO>>(result);
    }

    [Fact]
    public async void TestPutNote()
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
            Note = "Test Note!",
            GameName = "Test Game"
        };
        await controller.PostSavePointNote(savePointNoteDTO);

        savePointNoteDTO = new SavePointNoteDTO
        {
            SavePointNoteId = 1,
            Note = "Test Note Updated!",
            GameName = "Test Game"
        };
        // Act
        var result = await controller.PutSavePointNote(1, savePointNoteDTO);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

}