﻿using System;
using NUnit.Framework;

namespace Omise.Tests
{
    [TestFixture]
    public class ClientTest : OmiseTest
    {
        [Test]
        public void TestCtor()
        {
            var pkey = "pkey_test_123";
            var skey = "skey_test_123";

            Assert.Throws<ArgumentNullException>(() => new Client(null, null));
            Assert.DoesNotThrow(() => new Client(pkey, null));
            Assert.DoesNotThrow(() => new Client(null, skey));
            Assert.DoesNotThrow(() => new Client(pkey, skey));

            var creds = DummyCredentials;
            Assert.Throws<ArgumentNullException>(() => new Client(credentials: null));
            Assert.DoesNotThrow(() => new Client(creds));
        }

        [Test]
        public void TestAPIVersion()
        {
            var client = new Client("pkey_test_123", "skey_test_123");
            var version = "2019-05-29";

            Assert.AreEqual(version, client.APIVersion);
            Assert.AreEqual(version, ((Requester)client.Requester).APIVersion);
        }

        [Test]
        public void TestResources()
        {
            var client = new Client(DummyCredentials);
            var resources = new object[]
            {
                client.Account,
                client.Balance,
                client.Charges.Charge("chrg_test_4yq7duw15p9hdrjp8oq"),
                client.Charges,
                client.Customers.Customer("cust_test_4yq6txdpfadhbaqnwp3"),
                client.Customers,
                client.Disputes,
                client.Events,
                client.Occurrences,
                client.Recipients.Recipient("recp_test_57po4c5obpi7rrxhtyl"),
                client.Recipients,
                client.Refunds,
                client.Schedules.Schedule("schd_test_57ze0f4rbugx2jjlg4y"),
                client.Schedules,
                client.Tokens,
                client.Transactions,
                client.Transfers,
            };

            foreach (var resource in resources)
            {
                Assert.IsNotNull(resource);
            }
        }
    }
}

