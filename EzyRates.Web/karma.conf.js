module.exports = function (config) {
    config.set({
        babelPreprocessor: {
            options: {
                presets: ['es2015'],
                sourceMap: 'inline'
            },
            filename: function (file) {
                return file.originalPath.replace(/\.js$/, '.es5.js');
            },
            sourceFileName: function (file) {
                return file.originalPath;
            }
        },
        basePath: "",
        colors: true,
        exclude: [],
        files: [
            "Client/Scripts/**/*.js",
            "Client/Scripts.Tests/**/*.js"
        ],
        frameworks: ["mocha", "chai", "sinon"],
        logLevel: config.LOG_INFO,
        plugins: [
            "karma-*"
        ],
        port: 9876,
        preprocessors: {
            "Client/Scripts/**/*.js": ['babel'],
            "Client/Scripts.Tests/**/*.js": ['babel']
        },
        reporters: ["mocha"],
        client: {
            mocha: {
                require: ["chai.conf.js"]
            }
        }
    });
};