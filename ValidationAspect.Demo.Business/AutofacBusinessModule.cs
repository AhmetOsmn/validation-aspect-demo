using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using ValidationAspect.Demo.Core.Utilities.Interceptors;
using Module = Autofac.Module;

namespace ValidationAspect.Demo.Business
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
