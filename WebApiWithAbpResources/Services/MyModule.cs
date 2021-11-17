using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace WebApiWithAbpResources
{
    [DependsOn(typeof(AbpLocalizationModule))]
    public class MyModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                // "YourRootNameSpace" is the root namespace of your project. It can be empty if your root namespace is empty.
                options.FileSets.AddEmbedded<MyModule>("WebApiWithAbpResources");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                //Define a new localization resource (TestResource)
                options.Resources
                    .Add<TestResource>("ar")
                    //.AddBaseTypes(typeof(AbpValidationResource)) //Inherit from an existing resource
                    .AddVirtualJson("/Localization/Resources/Test")
                    ;
                options.DefaultResourceType = typeof(TestResource);
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace(  "WebApiWithAbpResources", typeof(TestResource));
            });
        }
    }
}
