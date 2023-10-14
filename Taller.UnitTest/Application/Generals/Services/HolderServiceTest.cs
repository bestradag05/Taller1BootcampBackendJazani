using AutoFixture;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Taller.Application.Admins.Dtos.Holders;
using Taller.Application.Admins.Dtos.Holders.Profiles;
using Taller.Application.Admins.Services;
using Taller.Application.Admins.Services.Implementations;
using Taller.Domain.Admins.Models;
using Taller.Domain.Admins.Repositories;

namespace Taller.UnitTest.Application.Generals.Services
{
    public class HolderServiceTest
    {
        Mock<IHolderRepository> _mockHolderRepository;
        Mock<ILogger<HolderService>> _mockILoggger;
        IMapper _mapper;

        Fixture _fixture;

        public HolderServiceTest()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<HoldeProfile>();
            });

            _mapper = mapperConfiguration.CreateMapper();

            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            _mockHolderRepository = new Mock<IHolderRepository>();
            _mockILoggger = new Mock<ILogger<HolderService>>();
        }



        [Fact]
        public async void returnHolderDtoWhenFindByIdAsync()
        {
            //Arange
            Holder holder = _fixture.Create<Holder>();

            _mockHolderRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(holder);

            //Act

            IHolderService holderService = new HolderService(_mockHolderRepository.Object, _mapper, _mockILoggger.Object);

            HolderDto HolderDto = await holderService.FindByIdAsync(holder.Id);

            //Asset

            Assert.Equal(holder.Name, HolderDto.Name);

        }

        [Fact]
        public async void returnHoldersDtoWhenFindAllAsync()
        {
            //Arange
            IReadOnlyList<Holder> holders = _fixture.CreateMany<Holder>(5).ToList();

            _mockHolderRepository
                .Setup(r => r.FindAllAsync())
                .ReturnsAsync(holders);

            //Act

            IHolderService holderService = new HolderService(_mockHolderRepository.Object, _mapper, _mockILoggger.Object);

            IReadOnlyList<HolderDto> holderDtos = await holderService.findAllAsync();

            //Asset

            Assert.Equal(holders.Count, holderDtos.Count);
        }

        [Fact]
        public async void returnHoldersDtoWhenCreateAsync()
        {
            //Arange
            Holder holder = new()
            {
                Id = 1,
                Name = "Minera Peru S.A.C",
                LastName = "Minera",
                MaidenName = "Test",
                DocumentNumber = "205532323",
                HolderregimeId = 1,
                HoldergroupId = 1,
                RegistryOfficeId = 1,
                IdentificationDocumentId = 1,
                HoldertypeId = 1,
                State = true,
                RegistrationDate = DateTime.Now

            };

            _mockHolderRepository
                .Setup(r => r.SaveAsync(It.IsAny<Holder>()))
                .ReturnsAsync(holder);

            //Act

            HolderSaveDto holdersaveDto = new()
            {
           
                Name = holder.Name,
                LastName = holder.LastName,
                MaidenName = holder.MaidenName,
                DocumentNumber = holder.DocumentNumber,
                HolderregimeId = holder.HolderregimeId,
                HoldergroupId = holder.HoldergroupId,
                RegistryOfficeId = holder.RegistryOfficeId,
                IdentificationDocumentId = holder.IdentificationDocumentId,
                HoldertypeId = holder.HoldertypeId,

            };

            IHolderService holderService = new HolderService(_mockHolderRepository.Object, _mapper, _mockILoggger.Object);
            HolderDto holderDto = await holderService.CreateAsync(holdersaveDto);

            //Assert

            Assert.Equal(holder.Name, holderDto.Name);
        }


        [Fact]
        public async void returnHoldersDtoWhenEditAsync()
        {
            //Arange
            Holder holder = new()
            {
                Id = 1,
                Name = "Minera Peru S.A.C",
                LastName = "Minera",
                MaidenName = "Test",
                DocumentNumber = "205532323",
                HolderregimeId = 1,
                HoldergroupId = 1,
                RegistryOfficeId = 1,
                IdentificationDocumentId = 1,
                HoldertypeId = 1,
                State = true,
                RegistrationDate = DateTime.Now

            };

            _mockHolderRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(holder);

            _mockHolderRepository
                .Setup(r => r.SaveAsync(It.IsAny<Holder>()))
                .ReturnsAsync(holder);

            //Act

            HolderSaveDto holdersaveDto = new()
            {

                Name = holder.Name,
                LastName = holder.LastName,
                MaidenName = holder.MaidenName,
                DocumentNumber = holder.DocumentNumber,
                HolderregimeId = holder.HolderregimeId,
                HoldergroupId = holder.HoldergroupId,
                RegistryOfficeId = holder.RegistryOfficeId,
                IdentificationDocumentId = holder.IdentificationDocumentId,
                HoldertypeId = holder.HoldertypeId,

            };

            IHolderService holderService = new HolderService(_mockHolderRepository.Object, _mapper, _mockILoggger.Object);
            HolderDto holderDto = await holderService.EditAsync(holder.Id, holdersaveDto);

            //Assert

            Assert.Equal(holder.Id, holderDto.Id);
        }


        [Fact]
        public async void returnHoldersDtoWhenDisabledAsync()
        {
            //Arange
            Holder holder = new()
            {
                Id = 1,
                Name = "Minera Peru S.A.C",
                LastName = "Minera",
                MaidenName = "Test",
                DocumentNumber = "205532323",
                HolderregimeId = 1,
                HoldergroupId = 1,
                RegistryOfficeId = 1,
                IdentificationDocumentId = 1,
                HoldertypeId = 1,
                State = true,
                RegistrationDate = DateTime.Now

            };

            _mockHolderRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(holder);

            _mockHolderRepository
                .Setup(r => r.SaveAsync(It.IsAny<Holder>()))
                .ReturnsAsync(holder);

            //Act

          

            IHolderService holderService = new HolderService(_mockHolderRepository.Object, _mapper, _mockILoggger.Object);
            HolderDto holderDto = await holderService.DisabledAsync(holder.Id);

            //Assert

            Assert.Equal(holder.State, holderDto.State);
        }

    }
}
