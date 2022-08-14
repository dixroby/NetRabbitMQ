using RabbitMQ.Client;
using RabbitMQ.Client.Events;
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

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, ea) =>
    {
        var body = ea.Body.Span;
        var message = Encoding.UTF8.GetString(body);
        Console.WriteLine("this is message recived {0}", message);
    };

    channel.BasicConsume(queue, true, consumer);

    Console.WriteLine("Press [enter] exit aplication");
}