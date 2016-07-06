namespace SubEchoNest
{
    using Common.DIConventions;

    public class SubEchoNestModule : ModuleWithAutoDiscovery
    {
        protected override void PrepareForLoad()
        {
            Conventions.AddRange(new Convetion[] { new ServiceConvention(Injector) });
        }
    }
}
