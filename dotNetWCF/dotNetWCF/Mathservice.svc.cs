using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace dotNetWCF
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Mathservice" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Mathservice.svc ou Mathservice.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Mathservice : IMathservice
    {
        public Int32 Add(Int32 piNum1, Int32 piNum2)
        {
            return piNum1 + piNum2;
        }

       public Int32 Subtract(Int32 piNum1, Int32 piNum2)
        {
            return piNum1 - piNum2;
        }

        public Int32 Multiply(Int32 piNum1, Int32 piNum2)
        {
            return piNum1 * piNum2;
        }

        public Int32 Divide(Int32 piNum1, Int32 piNum2)
        {
            return piNum1 / piNum2;
        }

    }
}
