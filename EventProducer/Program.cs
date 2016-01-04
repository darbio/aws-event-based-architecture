using System;

namespace EventProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            string INCIDENT_CREATED_ARN = "arn:aws:sns:ap-southeast-2:835265634988:INCIDENT_CREATED";
            string INCIDENT_UPDATED_ARN = "arn:aws:sns:ap-southeast-2:835265634988:INCIDENT_UPDATED";

            using (var client = new Amazon.SimpleNotificationService.AmazonSimpleNotificationServiceClient(Amazon.RegionEndpoint.APSoutheast2))
            {
                Console.WriteLine("Press 1 to create a new incident, or 2 to update an existing incident.");

                while (true)
                {
                    var key = Console.ReadKey();

                    if (key.KeyChar == '1')
                    {
                        Console.Write("\rCreating incident.");
                        client.Publish(INCIDENT_CREATED_ARN, "Incident created.");
                    }
                    else if (key.KeyChar == '2')
                    {
                        Console.Write("\rUpdating incident");
                        client.Publish(INCIDENT_UPDATED_ARN, "Incident updated.");
                    }
                    else
                    {
                        Console.Write("\rUnrecognised action.");
                    }
                }
            }
        }
    }
}
