using AutoFixture;
using Moq;
using NorthWind.Models;
using NorthWind.UnitOfWork;
using NortWind.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace NorthWind.BusinessLogic.Test.Mocked
{
    public class CustomerRepositoryMocked
    {
        private readonly List<Customer> _customers;

        public CustomerRepositoryMocked() 
        {
            _customers = Customers();
        }

        public IUnitOfWork GetInstance() 
        {
            var mocked = new Mock<IUnitOfWork>();
            mocked.Setup(u => u.Customer)
                  .Returns(GetCustomerRepositoryMocked());
            return mocked.Object;
        }


        public ICustomerRepository GetCustomerRepositoryMocked() 
        {
            var customerMocked = new Mock<ICustomerRepository>();

            customerMocked.Setup(x => x.GetById(It.IsAny<int>())) 
                          .Returns((int id) => _customers.FirstOrDefault(x => x.Id == id));

            customerMocked.Setup(x => x.Insert(It.IsAny<Customer>()))
                          .Callback<Customer>((y) => _customers.Add(y))
                          .Returns<Customer>(z => z.Id);

            customerMocked.Setup(x => x.Update(It.IsAny<Customer>()))
                          .Callback<Customer>((x) => 
                          { 
                              _customers.RemoveAll(y => y.Id == x.Id); 
                              _customers.Add(x); 
                          })
                          .Returns(true);

            return customerMocked.Object;
        }


        public List<Customer> Customers() 
        {
            var fixture = new Fixture();
            var customers = fixture.CreateMany<Customer>(50).ToList();
            for (int i = 0; i < 50; i++)
            {
                customers[i].Id = i + 1;
            }

            return customers; 
        }
    }
}
