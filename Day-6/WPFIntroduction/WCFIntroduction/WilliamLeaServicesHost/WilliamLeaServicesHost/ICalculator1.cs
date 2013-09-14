using System;
using System.ServiceModel;
namespace WilliamLeaServicesHost
{
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract(IsOneWay=true)]
        void Add(int number1, int number2);

        [OperationContract(IsOneWay = true)]
        void Subtract(int number1, int number2);
    }
}
