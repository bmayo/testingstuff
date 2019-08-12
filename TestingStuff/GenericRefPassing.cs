using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TestingStuff
{
    /// <summary>
    /// The idea behind this class is to test the functionality of pre established ref passing methods 
    /// and extending functionality of new classes with generic and interface bases.
    /// </summary>
    public class GenericRefPassing
    {
        public int AClassWithAReponseRefToCallAMethod()
        {
            var a = new AClass<GenericClassA>();
            var gen = new GenericClassA(); //data would normally be populated elsewhere but for testing and example is done here
            a.SetReponse(gen);
            RefMethod(ref a);
           
            var aMoop = a.boop();
            return aMoop;
        }

        public int BClassWithBReponseRefToCallAMethod()
        {
            var b = new BClass<GenericClassB>();
            var gen = new GenericClassB();
            b.SetReponse(gen);
            RefMethod(ref b);

            var bMoop = b.boop();
            return bMoop;
        }

        public int AClassWithBReponseRefToCallAMethod()
        {
            var a = new AClass<GenericClassB>();
            var gen = new GenericClassB();
            a.SetReponse(gen);
            RefMethod(ref a);

            var aMoop = a.boop();
            return aMoop;
        }

        public int BClassWithAReponseRefToCallAMethod()
        {
            var b = new BClass<GenericClassA>();
            var gen = new GenericClassA();
            b.SetReponse(gen);
            RefMethod(ref b);

            var aMoop = b.boop();
            return aMoop;
        }

        public int AClassWithGenericReponseRefToCallAMethod<response>() where response : IGenericInterface
        {

            var a = new AClass<response>();
            var gen = (response)Activator.CreateInstance(typeof(response));
            a.SetReponse(gen);
            RefMethod(ref a);

            var aMoop = a.boop();
            return aMoop;
        }

        public int BClassWithGenericReponseRefToCallAMethod<response>() where response : IGenericInterface
        {

            var b = new BClass<response>();
            var gen = (response)Activator.CreateInstance(typeof(response));
            b.SetReponse(gen);
            RefMethod(ref b);

            var aMoop = b.boop();
            return aMoop;
        }

        public int AnyClassReponseRefToCallAMethod<reponseClass, response>() where reponseClass : IBaseInterface<response> where response : IGenericInterface
        {
            IBaseInterface<response> genReponse = (reponseClass)Activator.CreateInstance(typeof(reponseClass));            
            var gen = (response)Activator.CreateInstance(typeof(response));
            genReponse.SetReponse(gen);
            RefMethod(ref genReponse);

            var genMoop = genReponse.boop();
            return genMoop;
        }

        private void RefMethod<reponse>(ref AClass<reponse> r) where reponse : IGenericInterface
        {

            IBaseInterface<reponse> i = r;
            var result = Object.ReferenceEquals(i, r);
            if (!result)
                throw new Exception("Ref not equal");
            RefMethod(ref i);
        }

        private void RefMethod<reponse>(ref BClass<reponse> r) where reponse : IGenericInterface
        {

            IBaseInterface<reponse> i = r;
            var result = Object.ReferenceEquals(i, r);
            if (!result)
                throw new Exception("Ref not equal");
            RefMethod(ref i);
        }

        private void RefMethod<reponse>(ref IBaseInterface<reponse> i) where reponse : IGenericInterface
        {

        }
    }

    public interface IGenericInterface 
    {
        int moop();
    }

    public class GenericClassA : IGenericInterface
    {
        public int moop()
        {
            return 1;
        }
    }

    public class GenericClassB : IGenericInterface
    {
        public int moop()
        {
            return 2;
        }
    }

    public interface IBaseInterface<response> where response : IGenericInterface
    {
        int boop();

        void SetReponse(response data);
    }

    public abstract class BaseClass<response> : IBaseInterface<response> where response : IGenericInterface
    {
        private response _data;

        public BaseClass(){

        }

        public void SetReponse(response data)
        {
            _data = data;
        }

        public virtual int boop()
        {
            return _data.moop();
        }
    }

    public class AClass<response> : BaseClass<response> where response : IGenericInterface
    {

    }

    public class BClass<response> : BaseClass<response> where response : IGenericInterface
    {
        public override int boop()
        {
            return base.boop() + 1;
        }
    }
}
