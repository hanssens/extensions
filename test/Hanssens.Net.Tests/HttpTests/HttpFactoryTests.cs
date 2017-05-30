using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Hanssens.Net.Http;
using Xunit;

namespace Hanssens.Net.Tests.HttpTests
{
    public class HttpFactoryTests
    {
        private const string BaseEndpoint = "http://telemetry-test.api.marlink.io/api/v1.1";

        [Fact(DisplayName = "HttpFactory.Get() should provide success status code")]
        public async Task Test1()
        {
            var factory = new HttpFactory();
            var response = await factory.GetAsync($"{BaseEndpoint}/auth");

            response.IsSuccessStatusCode.Should().BeTrue();
        }

        [Fact(DisplayName = "HttpFactory.Post() should use custom body + header")]
        public async Task Test2()
        {
            var factory = new HttpFactory();
            var deviceId = 1602408;
            var token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6Ik9FSXdOemxCUVRRNE16VkRPVVJET0RjeU16UXpSakpCTlRjeU9EazNPRUpCUlRFek1UTTRSQSJ9.eyJpc3MiOiJodHRwczovL21hcmxpbmsuZXUuYXV0aDAuY29tLyIsInN1YiI6Ik03MWVBNGtXd2dFenl1NjRpaFFNWFpybDZBWmprNGFmQGNsaWVudHMiLCJhdWQiOiJ0ZWxlbWV0cnktc3RvcmUtYXBpLmF6dXJld2Vic2l0ZXMubmV0IiwiZXhwIjoxNDk1NTY1OTA2LCJpYXQiOjE0OTU0Nzk1MDYsInNjb3BlIjoiIn0.D-Fr7gNHse6H_9KbuXFde6JFC0sRtknJPDA-4FAteyidnReoMpOce_mr5lNurdTAAiyLTf3W-qIJNuEQynvGvX8mOIfTWcCnJvT0sOYJ2CS3v742dlE_3oRNtYo26DK4Hvq5BjdqlN5Kh_hl5rma207Hz1Vc5dycgvcezWalYj8ujYpthDgGsm-w37Muqt6YHQ_Am-S0_tqa9DaOAt42nhldPMiiUF7-hcBVjabti4wogpA7FZZAfj1P0OgzMxNWDbBI5Y_Ja15lOSInYSaTSqR94PfpdhJ6TX_L4_WOieMYBlrnwYVE5bN9qaNi85aHto62Jxpcs-Iu3_OzCZ03zQ";
            var body = new
            {
                From = new DateTime(2017, 5, 1),
                Until = new DateTime(2017, 5, 31),
                Measurement = "blindsector",
                Metrics = new string[] { "antenna_size", "average_speed" }
            };
            var headers = new Dictionary<string, string>();
            headers.Add("content-type", "application/json");
            headers.Add("authorization", $"bearer {token}");

            var response = await factory.PostAsync($"{BaseEndpoint}/devices/{deviceId}/history", body, headers);
            
            response.IsSuccessStatusCode.Should().BeTrue(because: response.ReasonPhrase);

        }

        [Fact(DisplayName = "HttpFactory.Get() should provide clear error message if domain does not exist")]
        public async Task Test3()
        {
            var factory = new HttpFactory();
            var response = await factory.GetAsync("http://nonexistingdomain-bla-diblabla.com/api");

            response.IsSuccessStatusCode.Should().BeFalse();
            response.StatusCode.Should().Be(502);
        }
    }
}
