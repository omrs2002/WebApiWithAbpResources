using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace WebApiWithAbpResources
{
    public class MyService : ITransientDependency
    {
        private readonly IStringLocalizer<TestResource> _localizer;

        public MyService(IStringLocalizer<TestResource> localizer)
        {
            _localizer = localizer;
        }

        public string Foo()
        {
            var str = _localizer["HelloWorld"];
            return str;
        }
    }

}
