using System.Collections.Generic;
using System.Numerics;
using modul8_103022300011;
using static modul8_103022300011.BankTransferConfigInt;

class Program {
    public static void Main(String[] args) {
        UIBankTransferConfig config = new UIBankTransferConfig();
        config.ReadConfigFile();
        if (config.bankTransferConfig.lang == "en")
        {
            Console.WriteLine("Please insert the amount of money to transfer: ");
        }
        else if (config.bankTransferConfig.lang == "id") {
            Console.WriteLine("Masukkan jumlah uang yang akan di-transfer: ");
        }
        int inputTf = int.Parse(Console.ReadLine());
        int total = 0;

        if (inputTf <= config.bankTransferConfig.transfer.threshold)
        {
            total = inputTf + config.bankTransferConfig.transfer.low_fee;
            if (config.bankTransferConfig.lang == "en")
            {
                Console.WriteLine($"Transfer fee = {config.bankTransferConfig.transfer.low_fee}");
                Console.WriteLine($"Total amount = {total}");
            }
            else if (config.bankTransferConfig.lang == "id")
            {
                Console.WriteLine($"Biaya transfer =  {config.bankTransferConfig.transfer.low_fee}");
                Console.WriteLine($"Total biaya = {total}");
            }
        }
        else if (inputTf > config.bankTransferConfig.transfer.threshold)
        {
            total = inputTf + config.bankTransferConfig.transfer.high_fee;
            if (config.bankTransferConfig.lang == "en")
            {
                Console.WriteLine($"Transfer fee = {config.bankTransferConfig.transfer.high_fee}");
                Console.WriteLine($"Total amount = {total}");
                Console.WriteLine("Select transfer method: ");
            }
            else if (config.bankTransferConfig.lang == "id")
            {
                Console.WriteLine($"Biaya transfer =  {config.bankTransferConfig.transfer.high_fee}");
                Console.WriteLine($"Total biaya = {total}");
                Console.WriteLine("Pilih metode transfer: ");
            }
        }
        foreach (var item in config.bankTransferConfig.methods)
        {
            int i = 1;
            Console.WriteLine($"{i}. {config.bankTransferConfig.methods}");
            i++;
        }

        if (config.bankTransferConfig.lang == "en")
        {
            Console.WriteLine($"");
        }
        else if (config.bankTransferConfig.lang == "id")
        {
            Console.WriteLine($"");
        }
    }
}
