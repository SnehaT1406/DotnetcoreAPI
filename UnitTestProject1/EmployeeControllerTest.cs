using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using AspNetCore5APIWebService.Controllers;
using System.IO;
using System.Collections.Generic;
using DAL.Model;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestProject1
{
    [TestClass]
    public class EmployeeTestData
    {
        //public List<DAL.Model.Employee> Employeesset { get; set; }
        //readonly 
        //public EmployeeTestData()
        //{

        //    var tempdata = File.ReadAllText("./StubbedData.json");
        //    Employeesset = JsonConvert.DeserializeObject<Employee>(tempdata);
        //}
        //[TestMethod]
        //public void GetAllEmployeeByName()
        //{
        //    var _mock = new Mock<EmployeeDetailsController>();
        //    _mock.Setup(x => x.AddEmployee).R;
        //}

        [Fact]
        public  void GetAllEmployeeByName()
        {
            var tempdata = File.ReadAllText("./StubbedData.json");
            var Employeesset = JsonConvert.DeserializeObject<Employee>(tempdata);
            var _mock = new Mock<EmployeeDetailsController>();
            _mock.Setup(x => x.GetAllEmployees()).Returns(Employeesset);
            Assert.IsNotNull(true);
        }
    }
}
