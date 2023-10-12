using AutoFixture;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Taller.Application.Admins.Dtos.MeasureUnits;
using Taller.Application.Admins.Dtos.MeasureUnits.Profiles;
using Taller.Application.Admins.Services;
using Taller.Application.Admins.Services.Implementations;
using Taller.Domain.Admins.Models;
using Taller.Domain.Admins.Repositories;

namespace Taller.UnitTest.Application.Generals.Services
{
    public class MeasureUnitServiceTest
    {
        Mock<IMeasureUnitRepository> _mockMeasureUnitRepository;
        Mock<ILogger<MeasureUnitsService>> _mockILoggger;
        IMapper _mapper;

        Fixture _fixture;

        public MeasureUnitServiceTest()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<MeasureUnitProfile>();
            });

            _mapper = mapperConfiguration.CreateMapper();

            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            _mockMeasureUnitRepository = new Mock<IMeasureUnitRepository>();
            _mockILoggger = new Mock<ILogger<MeasureUnitsService>>();
        }


        [Fact]
        public async void returnMeasureUnitDtoWhenFindByIdAsync()
        {
            //Arange
            MeasureUnit muasureUnit = _fixture.Create<MeasureUnit>();

            _mockMeasureUnitRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(muasureUnit);

            //Act

           IMeasureUnitService measureUnitService = new MeasureUnitsService(_mockMeasureUnitRepository.Object, _mapper, _mockILoggger.Object);

            MeasureUnitDto measureUnitDto = await measureUnitService.FindByIdAsync(muasureUnit.Id);

            //Asset

            Assert.Equal(muasureUnit.Name, measureUnitDto.Name);

        }

        [Fact]
        public async void returnMeasureUnitsDtoWhenFindAllAsync()
        {
            //Arange
            IReadOnlyList<MeasureUnit> measureUnits = _fixture.CreateMany<MeasureUnit>(5).ToList();

            _mockMeasureUnitRepository
                .Setup(r => r.FindAllAsync())
                .ReturnsAsync(measureUnits);

            //Act

            IMeasureUnitService measureUnitService = new MeasureUnitsService(_mockMeasureUnitRepository.Object, _mapper, _mockILoggger.Object);

            IReadOnlyList<MeasureUnitDto> measureUnitDtos = await measureUnitService.FindAllAsync();

            //Asset

            Assert.Equal(measureUnits.Count, measureUnitDtos.Count);
        }

        [Fact]
        public async void returnMeasureUnitsDtoWhenCreateAsync()
        {
            //Arange
            MeasureUnit measureUnit = new()
            {
                Id = 1,
                Name = "Toneladas",
                Description = "Pero en toneladas",
                Symbol = "TN",
                State = true,
                RegistrationDate = DateTime.Now

            };

            _mockMeasureUnitRepository
                .Setup(r => r.SaveAsync(It.IsAny<MeasureUnit>()))
                .ReturnsAsync(measureUnit);

            //Act

            MeasureUnitSaveDto measureUnitsaveDto = new()
            {
                Name = measureUnit.Name,
                Description = measureUnit.Description,
                Symbol = measureUnit.Symbol,
            };

            IMeasureUnitService measureUnitService = new MeasureUnitsService(_mockMeasureUnitRepository.Object, _mapper, _mockILoggger.Object);
            MeasureUnitDto measureUnitDto = await measureUnitService.CreateAsync(measureUnitsaveDto);

            //Assert

            Assert.Equal(measureUnit.Name, measureUnitDto.Name);
        }


        [Fact]
        public async void returnMeasureUnitsDtoWhenEditAsync()
        {
            //Arange
            MeasureUnit measureUnit = new()
            {
                Id = 1,
                Name = "Toneladas",
                Description = "Pero en toneladas",
                Symbol = "TN",
                State = true,
                RegistrationDate = DateTime.Now

            };

            _mockMeasureUnitRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(measureUnit);

            _mockMeasureUnitRepository
                .Setup(r => r.SaveAsync(It.IsAny<MeasureUnit>()))
                .ReturnsAsync(measureUnit);

            //Act

            MeasureUnitSaveDto measureUnitsaveDto = new()
            {
                Name = measureUnit.Name,
                Description = measureUnit.Description,
                Symbol = measureUnit.Symbol,
            };

            IMeasureUnitService measureUnitService = new MeasureUnitsService(_mockMeasureUnitRepository.Object, _mapper, _mockILoggger.Object);
            MeasureUnitDto measureUnitDto = await measureUnitService.EditAsync(measureUnit.Id, measureUnitsaveDto);

            //Assert

            Assert.Equal(measureUnit.Id, measureUnitDto.Id);
        }


        [Fact]
        public async void returnMeasureUnitsDtoWhenDisabledAsync()
        {
            //Arange
            MeasureUnit measureUnit = new()
            {
                Id = 1,
                Name = "Toneladas",
                Description = "Pero en toneladas",
                Symbol = "TN",
                State = true,
                RegistrationDate = DateTime.Now

            };

            _mockMeasureUnitRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(measureUnit);

            _mockMeasureUnitRepository
                .Setup(r => r.SaveAsync(It.IsAny<MeasureUnit>()))
                .ReturnsAsync(measureUnit);

            //Act

           

            IMeasureUnitService measureUnitService = new MeasureUnitsService(_mockMeasureUnitRepository.Object, _mapper, _mockILoggger.Object);
            MeasureUnitDto measureUnitDto = await measureUnitService.DiasabledAsync(measureUnit.Id);

            //Assert

            Assert.Equal(measureUnit.State, measureUnitDto.State);
        }
    }
}
