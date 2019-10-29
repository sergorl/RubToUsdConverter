pragma solidity >=0.5.0;

contract Calculator {

    event EventOfResult(uint _usd, uint _cent);

    uint rubsPerOneUsd;
    uint restKopsPerOneUsd;

    uint estimatedUsd;
    uint estimatedRestOfCents;

    uint rubs;
    uint kops;
    uint k;

    uint id;

    function reqToConvertSumma(uint _rubs, uint _kops, uint _k /*for cent precision*/) public {
        rubs = _rubs;
        kops = _kops;
        k = _k;
    }

    function convert() public payable {

        uint kopsOfSumma = rubs * k + kops;
        uint kopsPerOneUSD = rubsPerOneUsd * k + restKopsPerOneUsd;

        estimatedUsd = kopsOfSumma / kopsPerOneUSD;
        uint restOfKops = kopsOfSumma % kopsPerOneUSD;
        estimatedRestOfCents = (k * restOfKops) / kopsPerOneUSD;

        emit EventOfResult(estimatedUsd, estimatedRestOfCents);
    }

    function askRateFromOracle(address oracleAddress) public {
        Oracle oracle = Oracle(oracleAddress);

        rubsPerOneUsd = oracle.getRubsPerOneUsd();
        restKopsPerOneUsd = oracle.getRestKopsPerOneUsd();

        oracle.setCalculator(address(this));
    }

    function getId() public view returns(uint) {
        return id;
    }

    function setId(uint _id) public {
        id = _id;
    }

    function getConvertedUsd() public view returns(uint) {
        return estimatedUsd;
    }

    function getConvertedRestOfCents() public view returns(uint) {
        return estimatedRestOfCents;
    }

    function getRubs() public view returns(uint) {
        return rubs;
    }

     function getKops() public view returns(uint) {
        return kops;
    }

    function getRubsPerOneUsd() public view returns(uint) {
        return rubsPerOneUsd;
    }

    function getRestKopsPerOneUsd() public view returns(uint) {
        return restKopsPerOneUsd;
    }
}

contract Oracle {

    uint rubsPerOneUsd;
    uint restKopsPerOneUsd;

    mapping(uint => Calculator) public calculators;

    uint id = 0;

    event EventLog(uint _id);

    function getRubsPerOneUsd() public view returns(uint) {
        return rubsPerOneUsd;
    }

    function getRestKopsPerOneUsd() public view returns(uint) {
        return restKopsPerOneUsd;
    }

    function reqToSetRate(uint _rubsPerOneUsd, uint _restKopsPerOneUsd) public {
        rubsPerOneUsd = _rubsPerOneUsd;
        restKopsPerOneUsd = _restKopsPerOneUsd;

        emit EventLog(id);
    }

    function setCalculator(address addressCalculator) public {
        calculators[id] = Calculator(addressCalculator);
        calculators[id].setId(id);

        ++id;
    }

    function reqToExecuteConvert(uint _id) public {
        calculators[_id].convert();
    }

    function getId() public view returns(uint) {
        return id;
    }
}