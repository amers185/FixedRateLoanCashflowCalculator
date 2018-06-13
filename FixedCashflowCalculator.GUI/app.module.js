var cashflowCalculatorModule = angular.module('cashflowCalculatorApp', ['ui.bootstrap', 'ngAnimate']);

cashflowCalculatorModule.component('loans', {
    templateUrl: './loans.html',
    controller: ['$http', '$scope', function ($http, $scope) {
        var self = this;
        self.loans = [];
        self.loan = {};

        self.addLoan = function () {
            if (self.loan.balance)
                if (self.loan.balance <= 0 || isNaN(self.loan.balance))
                    return alertify.error("Error, balance must be positive real number!");
            if (self.loan.balance > 1000000000)
                return alertify.error("Error, balance must be less than $1,000,000,000");
            if (self.loan.term <= 0 || isNaN(self.loan.term))
                return alertify.error("Error, term must be positive real number!");
            if (self.loan.term > 1000)
                return alertify.error("Error, maximum term is 1,000 months!");
            if (self.loan.rate <= 0 || isNaN(self.loan.rate))
                return alertify.error("Error, rate must be positive real number!");
            if (self.loan.rate > 15)
                return alertify.error("Error, maximum rate is 15%, you entered " + self.loan.rate + "% you jerk!");
            $http.post('http://localhost:50148/api/CashflowCalculator/AddLoan', self.loan).then(
                function (response) {
                    self.loan.id = response.data;
                    self.loans.push(angular.copy(self.loan));
                    console.log(JSON.stringify(self.loans));
                    alertify.success('Loan successfully added');
                },
                function (error) {
                    alertify.error('Invalid data');
                    console.log(response);
                }
            );
        };

    }]
});
