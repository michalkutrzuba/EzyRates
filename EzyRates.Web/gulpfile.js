"use strict";

var gulp = require("gulp"),
    babel = require("gulp-babel"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    karma = require("gulp-karma-runner"),
    sass = require("gulp-sass"),
    sourcemaps = require("gulp-sourcemaps"),
    uglify = require("gulp-uglify"),
    rimraf = require("rimraf");

var paths = {
    source: "./Client/",
    webroot: "./wwwroot/"
};

paths.js = paths.source + "Scripts/**/*.js";
paths.sass = paths.source + "Styles/**/*.scss";

paths.jsDest = paths.webroot + "js/";
paths.jsDestFile = paths.jsDest + "site.min.js";
paths.jsDestMaps = paths.jsDest + "maps";

paths.cssDest = paths.webroot + "css/";
paths.cssDestFile = paths.cssDest + "site.min.css";
paths.cssDestMaps = paths.cssDest + "maps";

gulp.task("clean:js", function (cb) {
    rimraf(paths.jsDest + "*", cb);
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.cssDest + "*", cb);
});

gulp.task("compile:js::debug", function () {
    return gulp.src(paths.js)
        .pipe(sourcemaps.init())
        .pipe(babel({ presets: ['es2015'] }))
        .pipe(concat(paths.jsDestFile))
        .pipe(sourcemaps.write(paths.jsDestMaps))
        .pipe(gulp.dest("."));
});

gulp.task("compile:js::release", function () {
    return gulp.src(paths.js)
        .pipe(babel({ presets: ['es2015'] }))
        .pipe(concat(paths.jsDestFile))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});

gulp.task("compile:css::debug", function () {
    return gulp.src(paths.sass)
        .pipe(sourcemaps.init())
        .pipe(sass().on('error', sass.logError))
        .pipe(concat(paths.cssDestFile))
        .pipe(sourcemaps.write(paths.cssDestMaps))
        .pipe(gulp.dest("."));
});

gulp.task("compile:css::release", function () {
    return gulp.src(paths.sass)
        .pipe(sass().on('error', sass.logError))
        .pipe(concat(paths.cssDestFile))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});

gulp.task("compile::debug", ["compile:js::debug", "compile:css::debug"]);

gulp.task("compile::release", ["compile:js::release", "compile:css::release"]);

gulp.task("build::debug", ["clean:js", "clean:css", "compile:js::debug", "compile:css::debug"]);

gulp.task("build::release", ["clean:js", "clean:css", "compile:js::release", "compile:css::release"]);


// Tests

paths.jsTests = paths.source + "Scripts.Tests/**/*.js";
paths.lib = paths.webroot + "lib/";
paths.libBootstrap = paths.lib + "bootstrap/dist/bootstrap.js";
paths.libJquery = paths.lib + "jquery/dist/jquery.js";
paths.libKnockout = paths.lib + "knockout/dist/knockout.debug.js";

var testSrc = [paths.libBootstrap, paths.libJquery, paths.libKnockout, paths.js, paths.jsTests];

gulp.task("test:singleRun::phantom", function () {
    gulp.src(testSrc, {"read": false})
        .pipe(
            karma.server({
                "configFile": "./karma.conf.js",
                "singleRun": true,
                "browsers": ["PhantomJS"]
            })
        );
});

gulp.task("test:singleRun::chrome", function () {
    gulp.src(testSrc, {"read": false})
        .pipe(
            karma.server({
                "configFile": "./karma.conf.js",
                "singleRun": true,
                "browsers": ["Chrome"]
            })
        );
});

gulp.task("test:watch::chrome", function () {
    gulp.src(testSrc, {"read": false})
        .pipe(
            karma.server({
                "configFile": "./karma.conf.js",
                "browsers": ["Chrome"]
            })
        );
});