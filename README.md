## Conversion rub to usd with solidity smart contacts


Demo application generates the requests with random value of rub and then converts it to usd with using contracts `Calculator` and  `Oracle`.
Inside `Converter.sol` there are two solidity smart contracts:

1. `Calculator` is dedicated for conversion from rub to usd according current day rate of usd from [CRB](https://www.cbr.ru/)
2. `Oracle` is dedicated for getting request of current day usd rate outside of blockchain and executing the `Calculator` above

Both contracts above were converted (more precisly were adapted) into c# classes `Calculator.cs` and `Oracle.cs` with using framework [Nethereum](https://nethereum.com/)



### Dependencies

```xml
    <PackageReference Include="Nethereum.Web3" Version="3.4.0" />
    <PackageReference Include="Serilog.Sinks.File" Version="4.1.0" />
```

### Logs

All logs with result of conversion from solidity contract `Calculator` are accessed by `https://localhost:5001/log?file=log.txt`, where `file` is the path to log file `log.txt`


### How to run it

1. First, to test the conversion from rub to usd, use [TestChain](https://github.com/Nethereum/TestChains). So, for linux:

    Launch `>> geth-clique-linux > startgeth.sh`

    Note: use `chmod +x startgeth.sh` and `chmod +x geth` to allow geth to execute.

2. Then do the `dotnet run` to run the demo of conversion rub to usd. Console should show something like this:

    `Contract address 0x2a89a49ece5e7211f4ca99ff2df2de85b4fac485 from thread # 12: 390,7407 rub => 6,1177 usd with rate 1 usd = 63,8699 rub`
