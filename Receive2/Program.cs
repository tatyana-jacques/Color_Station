using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using Newtonsoft.Json;
using ThirdStation;

var factory = new ConnectionFactory()
{
    HostName = "167.172.186.10",
    UserName = "tatyana",
    Password = "learningRabbitMQ"
};
using (var ctx = new Receive2Context())
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())

{

    var consumer = new EventingBasicConsumer(channel);

    consumer.Received += (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        var passenger = JsonConvert.DeserializeObject<List<string>>(message);
        foreach (var x in passenger)
        {
            Passenger passengerObj = new Passenger { ShapeData = message };
            ctx.Passengers.Add(passengerObj);
            ctx.SaveChangesAsync();
            Console.WriteLine(message);

        }


    };


    channel.BasicConsume(queue: "rails2",
                            autoAck: true,
                            consumer: consumer);

    Console.WriteLine(" Press [enter] to exit.");
    Console.ReadLine();
}