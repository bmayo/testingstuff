using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingStuff
{
    public class ExplicitInterfacePractice
    {
        public string GetReponse()
        {
            IBaseReponse proxy = new ProxyReponseStub();

            return proxy.GetReponse();
        }

        public string GetAlphaReponse()
        {
            IAlphaReponse proxy = new ProxyReponseStub();

            return proxy.GetReponse();
        }

        public string GetBetaReponse()
        {
            IBetaReponse proxy = new ProxyReponseStub();

            return proxy.GetReponse();
        }

        public string GetReponse<T>() where T  : IBaseReponse
        {
            var proxy = new ProxyReponseStub();

            return proxy.GetReponse<T>();
        }
    }

    

    public interface IBaseReponse
    {
        string GetReponse();
    }



    public interface IAlphaReponse : IBaseReponse
    {
        new string GetReponse();
    }

    public interface IBetaReponse: IBaseReponse
    {
        new string GetReponse();
    }

    public class ProxyReponseStub : IAlphaReponse, IBetaReponse
    {
        public string GetReponse<T>()
        {
            if(typeof(T) == typeof(IAlphaReponse))
            {
                return ((IAlphaReponse)this).GetReponse();
            }
            else if(typeof(T) == typeof(IBetaReponse))
            {
                return ((IBetaReponse)this).GetReponse();
            }

            return GetReponse();
        }

        public string GetReponse()
        {
            return "omega";
        }

        string IAlphaReponse.GetReponse()
        {
            return "alpha";
        }

        string IBetaReponse.GetReponse()
        {
            return "beta";
        }
    }
}
