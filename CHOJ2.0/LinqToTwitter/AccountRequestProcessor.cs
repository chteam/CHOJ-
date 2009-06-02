﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LinqToTwitter
{
    /// <summary>
    /// handles query processing for accounts
    /// </summary>
    public class AccountRequestProcessor : IRequestProcessor
    {
        /// <summary>
        /// base url for request
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// extracts parameters from lambda
        /// </summary>
        /// <param name="lambdaExpression">lambda expression with where clause</param>
        /// <returns>dictionary of parameter name/value pairs</returns>
        public Dictionary<string, string> GetParameters(System.Linq.Expressions.LambdaExpression lambdaExpression)
        {
            return
               new ParameterFinder<Account>(
                   lambdaExpression.Body,
                   new List<string> { 
                       "Type"
                   })
                   .Parameters;
        }

        /// <summary>
        /// builds url based on input parameters
        /// </summary>
        /// <param name="parameters">criteria for url segments and parameters</param>
        /// <returns>URL conforming to Twitter API</returns>
        public string BuildURL(Dictionary<string, string> parameters)
        {
            string url = null;

            if (parameters == null || !parameters.ContainsKey("Type"))
            {
                url = BaseUrl + "account/verify_credentials.xml";
                return url;
            }

            switch ((AccountType)Enum.ToObject(typeof(AccountType), int.Parse(parameters["Type"])))
            {
                case AccountType.VerifyCredentials:
                    url = BaseUrl + "account/verify_credentials.xml";
                    break;
                case AccountType.RateLimitStatus:
                    url = BaseUrl + "account/rate_limit_status.xml";
                    break;
                default:
                    url = BaseUrl + "account/verify_credentials.xml";
                    break;
            }

            return url;
        }

        /// <summary>
        /// transforms XML into IQueryable of User
        /// </summary>
        /// <param name="twitterResponse">xml with Twitter response</param>
        /// <returns>IQueryable of User</returns>
        public IList ProcessResults(System.Xml.Linq.XElement twitterResponse)
        {
            var acct = new Account();

            if (twitterResponse.Name == "user")
            {
                var user = new User().CreateUser(twitterResponse);

                acct.User = user;
            }
            else if (twitterResponse.Name == "hash")
            {
                if (twitterResponse.Element("hourly-limit") != null)
                {
                    var rateLimits = new RateLimitStatus
                    {
                        HourlyLimit = int.Parse(twitterResponse.Element("hourly-limit").Value),
                        RemainingHits = int.Parse(twitterResponse.Element("remaining-hits").Value),
                        ResetTime = DateTime.Parse(twitterResponse.Element("reset-time").Value),
                        ResetTimeInSeconds = int.Parse(twitterResponse.Element("reset-time-in-seconds").Value)
                    };

                    acct.RateLimitStatus = rateLimits; 
                }
                else
                {
                    var endSession = new TwitterHashResponse
                    {
                        Request = twitterResponse.Element("request").Value,
                        Error = twitterResponse.Element("error").Value
                    };

                    acct.EndSessionStatus = endSession;
                }
            }
            else
            {
                throw new ArgumentException("Account Results Processing expected a Twitter response for either a user or hash, but received an unknown element type instead.");
            }

            var acctList = new List<Account> { acct };
            return acctList;
            //return acctList.AsQueryable<Account>();
        }
    }
}
