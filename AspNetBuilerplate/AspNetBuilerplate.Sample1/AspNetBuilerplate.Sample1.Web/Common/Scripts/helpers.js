var App = App || {};
(function () {

    var appLocalizationSource = abp.localization.getSource('Sample1');
    App.localize = function () {
        return appLocalizationSource.apply(this, arguments);
    };

})(App);