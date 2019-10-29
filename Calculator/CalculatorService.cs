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
using Solidity.Contracts.Calculator.ContractDefinition;

namespace Solidity.Contracts.Calculator
{
    public partial class CalculatorService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, CalculatorDeployment calculatorDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<CalculatorDeployment>().SendRequestAndWaitForReceiptAsync(calculatorDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, CalculatorDeployment calculatorDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<CalculatorDeployment>().SendRequestAsync(calculatorDeployment);
        }

        public static async Task<CalculatorService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, CalculatorDeployment calculatorDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, calculatorDeployment, cancellationTokenSource);
            return new CalculatorService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public CalculatorService(Nethereum.Web3.Web3 web3, string contractAddress)
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

        public Task<BigInteger> GetConvertedRestOfCentsQueryAsync(GetConvertedRestOfCentsFunction getConvertedRestOfCentsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetConvertedRestOfCentsFunction, BigInteger>(getConvertedRestOfCentsFunction, blockParameter);
        }

        
        public Task<BigInteger> GetConvertedRestOfCentsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetConvertedRestOfCentsFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> AskRateFromOracleRequestAsync(AskRateFromOracleFunction askRateFromOracleFunction)
        {
             return ContractHandler.SendRequestAsync(askRateFromOracleFunction);
        }

        public Task<TransactionReceipt> AskRateFromOracleRequestAndWaitForReceiptAsync(AskRateFromOracleFunction askRateFromOracleFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(askRateFromOracleFunction, cancellationToken);
        }

        public Task<string> AskRateFromOracleRequestAsync(string oracleAddress)
        {
            var askRateFromOracleFunction = new AskRateFromOracleFunction();
                askRateFromOracleFunction.OracleAddress = oracleAddress;
            
             return ContractHandler.SendRequestAsync(askRateFromOracleFunction);
        }

        public Task<TransactionReceipt> AskRateFromOracleRequestAndWaitForReceiptAsync(string oracleAddress, CancellationTokenSource cancellationToken = null)
        {
            var askRateFromOracleFunction = new AskRateFromOracleFunction();
                askRateFromOracleFunction.OracleAddress = oracleAddress;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(askRateFromOracleFunction, cancellationToken);
        }

        public Task<BigInteger> GetIdQueryAsync(GetIdFunction getIdFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetIdFunction, BigInteger>(getIdFunction, blockParameter);
        }

        
        public Task<BigInteger> GetIdQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetIdFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> GetConvertedUsdQueryAsync(GetConvertedUsdFunction getConvertedUsdFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetConvertedUsdFunction, BigInteger>(getConvertedUsdFunction, blockParameter);
        }

        
        public Task<BigInteger> GetConvertedUsdQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetConvertedUsdFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> ConvertRequestAsync(ConvertFunction convertFunction)
        {
             return ContractHandler.SendRequestAsync(convertFunction);
        }

        public Task<string> ConvertRequestAsync()
        {
             return ContractHandler.SendRequestAsync<ConvertFunction>();
        }

        public Task<TransactionReceipt> ConvertRequestAndWaitForReceiptAsync(ConvertFunction convertFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(convertFunction, cancellationToken);
        }

        public Task<TransactionReceipt> ConvertRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<ConvertFunction>(null, cancellationToken);
        }

        public Task<string> ReqToConvertSummaRequestAsync(ReqToConvertSummaFunction reqToConvertSummaFunction)
        {
             return ContractHandler.SendRequestAsync(reqToConvertSummaFunction);
        }

        public Task<TransactionReceipt> ReqToConvertSummaRequestAndWaitForReceiptAsync(ReqToConvertSummaFunction reqToConvertSummaFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(reqToConvertSummaFunction, cancellationToken);
        }

        public Task<string> ReqToConvertSummaRequestAsync(BigInteger rubs, BigInteger kops, BigInteger k)
        {
            var reqToConvertSummaFunction = new ReqToConvertSummaFunction();
                reqToConvertSummaFunction.Rubs = rubs;
                reqToConvertSummaFunction.Kops = kops;
                reqToConvertSummaFunction.K = k;
            
             return ContractHandler.SendRequestAsync(reqToConvertSummaFunction);
        }

        public Task<TransactionReceipt> ReqToConvertSummaRequestAndWaitForReceiptAsync(BigInteger rubs, BigInteger kops, BigInteger k, CancellationTokenSource cancellationToken = null)
        {
            var reqToConvertSummaFunction = new ReqToConvertSummaFunction();
                reqToConvertSummaFunction.Rubs = rubs;
                reqToConvertSummaFunction.Kops = kops;
                reqToConvertSummaFunction.K = k;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(reqToConvertSummaFunction, cancellationToken);
        }

        public Task<string> SetIdRequestAsync(SetIdFunction setIdFunction)
        {
             return ContractHandler.SendRequestAsync(setIdFunction);
        }

        public Task<TransactionReceipt> SetIdRequestAndWaitForReceiptAsync(SetIdFunction setIdFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setIdFunction, cancellationToken);
        }

        public Task<string> SetIdRequestAsync(BigInteger id)
        {
            var setIdFunction = new SetIdFunction();
                setIdFunction.Id = id;
            
             return ContractHandler.SendRequestAsync(setIdFunction);
        }

        public Task<TransactionReceipt> SetIdRequestAndWaitForReceiptAsync(BigInteger id, CancellationTokenSource cancellationToken = null)
        {
            var setIdFunction = new SetIdFunction();
                setIdFunction.Id = id;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setIdFunction, cancellationToken);
        }

        public Task<BigInteger> GetRestKopsPerOneUsdQueryAsync(GetRestKopsPerOneUsdFunction getRestKopsPerOneUsdFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetRestKopsPerOneUsdFunction, BigInteger>(getRestKopsPerOneUsdFunction, blockParameter);
        }

        
        public Task<BigInteger> GetRestKopsPerOneUsdQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetRestKopsPerOneUsdFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> GetRubsQueryAsync(GetRubsFunction getRubsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetRubsFunction, BigInteger>(getRubsFunction, blockParameter);
        }

        
        public Task<BigInteger> GetRubsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetRubsFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> GetKopsQueryAsync(GetKopsFunction getKopsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetKopsFunction, BigInteger>(getKopsFunction, blockParameter);
        }

        
        public Task<BigInteger> GetKopsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetKopsFunction, BigInteger>(null, blockParameter);
        }
    }
}
