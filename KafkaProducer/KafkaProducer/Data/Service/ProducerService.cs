using Confluent.Kafka;
using KafkaProducer.Data.Model;
using System.Text.Json;

namespace KafkaProducer.Data.Service
{
    public class ProducerService
    {
        private ProducerConfig _ProducerConfig;
        private IConfiguration _Configuration;
        public ProducerService(ProducerConfig producerConfig, IConfiguration configuration)
        {
            _ProducerConfig = producerConfig;
            _Configuration = configuration;
        }

        public async Task<bool> PublishStudentAsync(StudentModel model)
        {
            var kafkaTopic = "StudentTopic"; 
            //serialize model to json
            string jsonData = JsonSerializer.Serialize(model);
            using var producer = new ProducerBuilder<Null, string>(_ProducerConfig).Build();
           var response = await producer.ProduceAsync(kafkaTopic, new Message<Null, string> { Value = jsonData });
            producer.Flush(TimeSpan.FromSeconds(10));
            if(response.Status == PersistenceStatus.Persisted)
            {
                return true;
            }

            return false;
        }




    }
}
