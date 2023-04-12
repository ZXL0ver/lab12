using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PaymentServiceUnitTest
{
    [TestClass]
    public class PaymentServiceTest
    {
        [TestMethod]
        public void TestBankTransferService()
        {
            PaymentService bankTransferService = new BankTransferService();
            PaymentService creditCardService = new CreditCardService();
            PaymentService payPalService = new PayPalService();

            bankTransferService.SetNext(creditCardService).SetNext(payPalService);

            Assert.IsFalse(bankTransferService.Handle(2500));
            Assert.IsTrue(bankTransferService.Handle(1000));
            Assert.IsTrue(bankTransferService.Handle(500));
        }

        [TestMethod]
        public void TestCreditCardService()
        {
            PaymentService creditCardService = new CreditCardService();
            PaymentService payPalService = new PayPalService();

            creditCardService.SetNext(payPalService);

            Assert.IsFalse(creditCardService.Handle(2500));
            Assert.IsTrue(creditCardService.Handle(0));
            Assert.IsTrue(creditCardService.Handle(500));
        }

        [TestMethod]
        public void TestPayPalService()
        {
            PaymentService payPalService = new PayPalService();

            Assert.IsFalse(payPalService.Handle(2500));
            Assert.IsTrue(payPalService.Handle(2000));
            Assert.IsTrue(payPalService.Handle(500));
        }
    }
}

