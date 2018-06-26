using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace dotNetWCF
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IMathservice" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IMathservice
    {
        [OperationContract]
        Int32 Add(Int32 piNum1,Int32 piNum2);

        [OperationContract]
        Int32 Subtract(Int32 piNum1, Int32 piNum2);

        [OperationContract]
        Int32 Multiply(Int32 piNum1, Int32 piNum2);

        [OperationContract]
        Int32 Divide(Int32 piNum1, Int32 piNum2);
    }
}
