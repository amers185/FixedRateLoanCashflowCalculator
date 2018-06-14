var cashflowCalculatorModule = angular.module('cashflowCalculatorApp', ['ui.bootstrap', 'ngAnimate']);
cashflowCalculatorModule.controller('LoanController', ['$scope', '$http', function ($scope, $http) {
    var self = this;
    self.loans = [];
    self.loan = {};
    self.idsToDelete = [];
    self.cashFlows = [];
    self.cashFlow = [];
    self.monthlypayment = {};
    self.poolCashFlow = [];

    self.getLoans = function () {
        $http.get('http://localhost:50148/api/CashflowCalculator/GetLoans')
            .then(function (success) {
                self.loans = success.data;
            },
                function (error) {
                    alert("Error!");
                });
    };

    self.getCashFlows = function () {
        $http.get('http://localhost:50148/api/CashflowCalculator/GetCashflows').then(
            function (success) {
                self.cashFlows = success.data;
             
            },
            function (error) {
                alert("error");
            }
        );
    };
   
    class MonthlyPayment {
        constructor(Month, Interest, Pricipal, RemainingBalance) {
            this.Month = Month;
            this.Interest = Interest;
            this.Principal = Principal;
            this.RemainingBalance = RemainingBalance;
        }
    }

    class Loan {
        constructor(Amount, Duration, Rate) {
            this.Amount = Amount;
            this.Duration = Duration;
            this.Rate = Rate;
        }
    }

    self.inputLoan = function (Amount, Duration, Rate) {
        var loan = new Loan(Amount, Duration, Rate);
        if (Amount < 0 || Duration < 0 || Rate < 0) {
            alert("Please enter positive values");
            throw "Please enter positive values";
        }
        if (Rate <= .5) {
            alert("Please enter the interest rate in % form (e.g. 10%)");
            throw "Please enter positive values";
        }
        $http.post('http://localhost:50148/api/CashflowCalculator/AddLoan', loan).then(
            function (success) {
                self.loan.id = success.data;
                //self.getLoans();

            
            },
            function (error) {
                alert("Error!");
            }
        );
    };

    //self.getLoans();
}]);
    