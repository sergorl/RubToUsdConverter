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

namespace Solidity.Contracts.Oracle.ContractDefinition
{


    public partial class OracleDeployment : OracleDeploymentBase
    {
        public OracleDeployment() : base(BYTECODE) { }
        public OracleDeployment(string byteCode) : base(byteCode) { }
    }

    public class OracleDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "6080604052600060035534801561001557600080fd5b506102f5806100256000396000f3fe608060405234801561001057600080fd5b506004361061007d5760003560e01c8063e726965a1161005b578063e726965a146100cc578063ea28c31e146100ef578063f26f09aa146100f7578063f602be33146101305761007d565b8063251f8e5a146100825780635d1ca6311461009c578063c53468f0146100a4575b600080fd5b61008a61014d565b60408051918252519081900360200190f35b61008a610153565b6100ca600480360360208110156100ba57600080fd5b50356001600160a01b0316610159565b005b6100ca600480360360408110156100e257600080fd5b50803590602001356101f5565b61008a610238565b6101146004803603602081101561010d57600080fd5b503561023e565b604080516001600160a01b039092168252519081900360200190f35b6100ca6004803603602081101561014657600080fd5b5035610259565b60005490565b60035490565b6003805460009081526002602052604080822080546001600160a01b0319166001600160a01b0386811691909117909155925480835281832054825163d0e0ba9560e01b815260048101929092529151919093169263d0e0ba9592602480830193919282900301818387803b1580156101d157600080fd5b505af11580156101e5573d6000803e3d6000fd5b5050600380546001019055505050565b6000829055600181905560035460408051918252517f4f6bb70aca6fc7c47363f52ec110d56d9621d246d07a15ca323ee62afdc448bb9181900360200190a15050565b60015490565b6002602052600090815260409020546001600160a01b031681565b6000818152600260205260408082205481516391bbdcc760e01b815291516001600160a01b03909116926391bbdcc7926004808201939182900301818387803b1580156102a557600080fd5b505af11580156102b9573d6000803e3d6000fd5b505050505056fea265627a7a72315820e1a96ac1650803014b6eba096cadbe18e5f4a4b5c615537a4da6a2227703c89764736f6c634300050b0032";
        public OracleDeploymentBase() : base(BYTECODE) { }
        public OracleDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class GetRubsPerOneUsdFunction : GetRubsPerOneUsdFunctionBase { }

    [Function("getRubsPerOneUsd", "uint256")]
    public class GetRubsPerOneUsdFunctionBase : FunctionMessage
    {

    }

    public partial class GetIdFunction : GetIdFunctionBase { }

    [Function("getId", "uint256")]
    public class GetIdFunctionBase : FunctionMessage
    {

    }

    public partial class SetCalculatorFunction : SetCalculatorFunctionBase { }

    [Function("setCalculator")]
    public class SetCalculatorFunctionBase : FunctionMessage
    {
        [Parameter("address", "addressCalculator", 1)]
        public virtual string AddressCalculator { get; set; }
    }

    public partial class ReqToSetRateFunction : ReqToSetRateFunctionBase { }

    [Function("reqToSetRate")]
    public class ReqToSetRateFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_rubsPerOneUsd", 1)]
        public virtual BigInteger RubsPerOneUsd { get; set; }
        [Parameter("uint256", "_restKopsPerOneUsd", 2)]
        public virtual BigInteger RestKopsPerOneUsd { get; set; }
    }

    public partial class GetRestKopsPerOneUsdFunction : GetRestKopsPerOneUsdFunctionBase { }

    [Function("getRestKopsPerOneUsd", "uint256")]
    public class GetRestKopsPerOneUsdFunctionBase : FunctionMessage
    {

    }

    public partial class CalculatorsFunction : CalculatorsFunctionBase { }

    [Function("calculators", "address")]
    public class CalculatorsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class ReqToExecuteConvertFunction : ReqToExecuteConvertFunctionBase { }

    [Function("reqToExecuteConvert")]
    public class ReqToExecuteConvertFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_id", 1)]
        public virtual BigInteger Id { get; set; }
    }

    public partial class EventLogEventDTO : EventLogEventDTOBase { }

    [Event("EventLog")]
    public class EventLogEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "_id", 1, false )]
        public virtual BigInteger Id { get; set; }
    }

    public partial class GetRubsPerOneUsdOutputDTO : GetRubsPerOneUsdOutputDTOBase { }

    [FunctionOutput]
    public class GetRubsPerOneUsdOutputDTOBase : IFunctionOutputDTO 
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





    public partial class GetRestKopsPerOneUsdOutputDTO : GetRestKopsPerOneUsdOutputDTOBase { }

    [FunctionOutput]
    public class GetRestKopsPerOneUsdOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class CalculatorsOutputDTO : CalculatorsOutputDTOBase { }

    [FunctionOutput]
    public class CalculatorsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }


}
