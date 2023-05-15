using System;
using System.Threading.Tasks;
using Xunit;

using Prova.Domain.Core;


namespace Prova.Tests
{
    public static class AssertExtensions
    {
        public static void ThrowsWithMessage(Action testecode, string messageexpected)
        {
            string message = "";
            Notify _notify = Assert.Throws<BusinessException>(testecode).Notifications;

            foreach (var item in _notify.NotificationList)
            {
                if (messageexpected == item.Message)
                {
                    message = item.Message;
                    break;
                }
            }

            Assert.Equal(messageexpected, message);
        }

        public static void ThrowsWithMessageAsync(Func<Task> testcode, string messageexpected)
        {
            var result = Assert.ThrowsAsync<BusinessException>(testcode).Result;
            Assert.Equal(messageexpected, result.Message);
        }
    }
}
