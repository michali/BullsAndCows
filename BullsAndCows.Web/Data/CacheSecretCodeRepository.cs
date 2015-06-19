using System;
using System.Web;
using BullsAndCows.Data;
using System.Web.Caching;

namespace BullsAndCows.Web.Data
{
    public class CacheSecretCodeRepository : ISecretCodeRepository
    {
        private readonly string Key = "secretCode";

        public string Get()
        {
            return (string)HttpContext.Current.Cache[Key];
        }

        public void Add(string secretCode)
        {
            HttpContext.Current.Cache.Add(Key, secretCode, null, DateTime.MaxValue, Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
        }
    }
}