using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Contracts;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string Header = "Artist|Title|Usages|StartDate|EndDate";
            const string L1 = "Monkey Claw|Black Mountain|digital download|1st Feb 2012|";
            const string L2 = "Monkey Claw|Motor Mouth|digital download|1st Mar 2011|";
            const string L3 = "Tinie Tempah|Frisky (Live from SoHo)|digital download|1st Feb 2012|";
            const string L4 = "Tinie Tempah|Miami 2 Ibiza|digital download|1st Feb 2012|";
                        
            var query = new ContractQuery("ITunes", "1st", "March", "2012");

            Assert.IsTrue(query.ResultList.Count == 5);
                       
            Assert.AreEqual(query.ResultList[0], Header);
            Assert.AreEqual(query.ResultList[1], L1);
            Assert.AreEqual(query.ResultList[2], L2);
            Assert.AreEqual(query.ResultList[3], L3);
            Assert.AreEqual(query.ResultList[4], L4);


        }

        [TestMethod]
        public void TestMethod2()
        {
            const string Header = "Artist|Title|Usages|StartDate|EndDate";
            const string L1 = "Monkey Claw|Motor Mouth|streaming|1st Mar 2011|";
            const string L2 = "Tinie Tempah|Frisky (Live from SoHo)|streaming|1st Feb 2012|";
            
            var query = new ContractQuery("YouTube", "1st", "April", "2012");

            Assert.IsTrue(query.ResultList.Count == 3);

            Assert.AreEqual(query.ResultList[0], Header);
            Assert.AreEqual(query.ResultList[1], L1);
            Assert.AreEqual(query.ResultList[2], L2);
 


        }


        [TestMethod]
        public void TestMethod3()
        {
            const string Header = "Artist|Title|Usages|StartDate|EndDate";
            const string L1 = "Monkey Claw|Christmas Special|streaming|25st Dec 2012|31st Dec 2012";
            const string L2 = "Monkey Claw|Iron Horse|streaming|1st June 2012|";
            const string L3 = "Monkey Claw|Motor Mouth|streaming|1st Mar 2011|";
            const string L4 = "Tinie Tempah|Frisky (Live from SoHo)|streaming|1st Feb 2012|";

            var query = new ContractQuery("YouTube", "27th", "Dec ", "2012");

            Assert.IsTrue(query.ResultList.Count == 5);

            Assert.AreEqual(query.ResultList[0], Header);
            Assert.AreEqual(query.ResultList[1], L1);
            Assert.AreEqual(query.ResultList[2], L2);
            Assert.AreEqual(query.ResultList[3], L3);
            Assert.AreEqual(query.ResultList[4], L4);


        }


    }
}
