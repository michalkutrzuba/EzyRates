"use strict";

class CurrencyDetailsViewModel {
    constructor() {
        this.code = ko.observable("");
        this.name = ko.observable("");
    }
}

class CurrencyRatesViewModel {
    constructor() {
        this.buy = ko.observable("");
        this.sell = ko.observable("");
        this.multiply = ko.observable("");
    }
}

class CurrencyGuideViewModel {
    constructor() {
        this.from = ko.observable("");
        this.to = ko.observable("");
        this.amount = ko.observable("");
        this.value = ko.observable("");

        this.toUserInfo = ko.pureComputed(
            () => `${this.amount()}${this.from()} is worth ${this.value()}${this.to()}`,
            this)
    }
}

class CurrencyViewModel {
    constructor() {
        this.details = new CurrencyDetailsViewModel();
        this.rate = new CurrencyRatesViewModel();
        this.guide = new CurrencyGuideViewModel();
    }
}

class ForexViewModel {
    constructor() {
        this.updatedOn = ko.observable("");
        this.currencies = ko.observableArray([]);

        this.hasCurrencies = ko.pureComputed(() => this.currencies().length > 0, this)
    }

    updateRates() {
        new HttpClient()
            .getJsonAsync(AppSettings.GetRatesUrl())
            .then(response => {new ForexMapper().toViewModel(response, this)})
            .then(response => {
                $('[data-toggle="tooltip"]').tooltip();
                $('[data-toggle="popover"]').popover();
            });
    }
}

ko.applyBindings(new ForexViewModel());