using System;
using System.Collections.Generic;
using System.Threading;
using System.Collections.Concurrent;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

using Serilog;

using Nethereum.Web3;
using Nethereum.Web3.Accounts;

using Util;
using Contract;

namespace aspnetcoreapp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ContractLog.Init();

            IList<Thread> threads = new List<Thread>(); 
            ConcurrentQueue<ContractTask> tasks = new ConcurrentQueue<ContractTask>();

            var web3 = InitWeb3();

            if (web3 != null) {

                var oracle = new Oracle(web3);

                threads.Add(new Thread(() => CreateHostBuilder(args).Build().Run()));

                for(int i = 0; i < 3; ++i)
                {           
                    threads.Add(new Thread(() => DemoOfContractExecute(oracle, tasks)));
                }  
            
                foreach (var thread in threads)
                {
                    thread.Start();
                }

                // generate contracts
                for(int i = 0; i < 9; ++i ) {           
                    tasks.Enqueue(new ContractTask(oracle));
                }                  
            }

            ContractLog.Close();
        }        

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static Web3 InitWeb3() {

            Web3 web3 = null;

            try
            {
                // using local chain eg Geth https://github.com/Nethereum/TestChains#geth
                var url = "http://localhost:8545";
                var privateKey = "0xb5b1870957d373ef0eeffecc6e4812c0fd08f554b37b233526acc331bf1544f7";
                var account = new Account(privateKey);
                web3 = new Web3(account, url);
            }
            catch (Exception ex)
            {
                Log.Information("Problem in web3 initialization!");
                Console.WriteLine(ex.ToString());
            }

            return web3;
        }

        static void DemoOfContractExecute(Oracle oracle, ConcurrentQueue<ContractTask> tasks)
        {
            ContractTask task;

            while(true) {
                 while (tasks.TryDequeue(out task)) {
                     task.ExecuteWith(oracle);
                 }
            }          
        }
    }
}
