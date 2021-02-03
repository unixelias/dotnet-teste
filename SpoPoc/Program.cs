using Microsoft.Identity.Client;
using PnP.Framework;
using System;
using System.Security;
using System.Threading.Tasks;

namespace SpoPoc
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            string siteUrl = "https://vlisa.sharepoint.com/sites/Portal-Equipagem";

            // The path to the certificate.
            string username = "RU_PortalEquipagem";
            string senha = "WO25LjbBx#For%1ty6j(";
            SecureString password = new SecureString();
            foreach (char ch in senha)
            {
                password.AppendChar(ch);
            }

            string clientId = "946ea09a-af1c-4c23-bbec-e06beaba07b0";
            string clientSecret = "RjtJ1Iow/B/aOHndNM2O6JudPwMbPwCghNj4qZ2DYvM=";
            string certificatePath = "C:/projetos/certs/equipagem.pfx";
            string certificatePassword = "PmQz1029384756@2020";
            string realm = "eef8f41a-1fa3-486c-9dc3-2fa5f63c9231";
            string redirectUrl = "https://localhost:44369/api";
            string token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6Im5PbzNaRHJPRFhFSzFqS1doWHNsSFJfS1hFZyIsImtpZCI6Im5PbzNaRHJPRFhFSzFqS1doWHNsSFJfS1hFZyJ9.eyJhdWQiOiIwMDAwMDAwMy0wMDAwLTBmZjEtY2UwMC0wMDAwMDAwMDAwMDAvdmxpc2Euc2hhcmVwb2ludC5jb21AZWVmOGY0MWEtMWZhMy00ODZjLTlkYzMtMmZhNWY2M2M5MjMxIiwiaXNzIjoiMDAwMDAwMDEtMDAwMC0wMDAwLWMwMDAtMDAwMDAwMDAwMDAwQGVlZjhmNDFhLTFmYTMtNDg2Yy05ZGMzLTJmYTVmNjNjOTIzMSIsImlhdCI6MTYxMTkyODcxOSwibmJmIjoxNjExOTI4NzE5LCJleHAiOjE2MTIwMTU0MTksImlkZW50aXR5cHJvdmlkZXIiOiIwMDAwMDAwMS0wMDAwLTAwMDAtYzAwMC0wMDAwMDAwMDAwMDBAZWVmOGY0MWEtMWZhMy00ODZjLTlkYzMtMmZhNWY2M2M5MjMxIiwibmFtZWlkIjoiOTQ2ZWEwOWEtYWYxYy00YzIzLWJiZWMtZTA2YmVhYmEwN2IwQGVlZjhmNDFhLTFmYTMtNDg2Yy05ZGMzLTJmYTVmNjNjOTIzMSIsIm9pZCI6IjY0OTk2YzQ5LTkyMTctNDUwNy04NzU2LTk3MDczNTdhOTZiNyIsInN1YiI6IjY0OTk2YzQ5LTkyMTctNDUwNy04NzU2LTk3MDczNTdhOTZiNyIsInRydXN0ZWRmb3JkZWxlZ2F0aW9uIjoiZmFsc2UifQ.e9Wjn1xMg1F9w2m9qITYz-mqwJIwk8Y-SmWpV60DK6oESCKIz33jQkyczr34WqtqX-gi-NwYJromQvWqBnCdQ5UhgTzN6ETmcTBhNUm_DszlyBhzQsTxb01WRxXvZMf3qNmZmOf6dUHxMDxL9e58ug36UunZrPuHfURtWGmK2s8TfgvuZ_vr06wwjIoVS_d6cR7FLG3lPWGin5-2YwOrwdQ8GM1h8g3VQLKNXm_a7wS0kh4rWWRI-5extbsNj6yNPz_PMWXBJCDXbto0w8S3u6JZQngEy_Wo-S4iMeXHLhgL3M0CmXfZx3AurpeGh9q4ieLGtRZ2VcuihGLRaWFQ6Q";
            //AuthenticationManager authManagert = new AuthenticationManager(clientId, certificatePath, certificatePassword, realm, redirectUrl);
            AuthenticationManager authManagert = new AuthenticationManager(clientId, username, password, redirectUrl);
            //UserAssertion userAssertion = new UserAssertion(token);
            //AuthenticationManager authManagert = new AuthenticationManager(clientId, clientId, userAssertion, realm);
            //AuthenticationManager authManagert = new AuthenticationManager();

            //var accessToken = await authManagert.GetAccessTokenAsync(siteUrl);
            //using (var cc = authManagert.GetAccessTokenContext(siteUrl, token))
            using (var cc = authManagert.GetACSAppOnlyContext(siteUrl, realm, clientId, clientSecret))
            {
                cc.Load(cc.Web, p => p.Title);
                cc.ExecuteQuery();
                Console.WriteLine(cc.Web.Title);
            };
        }
    }
}