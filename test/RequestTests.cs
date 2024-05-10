using SavePointAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using SavePointAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace test;


public class RequestTests
{
    [Fact]
    public async void TestPostGame()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<SavePointContext>()
            .UseInMemoryDatabase(databaseName: "SavePointGames")
            .Options;
        var context = new SavePointContext(options);
        var controller = new SavePointGamesController(context);

        // Mocking the SavePointGameDTO object
        var savePointGameDTO = new SavePointGameDTO
        {
            SavePointGameId = 0,
            GameName = "Test Game",
            GameGenre = "Test Genre",
            GameConsole = "Test Platform"
        };
        // Act
        var result = await controller.PostSavePointGame(savePointGameDTO);

        // Assert
        Assert.IsAssignableFrom<ActionResult<SavePointGame>>(result);
    }

    [Fact]
    public async void TestGetGame()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<SavePointContext>()
            .UseInMemoryDatabase(databaseName: "SavePointGames")
            .Options;
        var context = new SavePointContext(options);
        var controller = new SavePointGamesController(context);

        // Act
        var result = await controller.GetSavePointGames();

        // Assert
        Assert.IsAssignableFrom<ActionResult<IEnumerable<SavePointGameDTO>>>(result);
    }

    [Fact]
    public async void TestGetGameById()
    {
        var options = new DbContextOptionsBuilder<SavePointContext>()
            .UseInMemoryDatabase(databaseName: "SavePointGames")
            .Options;
        var context = new SavePointContext(options);
        var controller = new SavePointGamesController(context);

        // Act
        var result = await controller.GetSavePointGame(1);

        // Assert
        Assert.IsAssignableFrom<ActionResult<SavePointGameDTO>>(result);
    }
    
    // TOOD: Fix this test
    // [Fact]
    // public async void TestPutGame()
    // {
        // // Arrange
        // var options = new DbContextOptionsBuilder<SavePointContext>()
            // .UseInMemoryDatabase(databaseName: "SavePointGames")
            // .Options;
        // var context = new SavePointContext(options);
        // var controller = new SavePointGamesController(context);

        // // Mocking the SavePointGameDTO object
        // var savePointGameDTO = new SavePointGameDTO
        // {
            // SavePointGameId = 1,
            // GameName = "Test Game",
            // GameGenre = "Test Genre",
            // GameConsole = "Test Platform"
        // };
        // await controller.PostSavePointGame(savePointGameDTO);

        // savePointGameDTO = new SavePointGameDTO
        // {
            // SavePointGameId = 1,
            // GameName = "Test Game Updated",
            // GameGenre = "Test Genre Updated",
            // GameConsole = "Test Platform Updated"
        // };
        // // Act
        // var result = await controller.PutSavePointGame(1, savePointGameDTO);

        // // Assert
        // Assert.IsType<NoContentResult>(result);
    // }

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
            SavePointGame = new SavePointGame
            {
                SavePointGameId = 0,
                GameName = "Test Game",
                GameGenre = "Test Genre",
                GameConsole = "Test Platform"
            }
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
        var game = new SavePointGame
        {
            SavePointGameId = 1,
            GameName = "Test Game",
            GameGenre = "Test Genre",
            GameConsole = "Test Platform"
        };
        // Mocking the SavePointNoteDTO object
        var savePointNoteDTO = new SavePointNoteDTO
        {
            SavePointNoteId = 1,
            Note = "Test Note!",
            SavePointGame = game        
            
        };
        await controller.PostSavePointNote(savePointNoteDTO);

        savePointNoteDTO = new SavePointNoteDTO
        {
            SavePointNoteId = 1,
            Note = "Test Note Updated!",
            // TODO: Get the previous SavePointGame
            SavePointGame = game
        };
        // Act
        var result = await controller.PutSavePointNote(1, savePointNoteDTO);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

}