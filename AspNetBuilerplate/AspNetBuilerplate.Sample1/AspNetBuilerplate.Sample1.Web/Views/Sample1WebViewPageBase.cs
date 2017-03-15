using Abp.Web.Mvc.Views;

namespace AspNetBuilerplate.Sample1.Web.Views
{
    public abstract class Sample1WebViewPageBase : Sample1WebViewPageBase<dynamic>
    {

    }

    public abstract class Sample1WebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected Sample1WebViewPageBase()
        {
            LocalizationSourceName = Sample1Consts.LocalizationSourceName;
        }
    }
}