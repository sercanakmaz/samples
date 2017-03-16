namespace Serene.Sample1.ScriptInitialization {
    Q.Config.responsiveDialogs = true;
    Q.Config.rootNamespaces.push('Serene.Sample1');
    Serenity.EntityDialog.defaultLanguageList = LanguageList.getValue;
}