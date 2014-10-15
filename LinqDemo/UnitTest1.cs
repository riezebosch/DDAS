using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace LinqDemo
{


    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InitialisatieVanDelegates()
        {
            // Dit
            var m = new MethodeNaam(MijnMethode);

            // is precies hetzelfde als
            MethodeNaam m2 = MijnMethode;
        }

        private static void MijnMethode(int i)
        {
        }

        [TestMethod]
        public void MyTestMethod()
        {
            MethodeNaam m = MijnMethode;

            // Dit
            m.Invoke(12);

            // is precies hetzelfde als:
            m(12);

            // Maar iets gans anders dan:
            MijnMethode(12);
        }

        public MethodeNaam DelegateOfEvent1 { get; set; }
        public event MethodeNaam DelegateOfEvent2;

        [TestMethod]
        public void VerschilTussenEventsEnDelgates()
        {
            this.DelegateOfEvent1 += i => { };
            this.DelegateOfEvent2 += i => { };

            // Dit kan alleen binnen de class die het event heeft gedefinieerd.
            this.DelegateOfEvent2(12);
            this.DelegateOfEvent2 = null;
        }

        [TestMethod]
        public void DeOvereenKomstTussenFuncsOfActionsEnDelegates()
        {
            Action<int> f = MijnMethode;
            int[] items = { 1, 2, 43, 54, 5, 354, 34, 34 };
            
            // Een plek waar je regelmatig Funcs hebt gebruikt:
            var even = items.Where(i => i % 2 == 0);
        }

        [TestMethod]
        public void LambdasEnAnonymousMethods()
        {
            int[] items = { 1, 2, 43, 54, 5, 354, 34, 34 };

            // Via expliciete kleine helper methods.
            var even1 = items.Where(IsEven);
            Func<int, bool> f = IsEven;
            var even2 = items.Where(f);

            // Via anonymous (inline) methods
            var even3 = items.Where(delegate(int i) { return i % 2 == 0; });

            // Via lambda's
            var even4 = items.Where((int i) => { return i % 2 == 0; });
            var even5 = items.Where(i => { return i % 2 == 0; });
            var even6 = items.Where(i => i % 2 == 0);
            
            // En dat is precies hetzelfde als:
            var even7 = from i in items
                        where i % 2 == 0
                        select i;
        }

        public static bool IsEven(int i)
        {
            return i % 2 == 0;
        }

        [TestMethod]
        public void VerschilTussenFuncsEnExpressions()
        {
            Func<int, bool> func = (i) => i % 2 == 0;
            Expression<Func<int, bool>> expr = (i) => i % 2 == 0;

            expr.Compile().Invoke(12);
        }

        [TestMethod]
        public void WatMoetJeDusNietDoenMetExpressions()
        {
            int[] items = { 1, 2, 43, 54, 5, 354, 34, 34 };
        
            // Mix and match van expressies en externe functies
            Expression<Func<string, bool>> expr = s => int.Parse(s) % 2 ==0;


            // Met je eigen methodes
            Expression<Func<string, bool>> expr2 = s => IsEven(int.Parse(s));
        }

        [TestMethod]
        public async Task TestIestAsync()
        {
            int result = await MijnAsyncMethode(2);

            Assert.AreEqual(4, result);
            Assert.AreEqual(8, await MijnAsyncMethode(result));
        }

        private async Task<int> MijnAsyncMethode(int a)
        {
            await Task.Delay(2000);

            return a * 2;
        }
    }
}
