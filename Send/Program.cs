using RabbitMQ.Client;
using Newtonsoft.Json;
using System.Text;

var factory = new ConnectionFactory()
{
    HostName = "167.172.186.10",
    UserName = "tatyana",
    Password = "learningRabbitMQ"
};


using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "rails1",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

    Random randSquares = new Random();
    int squareNumbers = randSquares.Next(3, 6);
    Console.WriteLine(squareNumbers);
    for (int i = 0; i < squareNumbers; i++)
    {
        string message = "square";

        var body = Encoding.UTF8.GetBytes(message);
        channel.BasicPublish(exchange: "",
                            routingKey: "rails1",
                            basicProperties: null,
                            body: body);
        Console.WriteLine(message);
    }

}

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();

