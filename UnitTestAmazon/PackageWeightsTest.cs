using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace UnitTestAmazon
{
    [TestClass]
    public class PackageWeightsTest
    {
        string url = "http://localhost:60752/";

        
        [TestMethod]
        public void Test1()
        {
            int ValueExpected = 21;
            int ResponseValue = 0;
            string json = "{'packageWeights':[2,9,10,3,7]}";
            ResponseValue = ServiceExecution(json);
            Assert.AreEqual(ValueExpected, ResponseValue);
        }
        [TestMethod]
        public void Test2()
        {
            int ValueExpected = 54;
            int ResponseValue = 0;
            string json = "{'packageWeights':[4,20,13,8,9]}";
            ResponseValue = ServiceExecution(json);
            Assert.AreEqual(ValueExpected, ResponseValue);
        }
        [TestMethod]
        public void Test3()
        {
            int ValueExpected = 37;
            int ResponseValue = 0;
            string json = "{'packageWeights':[7,10,20,4,3,10]}";
            ResponseValue = ServiceExecution(json);
            Assert.AreEqual(ValueExpected, ResponseValue);
        }
        [TestMethod]
        public void Test4()
        {
            int ValueExpected = 64;
            int ResponseValue = 0;
            string json = "{'packageWeights':[20,5,9,30,10,2,3,1]}";
            ResponseValue = ServiceExecution(json);
            Assert.AreEqual(ValueExpected, ResponseValue);
        }
        [TestMethod]
        public void Test5()
        {
            int ValueExpected = 98;
            int ResponseValue = 0;
            string json = "{'packageWeights':[30,10,5,20,33,2]}";
            ResponseValue = ServiceExecution(json);
            Assert.AreEqual(ValueExpected, ResponseValue);
        }
        [TestMethod]
        public void Test6()
        {
            int ValueExpected = 72;
            int ResponseValue = 0;
            string json = "{'packageWeights':[30,2,10,30,2,1]}";
            ResponseValue = ServiceExecution(json);
            Assert.AreEqual(ValueExpected, ResponseValue);
        }
        [TestMethod]
        public void Test7()
        {
            int ValueExpected = 45;
            int ResponseValue = 0;
            string json = "{'packageWeights':[15,1,5,9,3,2,10]}";
            ResponseValue = ServiceExecution(json);
            Assert.AreEqual(ValueExpected, ResponseValue);
        }
        [TestMethod]
        public void Test8()
        {
            int ValueExpected = 30;
            int ResponseValue = 0;
            string json = "{'packageWeights':[30,1,2,5]}";
            ResponseValue = ServiceExecution(json);
            Assert.AreEqual(ValueExpected, ResponseValue);
        }
        [TestMethod]
        public void Test9()
        {
            int ValueExpected = 100;
            int ResponseValue = 0;
            string json = "{'packageWeights':[100,5,2,3,1,4,10]}";
            ResponseValue = ServiceExecution(json);
            Assert.AreEqual(ValueExpected, ResponseValue);
        }
        [TestMethod]
        public void Test10()
        {
            int ValueExpected = 30;
            int ResponseValue = 0;
            string json = "{'packageWeights':[30,30,30,10,4,16]}";
            ResponseValue = ServiceExecution(json);
            Assert.AreEqual(ValueExpected, ResponseValue);
        }
        [TestMethod]
        public void Test11()
        {
            int ValueExpected = 183;
            int ResponseValue = 0;
            string json = "{'packageWeights':[90,10,15,15,20,33]}";
            ResponseValue = ServiceExecution(json);
            Assert.AreEqual(ValueExpected, ResponseValue);
        }
        [TestMethod]
        public void Test12()
        {
            int ValueExpected = 64;
            int ResponseValue = 0;
            string json = "{'packageWeights':[10,5,2,9,3,4,11,20,5,3,2]}";
            ResponseValue = ServiceExecution(json);
            Assert.AreEqual(ValueExpected, ResponseValue);
        }
        public int ServiceExecution( string json)
        {
            PackageWeightsModel packageweights = new PackageWeightsModel();

            string url = this.url + "TestAmazon/prueba";
            var request = (HttpWebRequest)WebRequest.Create(url);
            

            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";
            request.Accept = "application/json";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null)
                        {
                            return 0;
                        }
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            object responseBody = objReader.ReadToEnd();
                            packageweights = JsonConvert.DeserializeObject<PackageWeightsModel>(responseBody.ToString());


                        }
                    }
                }
            }
            catch (WebException ex)
            {
                packageweights.MaxPackageWeights = 0;
            }
            return packageweights.MaxPackageWeights;
        }
    }

    
}
