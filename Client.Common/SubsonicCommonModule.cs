namespace Client.Common
{
    using global::Common.DIConventions;

    public class SubsonicCommonModule : ModuleWithAutoDiscovery
    {
        #region Methods

        protected override void PrepareForLoad()
        {
            Conventions.Add(new ServiceConvention(Container));
        }

        #endregion
    }
}