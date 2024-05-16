using Moq;
using MyFirstBackend.Business.Services;
using MyFirstBackend.Core.Dtos;
using MyFirstBackend.DataLayer.Repositories;
using MyFirstBackend.Core.Exeptions;
using AutoMapper;
using MyFirstBackend.Business.Automapping;
namespace MyFirstBackend.Business.Test.Services;


public class UserServiceTest
{
    private const string _guidPattern = "^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$";
    private readonly Mock<IUsersRepository> _usersRepositoryMock;
   private readonly IMapper _mapper;
    public UserServiceTest()
    {
        _usersRepositoryMock = new Mock<IUsersRepository>();
        var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
        _mapper = config.CreateMapper();

    }
    [Fact]
    public void AddUser_ValidDtoSent_GuidReserved()
    {
        //arrange
        var validUserDto = new UserDto()
        {
            Age = 21,
            Email = "tt@uo.tu",
            Password = "password",
            UserName = "Test",
        };
        var expectedGuid= Guid.NewGuid();
        _usersRepositoryMock.Setup(x => x.AddUser(It.IsAny<UserDto>())).Returns(expectedGuid);
        var sut = new UsersService(_usersRepositoryMock.Object, _mapper);
        //act
        var actual = sut.AddUser(validUserDto);

        //assert
        Assert.Equal(expectedGuid, actual);
        _usersRepositoryMock.Verify(x => x.AddUser(It.IsAny<UserDto>()), Times.Once);
    }
    [Fact]
    public void AddUser_DtoWithInValidAgeSent_AgeErrorReserved()
    {
        //arrange
        var invalidUserDto = new UserDto()
        {
            Age = 12,
            Email = "tt@uo.tu",
            Password = "password",
            UserName = "Test",
        };
        var expectedGuid = Guid.NewGuid();
        _usersRepositoryMock.Setup(x => x.AddUser(It.IsAny<UserDto>())).Returns(expectedGuid);
        var sut = new UsersService(_usersRepositoryMock.Object, _mapper);
        //act, assert
        Assert.Throws<ValidationException>(() =>sut.AddUser(invalidUserDto));
        _usersRepositoryMock.Verify(x => x.AddUser(It.IsAny<UserDto>()), Times.Never);

    }
    [Theory]
    [InlineData(null)]
    [InlineData("pass")]
    [InlineData("")]
    public void AddUser_DtoWithInValidPasswordSent_PasswordErrorReserved(string password)
    {
        //arrange
        var invalidUserDto = new UserDto()
        {
            Age = 21,
            Email = "tt@uo.tu",
            Password = password,
            UserName = "Test",
        };
        var expectedGuid = Guid.NewGuid();
        _usersRepositoryMock.Setup(x => x.AddUser(It.IsAny<UserDto>())).Returns(expectedGuid);
        var sut = new UsersService(_usersRepositoryMock.Object, _mapper);
        //act, assert
        Assert.Throws<ValidationException>(() => sut.AddUser(invalidUserDto));
        _usersRepositoryMock.Verify(x => x.AddUser(It.IsAny<UserDto>()), Times.Never);

    }
    [Fact]
    public void GetUsers_Called_UsersReserved()
    {
        //arrange
        var dto1 = new UserDto() { Email = "pp@pp.tu" };
        var dto2 = new UserDto() { Email = "gg@gg.ru" };
        var expected = new List<UserDto>() { dto1, dto2 };
        var expected2 = new List<UserDto>() { dto1, dto2 };
        _usersRepositoryMock.Setup(x => x.GetUsers()).Returns(expected);
        var sut = new UsersService(_usersRepositoryMock.Object, _mapper );
        //act
        var actual = sut.GetUsers();

        //assert
        Assert.Equal(expected, actual);
        _usersRepositoryMock.Verify(x => x.GetUsers(), Times.Once);
    }
    [Fact]
    public void DeleteUserById_ValidGuidSent_NoErrorsReserved()
    {
        //arrange
        var userId = Guid.NewGuid();
       _usersRepositoryMock.Setup(x => x.GetUserById(userId)).Returns(new UserDto());
        var sut = new UsersService(_usersRepositoryMock.Object, _mapper);
        //act
        sut.DeleteUserById(userId);

        //assert
        _usersRepositoryMock.Verify(x => x.GetUserById(userId), Times.Once);
        _usersRepositoryMock.Verify(x => x.DeleteUserById(userId), Times.Once);
    }
    [Fact]
    public void DeleteUserById_EmptyGuidSent_UserNotFoundErrorsReserved()
    {
        //arrange
        var userId = Guid.Empty;
        _usersRepositoryMock.Setup(x => x.GetUserById(userId)).Returns(new UserDto());
        var sut = new UsersService(_usersRepositoryMock.Object, _mapper);
        //act, assert
        Assert.Throws<NotFoundExeption>(() => sut.DeleteUserById(userId));
        _usersRepositoryMock.Verify(x => x.GetUserById(userId), Times.Once);
        _usersRepositoryMock.Verify(x => x.DeleteUserById(userId), Times.Never);
    }
    [Fact]
    public void 


}