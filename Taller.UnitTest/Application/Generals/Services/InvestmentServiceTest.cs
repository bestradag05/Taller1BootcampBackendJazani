using AutoFixture;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Application.Admins.Dtos.Investments;
using Taller.Application.Admins.Services.Implementations;
using Taller.Application.Admins.Services;
using Taller.Domain.Admins.Models;
using Taller.Domain.Admins.Repositories;
using Taller.Application.Admins.Dtos.Investments.Profiles;
using Taller.Application.Admins.Dtos.Holders.Profiles;
using Taller.Application.Admins.Dtos.InvestmentConcepts.Profiles;
using Taller.Application.Admins.Dtos.InvestmentTypes.Profiles;
using Taller.Application.Admins.Dtos.MeasureUnits.Profiles;
using Taller.Application.Admins.Dtos.MiningConsessions.Profiles;
using Taller.Application.Admins.Dtos.PeriodTypes.Profiles;
using Taller.Application.Admins.Dtos.Documents.Profiles;

namespace Taller.UnitTest.Application.Generals.Services
{
    public class InvestmentServiceTest
    {
        Mock<IInvestmentRepository> _mockInvestmentRepository;
        Mock<ILogger<InvestmentService>> _mockILoggger;
        IMapper _mapper;

        Fixture _fixture;

        public InvestmentServiceTest()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<InvestmentProfile>();
                c.AddProfile<DocumentProfile>();
                c.AddProfile<HoldeProfile>();
                c.AddProfile<InvestmentConceptProfile>();
                c.AddProfile<InvestmentTypeProfile>();
                c.AddProfile<MiningConsessionProfile>();
                c.AddProfile<PeriodTypeProfile>();
                c.AddProfile<MeasureUnitProfile>();
            });

            _mapper = mapperConfiguration.CreateMapper();

            _fixture = new();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            _mockInvestmentRepository = new Mock<IInvestmentRepository>();
            _mockILoggger = new Mock<ILogger<InvestmentService>>();
        }



        [Fact]
        public async void returnInvestmentDtoWhenFindByIdAsync()
        {
            //Arange
            Investment investment = _fixture.Create<Investment>();

            _mockInvestmentRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(investment);

            //Act

            IInvestmentService investmentService = new InvestmentService(_mockInvestmentRepository.Object, _mapper, _mockILoggger.Object);

            InvestmentDto investmentDto = await investmentService.FindByIdAsync(investment.Id);

            //Asset

            Assert.Equal(investment.AccountantCode, investmentDto.AccountantCode);

        }

        [Fact]
        public async void returnInvestmentsDtoWhenFindAllAsync()
        {
            //Arange
            IReadOnlyList<Investment> investments = _fixture.CreateMany<Investment>(5).ToList();

            _mockInvestmentRepository
                .Setup(r => r.FindAllAsync())
                .ReturnsAsync(investments);

            //Act

            IInvestmentService investmentService = new InvestmentService(_mockInvestmentRepository.Object, _mapper, _mockILoggger.Object);

            IReadOnlyList<InvestmentDto> investmentDtos = await investmentService.findAllAsync();

            //Asset

            Assert.Equal(investments.Count, investmentDtos.Count);
        }

        [Fact]
        public async void returnInvestmentsDtoWhenCreateAsync()
        {
            //Arange
            Investment investment = new()
            {
                AmountInvestd = 100,
                Year = 2023,
                Description = "Registro creado por Sage, modificado",
                AccountantCode = "",
                DocumentId = 34146,
                HolderId = 3,
                DeclaredTypeId = 1,
                InvestmentConceptId = 9,
                InvestmentTypeId = 1,
                CurrencyTypeId = 1,
                MeasureUnitId = 1,
                MiningConcessionId = 15,
                PeriodTypeId = 1,
                State = true,
                RegistrationDate = DateTime.Now

            };

            _mockInvestmentRepository
                .Setup(r => r.SaveAsync(It.IsAny<Investment>()))
                .ReturnsAsync(investment);

            //Act

            InvestmentSaveDto investmentsaveDto = new()
            {
                AmountInvestd = investment.AmountInvestd,
                Year = investment.Year,
                Description = investment.Description,
                AccountantCode = investment.AccountantCode,
                DocumentId = investment.DocumentId,
                HolderId = investment.HolderId,
                DeclaredTypeId = investment.DeclaredTypeId,
                InvestmentConceptId = investment.InvestmentConceptId,
                InvestmentTypeId = investment.InvestmentTypeId,
                CurrencyTypeId = investment.CurrencyTypeId,
                MeasureUnitId = investment.MeasureUnitId,
                MiningConcessionId = investment.MiningConcessionId,
                PeriodTypeId = investment.PeriodTypeId

            };

            IInvestmentService investmentService = new InvestmentService(_mockInvestmentRepository.Object, _mapper, _mockILoggger.Object);
            InvestmentDto InvestmentDto = await investmentService.CreateAsync(investmentsaveDto);

            //Assert

            Assert.Equal(investment.Id, InvestmentDto.Id);
        }


        [Fact]
        public async void returnInvestmentsDtoWhenEditAsync()
        {
            //Arange
            Investment investment = new()
            {
                AmountInvestd = 100,
                Year = 2023,
                Description = "Registro creado por Sage, modificado",
                AccountantCode = "",
                DocumentId = 34146,
                HolderId = 3,
                DeclaredTypeId = 1,
                InvestmentConceptId = 9,
                InvestmentTypeId = 1,
                CurrencyTypeId = 1,
                MeasureUnitId = 1,
                MiningConcessionId = 15,
                PeriodTypeId = 1,
                State = true,
                RegistrationDate = DateTime.Now

            };

            _mockInvestmentRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(investment);

            _mockInvestmentRepository
                .Setup(r => r.SaveAsync(It.IsAny<Investment>()))
                .ReturnsAsync(investment);

            //Act

            InvestmentSaveDto investmentsaveDto = new()
            {
                AmountInvestd = investment.AmountInvestd,
                Year = investment.Year,
                Description = investment.Description,
                AccountantCode = investment.AccountantCode,
                DocumentId = investment.DocumentId,
                HolderId = investment.HolderId,
                DeclaredTypeId = investment.DeclaredTypeId,
                InvestmentConceptId = investment.InvestmentConceptId,
                InvestmentTypeId = investment.InvestmentTypeId,
                CurrencyTypeId = investment.CurrencyTypeId,
                MeasureUnitId = investment.MeasureUnitId,
                MiningConcessionId = investment.MiningConcessionId,
                PeriodTypeId = investment.PeriodTypeId

            };

            IInvestmentService investmentService = new InvestmentService(_mockInvestmentRepository.Object, _mapper, _mockILoggger.Object);
            InvestmentDto InvestmentDto = await investmentService.EditAsync(investment.Id, investmentsaveDto);

            //Assert

            Assert.Equal(investment.Id, InvestmentDto.Id);
        }


        [Fact]
        public async void returnInvestmentsDtoWhenDisabledAsync()
        {
            //Arange
            Investment investment = new()
            {
                AmountInvestd = 100,
                Year = 2023,
                Description = "Registro creado por Sage, modificado",
                AccountantCode = "",
                DocumentId = 34146,
                HolderId = 3,
                DeclaredTypeId = 1,
                InvestmentConceptId = 9,
                InvestmentTypeId = 1,
                CurrencyTypeId = 1,
                MeasureUnitId = 1,
                MiningConcessionId = 15,
                PeriodTypeId = 1,
                State = true,
                RegistrationDate = DateTime.Now

            };

            _mockInvestmentRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(investment);

            _mockInvestmentRepository
                .Setup(r => r.SaveAsync(It.IsAny<Investment>()))
                .ReturnsAsync(investment);

            //Act

           

            IInvestmentService investmentService = new InvestmentService(_mockInvestmentRepository.Object, _mapper, _mockILoggger.Object);
            InvestmentDto InvestmentDto = await investmentService.DisabledAsync(investment.Id);

            //Assert

            Assert.Equal(investment.State, InvestmentDto.State);
        }

    }
}
