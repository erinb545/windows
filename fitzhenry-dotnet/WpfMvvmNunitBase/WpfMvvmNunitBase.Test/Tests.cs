using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WpfMvvmNunitBase.Models;

namespace WpfMvvmNunitBase.Test
{
    public class Tests
    {
        [TestCase]
        public void Test1()
        {
            var model = new ExampleModel();
            Assert.IsTrue(model.CurValue == 0);

            model.Add(1);
            Assert.IsTrue(model.CurValue == 1);
        }
    }
}
