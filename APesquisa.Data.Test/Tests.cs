using APesquisa.Data.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace APesquisa.Data.Test
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var dbContext = new APesquisaContext())
            {
                var aux = dbContext.MergeTable.Where(x => x.ID < 100).ToList();
             }
        }
    }
}
