using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Services.Protocols;
using SlackApi.Domain;
using Slack.Webhooks;

namespace SlackApi.Controllers {

    [RoutePrefix(@"")]

    public class SlackController : ApiController {
        
        public SlackController() {

        }
        
        //nao precisa consumir o objeto inteiro só até o Consumer, pq depois vem o Binder e ignora o resto que não é usado
       // [Route(@"Get")]
        [HttpGet]
        public IHttpActionResult Get() {
            
            
            string diagnosticAPI = ConfigurationManager.AppSettings["DiagnosticAPI"];
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(diagnosticAPI);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Response response = null;
            HttpResponseMessage responseMessage = client.GetAsync("/queue/info").Result;
            if (responseMessage.IsSuccessStatusCode) {
                response = responseMessage.Content.ReadAsAsync<Response>().Result;
            }

            foreach (var layer in response.Layers)
            {
                foreach (var queueu in layer.Queues)
                {
                    if (queueu.Data.Consumers == 0)
                    {
                        var message = "error";

                        var slackClient = new SlackClient("https://hooks.slack.com/services/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");

                        var slackMessage = new SlackMessage {
                            Channel = "#teste",
                            Text = message,
                            IconEmoji = Emoji.Ambulance,
                            Username = "nerdfury"
                        };

                        var slackAttachment = new SlackAttachment {

                            Fallback = "ReferenceError - UI is not defined: https://honeybadger.io/path/to/event/",
                            Text = "<https://honeybadger.io/path/to/event/|ReferenceError> - UI is not defined",

                            Fields =
                                new List<SlackField>
                                {
                        new SlackField
                        {
                            Title = "Project",
                            Value =  "Awesome Project",
                            Short = true
                        },

                        new SlackField
                        {
                            Title = "Environment",
                            Value = "production",
                            Short = true
                        },

                                },

                            Color = "#F35A00"
                        };

                        slackMessage.Attachments = new List<SlackAttachment> { slackAttachment };

                        slackClient.Post(slackMessage);

                    }

                }
               
            }
            

            return Ok(response);
        }

    }
}
