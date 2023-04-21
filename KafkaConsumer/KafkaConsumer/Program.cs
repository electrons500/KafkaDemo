using Confluent.Kafka;

var config = new ConsumerConfig
{
    BootstrapServers = "localhost:9092",
    GroupId= "gid-consumers",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

var kafkaTopic = "StudentTopic";

using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
{
    consumer.Subscribe(kafkaTopic);
    while (true)
    {
        var students = consumer.Consume();
        Console.WriteLine(students.Message.Value);
    }
}




