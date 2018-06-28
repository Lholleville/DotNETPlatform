using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CalculationEngine
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "CalculationEngine" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez CalculationEngine.svc ou CalculationEngine.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class CalculationEngine : ICalculationEngine
    {

        public double Averager(double[] MyTable)
        {
            double MyResult = MyTable.Average();
            return MyResult;
        }
    }
}
