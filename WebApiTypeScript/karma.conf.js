// Karma configuration
// Generated on Tue Aug 23 2016 11:42:58 GMT+0200 (Mitteleuropäische Sommerzeit)

module.exports = function (config) {
    config.set({

        // base path that will be used to resolve all patterns (eg. files, exclude)
        basePath: '',


        // frameworks to use
        // available frameworks: https://npmjs.org/browse/keyword/karma-adapter
        frameworks: ['jasmine'],


        // list of files / patterns to load in the browser
        files: [
            'Scripts/jquery-3.1.0.js',
            'Scripts/angular.js',
            'Scripts/ui-bootstrap.js',
            'Scripts/angular-mocks.js',
            'Scripts/angular-animate.js',
            'Scripts/angular-route.js',
            'Scripts/angular-resource.js',
            //'Scripts/angular-sanitize.js',
            //'Scripts/angular-cookies.js',
            //'Scripts/angular-translate.js',
            //'Scripts/*.js',
            //'Scripts/!(jquery-3.1.0.intellisense).js',
            //'Scripts/**/*.js',
            'Angular/**/*.js',
            'Tests/*.js'
        ],


        // list of files to exclude
        exclude: [
        ],


        // preprocess matching files before serving them to the browser
        // available preprocessors: https://npmjs.org/browse/keyword/karma-preprocessor
        preprocessors: {
        },


        // test results reporter to use
        // possible values: 'dots', 'progress'
        // available reporters: https://npmjs.org/browse/keyword/karma-reporter
        reporters: ['progress', 'htmlDetailed'],

        // notify karma of the available plugins
        plugins: [
          'karma-jasmine',
          'karma-chrome-launcher',
          'karma-html-detailed-reporter',
          'karma-phantomjs-launcher'
        ],

        // configure the HTML-Detailed-Reporter to put all results in one file    
        htmlDetailed: {
            splitResults: false
        },

        // web server port
        port: 9876,


        // enable / disable colors in the output (reporters and logs)
        colors: true,


        // level of logging
        // possible values: config.LOG_DISABLE || config.LOG_ERROR || config.LOG_WARN || config.LOG_INFO || config.LOG_DEBUG
        logLevel: config.LOG_INFO,


        // enable / disable watching file and executing tests whenever any file changes
        autoWatch: true,


        // start these browsers
        // available browser launchers: https://npmjs.org/browse/keyword/karma-launcher
        browsers: ['Chrome', /*'PhantomJS'*/],


        // Continuous Integration mode
        // if true, Karma captures browsers, runs the tests and exits
        singleRun: false,

        // Concurrency level
        // how many browser should be started simultaneous
        concurrency: Infinity
    })
}