using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingStuff
{
    public delegate string MessageResponsePayloadPolicy(MessagePayload payload);

    public interface IDelegatePractice
    {
        void SetPolicy(MessageResponsePayloadPolicy payloadPolicy);
        MessageResponse ReponsePayload(int[] values);
    }

    public class DelegatePractice
    {
        MessageResponsePayloadPolicy policy;

        public DelegatePractice()
        {
            policy = MessagePayloadReponsePolicies.DefaultMessageResponsePayloadPolicy;
        }

        public void SetPolicy(MessageResponsePayloadPolicy payloadPolicy)
        {
            policy = payloadPolicy;
        }

        public MessageResponse ReponsePayload(int[] values)
        {
            var payload = new MessagePayload() { Values = values };

            var response = new MessageResponse
            {
                Payload = policy(payload)
            };

            return response;
        }

    }

    public static class MessagePayloadReponsePolicies
    {
        public static string DefaultMessageResponsePayloadPolicy(MessagePayload payload)
        {
            return "-";
        }

        public static string StringMessageResponsePayloadPolicy(MessagePayload payload)
        {
            return "{"+ string.Join(":", payload.Values) +"}";
        }

        public static string JsonMessageResponsePayloadPolicy(MessagePayload payload)
        {
            return JsonConvert.SerializeObject(payload.Values);
        }
    }

    public class MessagePayload
    {
        public int[] Values { get; set; }

    }

    public class MessageResponse
    {
        public string Payload { get; set; }
    }

}
