
    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;
    using System;
    using System.Text;

    namespace CorePublisher

{
    class Program
        {
            static void Main(string[] args)
            {
              Console.WriteLine("Please input name.");
              string sName = Console.ReadLine();

                var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "Oloza2013" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "Name",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var body = Encoding.UTF8.GetBytes(sName);
                channel.BasicPublish(exchange: "", routingKey: "Name",mandatory:false, basicProperties: null, body: body);
                    
                        Console.WriteLine("Hello my name is {0}.", sName);
                    

                    Console.WriteLine("press any key to exit.");
                    Console.ReadKey();

                }
            }
        }
    }




