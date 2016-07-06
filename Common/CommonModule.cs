namespace Common
{
    using Common.DIConventions;
    using Common.Interfaces;
    using Common.Services;

    public class CommonModule : ModuleWithAutoDiscovery
    {
        protected override void PrepareForLoad()
        {
            Singletons.Add<IHtmlTransformService, HtmlTransformService>();
        }
    }
}
