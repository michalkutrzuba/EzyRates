"use strict";

class ForexMapper {

    toViewModel(response, viewModel) {

        viewModel.updatedOn(response.updatedOn);
        viewModel.currencies(response.currencies.map(rate => {

            let model = new CurrencyViewModel();

            model.details.code(rate.details.code);
            model.details.name(rate.details.name);

            model.rate.buy(rate.rate.buy.toFixed(2));
            model.rate.sell(rate.rate.sell.toFixed(2));
            model.rate.multiply(rate.rate.multiply);

            model.guide.from(rate.guide.from);
            model.guide.to(rate.guide.to);
            model.guide.amount(rate.guide.amount);
            model.guide.value(rate.guide.value.toFixed(2));

            return model;
        }));
    }
}
