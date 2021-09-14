using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Framework.Teste.Entities.Dtos;
using Framework.Teste.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Framework.Teste.Test.Services
{
    public class DecomposeServiceTest : IClassFixture<ConfigureServiceFixure>
    {
        private readonly ConfigureServiceFixure _fixure;

        public DecomposeServiceTest(ConfigureServiceFixure fixure)
        {
            _fixure = fixure;
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async Task Decompose_Shoud_be_true(int number, DecomposeNumbers expected)
        {
            var service = _fixure.Services.GetService<IDecomposeService>();

            var result = await service.DecomposeAsync(number);
            result.Should().BeEquivalentTo(expected);
        }
        
        
        
        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { 290, new DecomposeNumbers{ Dividers = new List<int>{1, 2, 5, 10, 29, 58, 145, 290}, Input = 290,PrimeDividers = new List<int>{2,5,29} } },
                new object[] { 45, new DecomposeNumbers{ Dividers = new List<int>{1, 3, 5, 9, 15, 45}, Input = 45,PrimeDividers = new List<int>{3,5} } },
                new object[] { 720, new DecomposeNumbers{ Dividers = new List<int>{1, 2, 3, 4, 5, 6, 8, 9, 10, 12, 15, 16, 18, 20, 24, 30, 36, 40, 45, 48, 60, 72, 80, 90, 120, 144, 180, 240, 360, 720}, Input = 720,PrimeDividers = new List<int>{2,3,5} } },
                new object[] { 300, new DecomposeNumbers{ Dividers = new List<int>{1, 2, 3, 4, 5, 6, 10, 12, 15, 20, 25, 30, 50, 60, 75, 100, 150, 300}, Input = 300,PrimeDividers = new List<int>{2,3,5} } },
                new object[] { 250, new DecomposeNumbers{ Dividers = new List<int>{1, 2, 5, 10, 25, 50, 125, 250}, Input = 250,PrimeDividers = new List<int>{2,5} } },
                new object[] { 65, new DecomposeNumbers{ Dividers = new List<int>{1, 5, 13, 65}, Input = 65,PrimeDividers = new List<int>{5,13} } },
                new object[] { 82, new DecomposeNumbers{ Dividers = new List<int>{1, 2, 41, 82}, Input = 82,PrimeDividers = new List<int>{2,41} } },
                new object[] { 155, new DecomposeNumbers{ Dividers = new List<int>{1, 5, 31, 155}, Input = 155,PrimeDividers = new List<int>{5,31} } },
                new object[] { 93, new DecomposeNumbers{ Dividers = new List<int>{1, 3, 31, 93}, Input = 93,PrimeDividers = new List<int>{3,31} } },
                new object[] { 395, new DecomposeNumbers{ Dividers = new List<int>{1, 5, 79, 395}, Input = 395,PrimeDividers = new List<int>{5, 79} } },
                new object[] { 555, new DecomposeNumbers{ Dividers = new List<int>{1, 3, 5, 15, 37, 111, 185, 555}, Input = 555,PrimeDividers = new List<int>{3,5,37} } },
                
                
            };
    }
}