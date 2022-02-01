using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lotto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto.Tests
{
    [TestClass()]
    public class ChybilTrafilTests
    {
        [TestMethod()]
        public void RozmiarKuponuTest()
        {
            int n = 5;
            var res = ChybilTrafil.GenerujKupon(n);
            Assert.IsTrue(res.Length == n);
        }

        [TestMethod()]
        public void RozmiarZakladuTest()
        {
            int n = 10;
            var res = ChybilTrafil.GenerujKupon(n);

            for(int i = 0; i < n; i++)
            {
                Assert.IsTrue(res[i].Count == ChybilTrafil.ileLiczb);
            }
        }

        [TestMethod()]
        public void ZakresLiczbTest()
        {
            int n = 10;
            var res = ChybilTrafil.GenerujKupon(n);

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < 6; j ++)
                {
                    Assert.IsTrue(res[i][j] >= ChybilTrafil.zakresLosowaniaMin && res[i][j] <= ChybilTrafil.zakresLosowaniaMax);
                }
            }
        }
    }
}