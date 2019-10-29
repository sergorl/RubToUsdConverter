using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Util;
using System.Numerics;
using System.Xml.Linq;
using Serilog;
using CourseRate;
using Solidity.Contracts.Oracle.ContractDefinition;
using Solidity.Contracts.Oracle;
using Solidity.Contracts.Calculator.ContractDefinition;
using Solidity.Contracts.Calculator;
using System;
using System.Threading;

namespace Contract {

    public class ContractTask {

        static int count = 0;
        public readonly int id;

        Calculator calculator;

        public struct Summa {            
            private static Random rnd = new Random();
            
            public uint rubs {get; set;}
            public uint kops {get; set;}

            public static Summa Create(int MaxRubs = 1000, int MaxKops = 10000) {
                Summa req = new Summa();
                req.rubs = (uint)rnd.Next(0, MaxRubs + 1);
                req.kops = (uint)rnd.Next(0, MaxKops + 1);

                return req;
            }

            public override string ToString() {
                return $"Request summa is {rubs},{kops} rub";
            }
        }

        public ContractTask(Oracle oracle) {

            calculator = new Calculator(oracle.web3);

            var summa = Summa.Create();

            calculator.RequestToConvetSumma(summa.rubs, summa.kops);
            calculator.AskRateFrom(oracle);

            id = count++;
        }

        public void ExecuteWith(Oracle oracle) {
            oracle.RequestToExecute(calculator);

            var res = calculator.Result();
            var rate = calculator.Rate();

            string info = $"Contract address {calculator.Address()} from thread # {Thread.CurrentThread.ManagedThreadId}: {res} with rate {rate}";

            Log.Information(info);
            Console.WriteLine(info);
        }
    }

    public class Calculator {

        static CalculatorDeployment deploymentCalculator = new CalculatorDeployment();
        TransactionReceipt receipt;
        CalculatorService service;

        public Calculator(Web3 web3) {
            receipt = CalculatorService.DeployContractAndWaitForReceiptAsync(web3, deploymentCalculator).Result;
            service = new CalculatorService(web3, receipt.ContractAddress);
        }

        public string Address() {
            return service.ContractHandler.ContractAddress;
        }

        public void RequestToConvetSumma(uint rubs, uint kops, uint k = 10000 /*for cent precision*/) {
            var r = service.ReqToConvertSummaRequestAndWaitForReceiptAsync(rubs, kops, k ).Result;
        }

        public void AskRateFrom(Oracle oracle) {
            oracle.RequestToSetRate();            
            var r = service.AskRateFromOracleRequestAndWaitForReceiptAsync(oracle.Address()).Result;
        }

        public BigInteger GetId() {
            var id =  service.GetIdQueryAsync().Result;
            return id;
        }

        public string Result() {
            var rubs = service.GetRubsQueryAsync().Result;
            var kops = service.GetKopsQueryAsync().Result;
            var usd = service.GetConvertedUsdQueryAsync().Result;
            var cent = service.GetConvertedRestOfCentsQueryAsync().Result;

            return $"{rubs},{kops} rub => {usd},{cent} usd";
        }

        public string Rate() {
            var rubs = service.GetRubsPerOneUsdQueryAsync().Result;
            var kops = service.GetRestKopsPerOneUsdQueryAsync().Result;

            return $"1 usd = {rubs},{kops} rub";
        }
    }


    public class Oracle {
        static readonly OracleDeployment deploymentOracle = new OracleDeployment();
        TransactionReceipt receipt;
        OracleService service;
        public Web3 web3 {get; set;}

        public Oracle(Web3 _web3) {
            web3 = _web3;
            receipt = OracleService.DeployContractAndWaitForReceiptAsync(web3, deploymentOracle).Result;
            service = new OracleService(web3, receipt.ContractAddress);
        }

        public string Address() {
            return service.ContractHandler.ContractAddress;
        }

        public void ReqToExecuteConvert(string idClaculator) {
            service.ReqToExecuteConvertRequestAndWaitForReceiptAsync(uint.Parse(idClaculator));
        }

        public void RequestToExecute(Calculator calculator) {
            var calcId = calculator.GetId();
            // Console.WriteLine($"calcId = {calcId}");
            var r = service.ReqToExecuteConvertRequestAndWaitForReceiptAsync(calcId).Result;
        }

        public void RequestToSetRate() {
                       
            var crb = new Crb(Date.Now());
            XDocument xml = crb.Xml();

            Usd rate = CrbCourseXmlParser.UsdRate(xml);   

            service.ReqToSetRateRequestAsync(rate.integerPart, rate.fractPart);
            var r = service.ReqToSetRateRequestAndWaitForReceiptAsync(rate.integerPart, rate.fractPart).Result;

            // var r = service.ReqToSetRateRequestAndWaitForReceiptAsync(63, 6336).Result;

            // var rubs = service.GetRubsPerOneUsdQueryAsync().Result;
            // var kops = service.GetRestKopsPerOneUsdQueryAsync().Result;
            // Console.WriteLine($"1 usd = {rubs},{kops} rub");
        }
    } 
}