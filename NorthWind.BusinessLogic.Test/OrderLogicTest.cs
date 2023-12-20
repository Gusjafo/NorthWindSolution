using FluentAssertions;
using NorthWind.BusinessLogic.Implementations;
using NorthWind.BusinessLogic.Interfaces;
using NorthWind.BusinessLogic.Test.Mocked;
using NorthWind.UnitOfWork;
using Xunit;

namespace NorthWind.BusinessLogic.Test
{
    public class OrderLogicTest
    {
        private readonly IUnitOfWork _unitMocked;
        private readonly IOrderLogic _orderLogic;

        public OrderLogicTest()
        {
            var unitMocked = new OrderRepositoryMocked();
            _unitMocked = unitMocked.GetInstance();
            _orderLogic = new OrderLogic(_unitMocked);
        }

        [Fact]
        public void GetOrderNumber_Order_Test()
        {
            var result = _orderLogic.GetOrderNumber(1);
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
        }
    }
}
