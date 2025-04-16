using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_103022300011
{
    internal class BankTransferConfigInt {
        public class Confirmation
        {
            public Confirmation(string en, string id)
            {
                this.id = id;
                this.en = en;
            }

            public string en { get; set; }
            public string id { get; set; }
        }
        public class Transfer
        {

            public Transfer(int threshold, int low_fee, int high_fee)
            {
                this.threshold = threshold;
                this.low_fee = low_fee;
                this.high_fee = high_fee;
            }
            public int threshold { get; set; }
            public int low_fee { get; set; }
            public int high_fee { get; set; }
        }
        public class BankTransferConfig
        {
            public BankTransferConfig (string lang, Transfer transfer, List<string> methods, Confirmation confirmation) { 
                this.lang = lang;
                this.transfer = transfer;
                this.methods = methods;
                this.confirmation = confirmation;
            }
            public string lang { get; set; }
            public Transfer transfer { get; set; }
            public List<string> methods { get; set; }
            public Confirmation confirmation { get; set; }
        }

        public class UIBankTransferConfig
        {
            public BankTransferConfig bankTransferConfig;
            public String filePath = @"bank_transfer_config.json";
            public UIBankTransferConfig()
            {
                try
                {
                    ReadConfigFile();
                }
                catch (Exception)
                {
                    SetDefault();
                    WriteNewConfigFile();
                }
            }
            public BankTransferConfig ReadConfigFile()
            {
                String configJsonData = File.ReadAllText(filePath);
                bankTransferConfig = JsonSerializer.Deserialize<BankTransferConfig>(configJsonData);
                return bankTransferConfig;
            }

            private void WriteNewConfigFile()
            {
                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    WriteIndented = true
                };
                String jsonString = JsonSerializer.Serialize(bankTransferConfig, options);
                File.WriteAllText(filePath, jsonString);
            }

            private void SetDefault()
            {

                bankTransferConfig.lang = "en";
                bankTransferConfig.transfer.threshold = 25000000;
                bankTransferConfig.transfer.low_fee = 6500;
                bankTransferConfig.transfer.high_fee = 15000;
                bankTransferConfig.methods = new List<string> { "RTO(real - time)", "SKN", "RTGS", "BI FAST" };
                bankTransferConfig.confirmation.en = "yes";
                bankTransferConfig.confirmation.id = "ya";
            }

        }
    }
    
}
