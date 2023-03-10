using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Newtonsoft.Json;
var factory = new ConnectionFactory()
{
    HostName = "167.172.186.10",
    UserName = "tatyana",
    Password = "learningRabbitMQ"
};

using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())

{
    var consumer = new EventingBasicConsumer(channel);

    consumer.Received += (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        channel.QueueDeclare(queue: "rails2",
                      durable: false,
                      exclusive: false,
                      autoDelete: false,
                      arguments: null);
        channel.BasicPublish(exchange: "",
                            routingKey: "rails2",
                            basicProperties: null,
                            body: body);
        Console.WriteLine(message);

    };

    channel.BasicConsume(queue: "rails1",
                            autoAck: true,
                            consumer: consumer);

    Console.WriteLine(" Press [enter] to exit.");
    Console.ReadLine();
}

