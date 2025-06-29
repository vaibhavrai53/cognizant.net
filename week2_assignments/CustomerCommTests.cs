using NUnit.Framework;
using Moq;
using CustomerCommLib;

namespace CustomerCommLib.Tests
{
    public class CustomerCommTests
    {
        [Test]
        public void SendMailToCustomer_ShouldCallSendMailOnce_AndReturnTrue()
        {
            // Arrange
            var mockMailSender = new Mock<IMailSender>();
            mockMailSender
                .Setup(x => x.SendMail(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            var customerComm = new CustomerComm(mockMailSender.Object);

            // Act
            var result = customerComm.SendMailToCustomer();

            // Assert
            Assert.IsTrue(result);
            mockMailSender.Verify(
                x => x.SendMail("cust123@abc.com", "Some Message"),
                Times.Once);
        }
    }
}