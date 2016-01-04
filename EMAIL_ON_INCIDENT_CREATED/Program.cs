using System;

namespace EMAIL_ON_INCIDENT_CREATED
{
    class Program
    {
        static void Main(string[] args)
        {
            string queueUrl = "https://sqs.ap-southeast-2.amazonaws.com/835265634988/EMAIL_ON_INCIDENT_CREATED";
            using (var client = new Amazon.SQS.AmazonSQSClient(Amazon.RegionEndpoint.APSoutheast2))
            {
                while (true)
                {
                    // Get the messages
                    var response = client.ReceiveMessage(queueUrl);

                    // Check our response
                    if (response.Messages.Count > 0)
                    {
                        for (int i = 0; i < response.Messages.Count; i++)
                        {
                            // Send an email
                            Console.WriteLine("Sending email");

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
