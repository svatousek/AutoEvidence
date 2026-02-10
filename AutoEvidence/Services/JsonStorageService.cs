using System.IO;
using System.Text.Json;
using AutoEvidence.Models;

namespace AutoEvidence.Services
{
    public class JsonStorageService : IStorageService
    {
        private const string FileName = "data.json";

        public void SaveData(CarEvidenceData data)
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(FileName, json);
        }

        public CarEvidenceData LoadData()
        {
            if (!File.Exists(FileName))
                return new CarEvidenceData();

            var json = File.ReadAllText(FileName);
            return JsonSerializer.Deserialize<CarEvidenceData>(json)
                   ?? new CarEvidenceData();
        }
    }
}
