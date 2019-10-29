using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace Solidity.Contracts.Calculator.ContractDefinition
{


    public partial class CalculatorDeployment : CalculatorDeploymentBase
    {
        public CalculatorDeployment() : base(BYTECODE) { }
        public CalculatorDeployment(string byteCode) : base(byteCode) { }
    }

    public class CalculatorDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b5061041f806100206000396000f3fe60806040526004361061009c5760003560e01c806391bbdcc71161006457806391bbdcc71461013c578063aa90997b14610144578063d0e0ba951461017a578063ea28c31e146101a4578063f0bbb598146101b9578063fc7ce492146101ce5761009c565b8063251f8e5a146100a15780632cc3a6f6146100c8578063521f9934146100dd5780635d1ca6311461011257806362cc9b5914610127575b600080fd5b3480156100ad57600080fd5b506100b66101e3565b60408051918252519081900360200190f35b3480156100d457600080fd5b506100b66101e9565b3480156100e957600080fd5b506101106004803603602081101561010057600080fd5b50356001600160a01b03166101ef565b005b34801561011e57600080fd5b506100b661032e565b34801561013357600080fd5b506100b6610334565b61011061033a565b34801561015057600080fd5b506101106004803603606081101561016757600080fd5b50803590602081013590604001356103c5565b34801561018657600080fd5b506101106004803603602081101561019d57600080fd5b50356103d3565b3480156101b057600080fd5b506100b66103d8565b3480156101c557600080fd5b506100b66103de565b3480156101da57600080fd5b506100b66103e4565b60005490565b60035490565b6000819050806001600160a01b031663251f8e5a6040518163ffffffff1660e01b815260040160206040518083038186803b15801561022d57600080fd5b505afa158015610241573d6000803e3d6000fd5b505050506040513d602081101561025757600080fd5b505160005560408051637514618f60e11b815290516001600160a01b0383169163ea28c31e916004808301926020929190829003018186803b15801561029c57600080fd5b505afa1580156102b0573d6000803e3d6000fd5b505050506040513d60208110156102c657600080fd5b505160015560408051630c53468f60e41b815230600482015290516001600160a01b0383169163c53468f091602480830192600092919082900301818387803b15801561031257600080fd5b505af1158015610326573d6000803e3d6000fd5b505050505050565b60075490565b60025490565b6005546006546004546001546000549183029093019291020180828161035c57fe5b04600255600081838161036b57fe5b0690508181600654028161037b57fe5b04600381905560025460408051918252602082019290925281517f02d72fe7407400effbf796922c83b93114531ad5fad7b845fbee1005a2ce6200929181900390910190a1505050565b600492909255600555600655565b600755565b60015490565b60045490565b6005549056fea265627a7a723158206931a668a19af9d71b16bd28a495cb275723ce8af4a3102c3a21d031c6aa0ceb64736f6c634300050b0032";
        public CalculatorDeploymentBase() : base(BYTECODE) { }
        public CalculatorDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class GetRubsPerOneUsdFunction : GetRubsPerOneUsdFunctionBase { }

    [Function("getRubsPerOneUsd", "uint256")]
    public class GetRubsPerOneUsdFunctionBase : FunctionMessage
    {

    }

    public partial class GetConvertedRestOfCentsFunction : GetConvertedRestOfCentsFunctionBase { }

    [Function("getConvertedRestOfCents", "uint256")]
    public class GetConvertedRestOfCentsFunctionBase : FunctionMessage
    {

    }

    public partial class AskRateFromOracleFunction : AskRateFromOracleFunctionBase { }

    [Function("askRateFromOracle")]
    public class AskRateFromOracleFunctionBase : FunctionMessage
    {
        [Parameter("address", "oracleAddress", 1)]
        public virtual string OracleAddress { get; set; }
    }

    public partial class GetIdFunction : GetIdFunctionBase { }

    [Function("getId", "uint256")]
    public class GetIdFunctionBase : FunctionMessage
    {

    }

    public partial class GetConvertedUsdFunction : GetConvertedUsdFunctionBase { }

    [Function("getConvertedUsd", "uint256")]
    public class GetConvertedUsdFunctionBase : FunctionMessage
    {

    }

    public partial class ConvertFunction : ConvertFunctionBase { }

    [Function("convert")]
    public class ConvertFunctionBase : FunctionMessage
    {

    }

    public partial class ReqToConvertSummaFunction : ReqToConvertSummaFunctionBase { }

    [Function("reqToConvertSumma")]
    public class ReqToConvertSummaFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_rubs", 1)]
        public virtual BigInteger Rubs { get; set; }
        [Parameter("uint256", "_kops", 2)]
        public virtual BigInteger Kops { get; set; }
        [Parameter("uint256", "_k", 3)]
        public virtual BigInteger K { get; set; }
    }

    public partial class SetIdFunction : SetIdFunctionBase { }

    [Function("setId")]
    public class SetIdFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_id", 1)]
        public virtual BigInteger Id { get; set; }
    }

    public partial class GetRestKopsPerOneUsdFunction : GetRestKopsPerOneUsdFunctionBase { }

    [Function("getRestKopsPerOneUsd", "uint256")]
    public class GetRestKopsPerOneUsdFunctionBase : FunctionMessage
    {

    }

    public partial class GetRubsFunction : GetRubsFunctionBase { }

    [Function("getRubs", "uint256")]
    public class GetRubsFunctionBase : FunctionMessage
    {

    }

    public partial class GetKopsFunction : GetKopsFunctionBase { }

    [Function("getKops", "uint256")]
    public class GetKopsFunctionBase : FunctionMessage
    {

    }

    public partial class EventOfResultEventDTO : EventOfResultEventDTOBase { }

    [Event("EventOfResult")]
    public class EventOfResultEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "_usd", 1, false )]
        public virtual BigInteger Usd { get; set; }
        [Parameter("uint256", "_cent", 2, false )]
        public virtual BigInteger Cent { get; set; }
    }

    public partial class GetRubsPerOneUsdOutputDTO : GetRubsPerOneUsdOutputDTOBase { }

    [FunctionOutput]
    public class GetRubsPerOneUsdOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetConvertedRestOfCentsOutputDTO : GetConvertedRestOfCentsOutputDTOBase { }

    [FunctionOutput]
    public class GetConvertedRestOfCentsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class GetIdOutputDTO : GetIdOutputDTOBase { }

    [FunctionOutput]
    public class GetIdOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetConvertedUsdOutputDTO : GetConvertedUsdOutputDTOBase { }

    [FunctionOutput]
    public class GetConvertedUsdOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }







    public partial class GetRestKopsPerOneUsdOutputDTO : GetRestKopsPerOneUsdOutputDTOBase { }

    [FunctionOutput]
    public class GetRestKopsPerOneUsdOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetRubsOutputDTO : GetRubsOutputDTOBase { }

    [FunctionOutput]
    public class GetRubsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetKopsOutputDTO : GetKopsOutputDTOBase { }

    [FunctionOutput]
    public class GetKopsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }
}
