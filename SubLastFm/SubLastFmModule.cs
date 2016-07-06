namespace SubLastFm
{
    using Common.DIConventions;

    public class SubLastFmModule : ModuleWithAutoDiscovery
    {
        protected override void PrepareForLoad()
        {
            Conventions.AddRange(new Convetion[] { new ServiceConvention(Injector) });
        }
    }
}
