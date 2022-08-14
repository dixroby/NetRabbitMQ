using RabbitMQ.Client;
using System.Text;

const string queue = "firtsQueue";

ConnectionFactory factory = new ConnectionFactory
{
    HostName = "localhost",
    UserName = "YOUR_USERNAME",
    Password = "YOUR_PASSWORD",
};

using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue, false, false, false, null);
    var message = "new queue 2022";
    var body = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish("", queue, null, body);
    Console.WriteLine("this is message send {0}", message);
}

Console.WriteLine("Press enter exit aplication");
Console.ReadLine();