using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Constants
{
    public class NexudusConstants
    {
        public const string CLIENT_ID
            = "6962E962-A46C-47B3-93F3-53EE48B39611";

        public const string AUTHENTICATION_URL 
            = "https://spaces.nexudus.com/api/token";

        public const string BILLING_PLANS_URL
            = "https://spaces.nexudus.com/api/billing/tariffs";

        public const string SPACES_RESOURCES_URL
            = "https://spaces.nexudus.com/api/spaces/resources";

        public const string BILLING_TIMEPASSES_URL
            = "https://spaces.nexudus.com/api/billing/timepasses";

        public const string BILLING_PRODUCTS_URL
            = "https://spaces.nexudus.com/api/billing/products";

        public const string BILLING_FINANCIALACCOUNTS_URL
            = "https://spaces.nexudus.com/api/billing/financialaccounts";

        public const string SYSTEM_BUSINESSES_URL
            = "https://spaces.nexudus.com/api/sys/businesses";

        public const string SPACES_RESOURCE_TYPES_URL
            = "https://spaces.nexudus.com/api/spaces/resourcetypes";

        public static IDictionary<Type, string> NexudusUrls { get; }
            = new Dictionary<Type, string>
            {
                { typeof(Plan), BILLING_PLANS_URL }
                ,{ typeof(Resource), SPACES_RESOURCES_URL }
                ,{ typeof(Pass), BILLING_TIMEPASSES_URL }
                ,{ typeof(Product), BILLING_PRODUCTS_URL }
                ,{ typeof(FinancialAccount), BILLING_FINANCIALACCOUNTS_URL }
                , { typeof(Business), SYSTEM_BUSINESSES_URL }
                , { typeof(ResourceType), SPACES_RESOURCE_TYPES_URL }
            };
    }
}
