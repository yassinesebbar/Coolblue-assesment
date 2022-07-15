using AutoMapper;
using coolblue_assesment.Data;
using coolblue_assesment.Dtos;
using coolblue_assesment.Models;
using coolblue_assesment.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using NSubstitute;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace coolblue_assessment.Test
{
    [TestClass]
    public class ApiTests

    {
        private readonly IProductRepo _iProductRepo = Substitute.For<IProductRepo>();
        private readonly IProductTypeRepo _iProductTypeRepo = Substitute.For<IProductTypeRepo>();
        private readonly IInsuranceService _iInsuranceService = Substitute.For<IInsuranceService>();
        private readonly IMapper _mapper = Substitute.For<IMapper>();

        [TestMethod]
        public async Task CoolBlue_Slogan()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            var httpClient = webAppFactory.CreateDefaultClient();

            var response = await httpClient.GetAsync("");
            var StringResult = await response.Content.ReadAsStringAsync();

            Assert.AreEqual("Alles voor een glimlach!", StringResult);
        }

        [TestMethod]
        public async Task GetProductByID()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            var httpClient = webAppFactory.CreateDefaultClient();

            //product 572770

            String filepath = Environment.CurrentDirectory + "../../../../resources/getProductById.json";
            StreamReader jsonreader = new StreamReader(filepath);
            string jsonObjectFile = Regex.Replace(jsonreader.ReadToEnd().ToString(), "(\"(?:[^\"\\\\]|\\\\.)*\")|\\s+", "$1");

            var response = await httpClient.GetAsync("api/v1/getProduct?id=572770");
            String JsonObjectCall = await response.Content.ReadAsStringAsync();

            Assert.AreEqual(jsonObjectFile, JsonObjectCall.Trim());
        }

        [TestMethod]
        public async Task GetProductTypeByID()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            var httpClient = webAppFactory.CreateDefaultClient();

            //productType id 35
            String filepath = Environment.CurrentDirectory + "../../../../resources/getProductTypeById.json";
            StreamReader jsonreader = new StreamReader(filepath);
            string jsonObjectFile = Regex.Replace(jsonreader.ReadToEnd().ToString(), "(\"(?:[^\"\\\\]|\\\\.)*\")|\\s+", "$1");

            var response = await httpClient.GetAsync("api/v1/getProductType?id=35");
            String JsonObjectCall = await response.Content.ReadAsStringAsync();

            Assert.AreEqual(jsonObjectFile, JsonObjectCall.Trim());
        }

        [TestMethod]
        public async Task getInsuranceCostBelowMinimum()
        {
            // below 500

            var webAppFactory = new WebApplicationFactory<Program>();
            var httpClient = webAppFactory.CreateDefaultClient();

            //productType id 715990
            String filepath = Environment.CurrentDirectory + "../../../../resources/getInsuranceCost1.json";
            StreamReader jsonreader = new StreamReader(filepath);
            string jsonObjectFile = Regex.Replace(jsonreader.ReadToEnd().ToString(), "(\"(?:[^\"\\\\]|\\\\.)*\")|\\s+", "$1");

            var response = await httpClient.GetAsync("api/v1/getInsuranceCost?id=715990");
            String JsonObjectCall = await response.Content.ReadAsStringAsync();

            Assert.AreEqual(jsonObjectFile, JsonObjectCall.Trim());
        }

        [TestMethod]
        public async Task getInsuranceCostCanNotBeInsured()
        {
            //(Laptop) CanBeInsured == false 

            var webAppFactory = new WebApplicationFactory<Program>();
            var httpClient = webAppFactory.CreateDefaultClient();

            //productType id 838978
            String filepath = Environment.CurrentDirectory + "../../../../resources/getInsuranceCost2.json";
            StreamReader jsonreader = new StreamReader(filepath);
            string jsonObjectFile = Regex.Replace(jsonreader.ReadToEnd().ToString(), "(\"(?:[^\"\\\\]|\\\\.)*\")|\\s+", "$1");

            var response = await httpClient.GetAsync("api/v1/getInsuranceCost?id=838978");
            String JsonObjectCall = await response.Content.ReadAsStringAsync();

            Assert.AreEqual(jsonObjectFile, JsonObjectCall.Trim());
        }

        [TestMethod]
        public async Task getInsuranceCostCanBeInsured()
        {
            //(Laptop) CanBeInsured == true 

            var webAppFactory = new WebApplicationFactory<Program>();
            var httpClient = webAppFactory.CreateDefaultClient();

            //productType id 858421
            String filepath = Environment.CurrentDirectory + "../../../../resources/getInsuranceCost3.json";
            StreamReader jsonreader = new StreamReader(filepath);
            string jsonObjectFile = Regex.Replace(jsonreader.ReadToEnd().ToString(), "(\"(?:[^\"\\\\]|\\\\.)*\")|\\s+", "$1");

            var response = await httpClient.GetAsync("api/v1/getInsuranceCost?id=858421");
            String JsonObjectCall = await response.Content.ReadAsStringAsync();

            Assert.AreEqual(jsonObjectFile, JsonObjectCall.Trim());
        }
    }
}