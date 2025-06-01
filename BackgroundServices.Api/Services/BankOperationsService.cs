using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackgroundServices.Api.Services
{
    public class BankOperationsService : IBankOperationsService
    {
        public BankOperationsService()
        {

        }
        public async Task ExecuteAutomaticSettlementAsync()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("[INFO] Starting automatic settlement process...");
            await Task.Delay(100);

            Console.WriteLine("[INFO] Connecting to financial database...");
            await Task.Delay(100);

            Console.WriteLine("[INFO] Fetching pending invoices...");
            await Task.Delay(100);

            int totalInvoices = 10;
            Console.WriteLine($"[INFO] {totalInvoices} invoices found for settlement.\n");

            for (int i = 0; i < totalInvoices; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[SETTLEMENT] Processing settlement for invoice #{i}...");
                await Task.Delay(1000); // Simulates processing time

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[SETTLEMENT] Invoice #{i} settled successfully.\n");
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("[INFO] All settlements completed successfully.");
            Console.WriteLine($"[INFO] Process finished at {DateTime.Now:T}");

            Console.ResetColor();

        }

        public async Task GenerateBankSlipAsync()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"[INFO] Starting boleto generation process for slip #{i}...");
                await Task.Delay(100);

                Console.WriteLine("[INFO] Validating customer data...");
                await Task.Delay(100);

                Console.WriteLine("[INFO] Preparing billing information...");
                await Task.Delay(100);

                Console.WriteLine("[INFO] Communicating with bank API...");
                await Task.Delay(150);

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("[BOLETO] Bank slip generated successfully.");
                Console.WriteLine($"[BOLETO] Barcode: 34191.79001 01043.510047 91020.150008 {i} 8937000000{i:0000}00");
                Console.WriteLine($"[BOLETO] Due Date: {DateTime.Now.AddDays(5).ToShortDateString()}");
                Console.WriteLine($"[BOLETO] Amount: R$ {200 + i * 10},00");

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("[INFO] Generation completed.");
                Console.WriteLine($"[INFO] Process finished at {DateTime.Now:T}\n");

                Console.ResetColor();

                await Task.Delay(200); // Simulate time between generations
            }
        }
    }
}