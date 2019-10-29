using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using Solidity.Contracts.Oracle.ContractDefinition;

namespace Solidity.Contracts.Oracle
{
    public partial class OracleService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, OracleDeployment oracleDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<OracleDeployment>().SendRequestAndWaitForReceiptAsync(oracleDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, OracleDeployment oracleDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<OracleDeployment>().SendRequestAsync(oracleDeployment);
        }

        public static async Task<OracleService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, OracleDeployment oracleDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, oracleDeployment, cancellationTokenSource);
            return new OracleService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public OracleService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<BigInteger> GetRubsPerOneUsdQueryAsync(GetRubsPerOneUsdFunction getRubsPerOneUsdFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetRubsPerOneUsdFunction, BigInteger>(getRubsPerOneUsdFunction, blockParameter);
        }

        
        public Task<BigInteger> GetRubsPerOneUsdQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetRubsPerOneUsdFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> GetIdQueryAsync(GetIdFunction getIdFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetIdFunction, BigInteger>(getIdFunction, blockParameter);
        }

        
        public Task<BigInteger> GetIdQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetIdFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> SetCalculatorRequestAsync(SetCalculatorFunction setCalculatorFunction)
        {
             return ContractHandler.SendRequestAsync(setCalculatorFunction);
        }

        public Task<TransactionReceipt> SetCalculatorRequestAndWaitForReceiptAsync(SetCalculatorFunction setCalculatorFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setCalculatorFunction, cancellationToken);
        }

        public Task<string> SetCalculatorRequestAsync(string addressCalculator)
        {
            var setCalculatorFunction = new SetCalculatorFunction();
                setCalculatorFunction.AddressCalculator = addressCalculator;
            
             return ContractHandler.SendRequestAsync(setCalculatorFunction);
        }

        public Task<TransactionReceipt> SetCalculatorRequestAndWaitForReceiptAsync(string addressCalculator, CancellationTokenSource cancellationToken = null)
        {
            var setCalculatorFunction = new SetCalculatorFunction();
                setCalculatorFunction.AddressCalculator = addressCalculator;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setCalculatorFunction, cancellationToken);
        }

        public Task<string> ReqToSetRateRequestAsync(ReqToSetRateFunction reqToSetRateFunction)
        {
             return ContractHandler.SendRequestAsync(reqToSetRateFunction);
        }

        public Task<TransactionReceipt> ReqToSetRateRequestAndWaitForReceiptAsync(ReqToSetRateFunction reqToSetRateFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(reqToSetRateFunction, cancellationToken);
        }

        public Task<string> ReqToSetRateRequestAsync(BigInteger rubsPerOneUsd, BigInteger restKopsPerOneUsd)
        {
            var reqToSetRateFunction = new ReqToSetRateFunction();
                reqToSetRateFunction.RubsPerOneUsd = rubsPerOneUsd;
                reqToSetRateFunction.RestKopsPerOneUsd = restKopsPerOneUsd;
            
             return ContractHandler.SendRequestAsync(reqToSetRateFunction);
        }

        public Task<TransactionReceipt> ReqToSetRateRequestAndWaitForReceiptAsync(BigInteger rubsPerOneUsd, BigInteger restKopsPerOneUsd, CancellationTokenSource cancellationToken = null)
        {
            var reqToSetRateFunction = new ReqToSetRateFunction();
                reqToSetRateFunction.RubsPerOneUsd = rubsPerOneUsd;
                reqToSetRateFunction.RestKopsPerOneUsd = restKopsPerOneUsd;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(reqToSetRateFunction, cancellationToken);
        }

        public Task<BigInteger> GetRestKopsPerOneUsdQueryAsync(GetRestKopsPerOneUsdFunction getRestKopsPerOneUsdFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetRestKopsPerOneUsdFunction, BigInteger>(getRestKopsPerOneUsdFunction, blockParameter);
        }

        
        public Task<BigInteger> GetRestKopsPerOneUsdQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetRestKopsPerOneUsdFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> CalculatorsQueryAsync(CalculatorsFunction calculatorsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CalculatorsFunction, string>(calculatorsFunction, blockParameter);
        }

        
        public Task<string> CalculatorsQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var calculatorsFunction = new CalculatorsFunction();
                calculatorsFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<CalculatorsFunction, string>(calculatorsFunction, blockParameter);
        }

        public Task<string> ReqToExecuteConvertRequestAsync(ReqToExecuteConvertFunction reqToExecuteConvertFunction)
        {
             return ContractHandler.SendRequestAsync(reqToExecuteConvertFunction);
        }

        public Task<TransactionReceipt> ReqToExecuteConvertRequestAndWaitForReceiptAsync(ReqToExecuteConvertFunction reqToExecuteConvertFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(reqToExecuteConvertFunction, cancellationToken);
        }

        public Task<string> ReqToExecuteConvertRequestAsync(BigInteger id)
        {
            var reqToExecuteConvertFunction = new ReqToExecuteConvertFunction();
                reqToExecuteConvertFunction.Id = id;
            
             return ContractHandler.SendRequestAsync(reqToExecuteConvertFunction);
        }

        public Task<TransactionReceipt> ReqToExecuteConvertRequestAndWaitForReceiptAsync(BigInteger id, CancellationTokenSource cancellationToken = null)
        {
            var reqToExecuteConvertFunction = new ReqToExecuteConvertFunction();
                reqToExecuteConvertFunction.Id = id;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(reqToExecuteConvertFunction, cancellationToken);
        }
    }
}
