using System;

namespace CACHE_ON_INCIDENT_ALL
{
    class Program
    {
        static void Main(string[] args)
        {
            string queueUrl = "https://sqs.ap-southeast-2.amazonaws.com/835265634988/CACHE_ON_INCIDENT_ALL";
            using (var client = new Amazon.SQS.AmazonSQSClient(Amazon.RegionEndpoint.APSoutheast2))
            {
                while (true)
                {
                    // Get the messages
                    var request = new Amazon.SQS.Model.ReceiveMessageRequest(queueUrl);
                    var response = client.ReceiveMessage(request);

                    // Check our response
                    if (response.Messages.Count > 0)
                    {
                        for (int i = 0; i < response.Messages.Count; i++)
                        {
                            // Send an email
                            Console.WriteLine("Updating Cache");

                            // Delete our message so that it doesn't get handled again
                            var receiptHandle = response.Messages[i].ReceiptHandle;
                            client.DeleteMessage(queueUrl, receiptHandle);
                        }
                    }
                }
            }
        }
    }
}
