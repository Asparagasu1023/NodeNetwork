using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeNetwork.Views
{
    public sealed class NNViewRegistrar
    {
        //Locatorが登録される前でも登録可能
        private static readonly List<Tuple<Func<object>, Type>> PendingRegistrations = new List<Tuple<Func<object>, Type>>();

        private static Action<Func<object>, Type> _registerAction;

        public static void AddRegistration(Func<object> factory, Type serviceType)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }
            else if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (_registerAction == null)
            {
                PendingRegistrations.Add(Tuple.Create(factory, serviceType));
            }
            else
            {
                _registerAction(factory, serviceType);
            }
        }

        private static void RegisterToLocator(Action<Func<object>, Type> newRegisterAction)
        {
            if (newRegisterAction == null)
            {
                throw new ArgumentNullException(nameof(newRegisterAction));
            }
            else if (_registerAction != null)
            {
                throw new InvalidOperationException("A locator has already been set");
            }

            //Locatorの登録
            _registerAction = newRegisterAction;
            
            //Pending組を追加
            foreach (var t in PendingRegistrations)
            {
                _registerAction(t.Item1, t.Item2);
            }

            PendingRegistrations.Clear();
        }
        /// <summary>
        /// Register all NodeNetwork view/viewmodel pairs to Locator.CurrentMutable.
        /// </summary>
        public static void RegisterSplat()
        {
            RegisterToLocator((f, t) => Locator.CurrentMutable.Register(f, t));
        }



    }
}
