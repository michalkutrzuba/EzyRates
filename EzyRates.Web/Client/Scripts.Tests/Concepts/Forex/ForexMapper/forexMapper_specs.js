"use strict";

describe("when respone is valid", () => {

    const response = 
    {
        "updatedOn": "2017-07-14T21:46:00",
        "currencies": 
        [
            {
                "details": {
                    "code": "fakeCode1",
                    "name": "fakeName1" 
                },
                "rate": {
                    "buy": 0.123,
                    "sell": 1.123,
                    "multiply": 2
                },
                "guide": {
                    "from": "from1",
                    "to": "to1",
                    "amount": 3,
                    "value": 4.123
                }
            },
            {
                "details": {
                    "code": "fakeCode2",
                    "name": "fakeName2" 
                },
                "rate": {
                    "buy": 10.123,
                    "sell": 11.123,
                    "multiply": 12
                },
                "guide": {
                    "from": "from2",
                    "to": "to2",
                    "amount": 13,
                    "value": 14.123
                }
            }
        ]
    };

    let result;

    beforeEach(() => {
        result = new ForexViewModel();
        new ForexMapper().toViewModel(response, result);
    });

    it("should map correctly forex model", () => { 
        result.updatedOn().should.equal("2017-07-14T21:46:00");
        result.currencies().length.should.equal(2);
    });

    it("should map correctly first rate", () => {
        let rate = result.currencies()[0];

        rate.details.code().should.equal("fakeCode1");
        rate.details.name().should.equal("fakeName1");

        rate.rate.buy().should.equal("0.12");
        rate.rate.sell().should.equal("1.12");
        rate.rate.multiply().should.equal(2);

        rate.guide.from().should.equal("from1");
        rate.guide.to().should.equal("to1");
        rate.guide.amount().should.equal(3);
        rate.guide.value().should.equal("4.12");
    });

    it("should map correctly second rate", () => {
        let rate = result.currencies()[1];

        rate.details.code().should.equal("fakeCode2");
        rate.details.name().should.equal("fakeName2");

        rate.rate.buy().should.equal("10.12");
        rate.rate.sell().should.equal("11.12");
        rate.rate.multiply().should.equal(12);

        rate.guide.from().should.equal("from2");
        rate.guide.to().should.equal("to2");
        rate.guide.amount().should.equal(13);
        rate.guide.value().should.equal("14.12");
    });
});
