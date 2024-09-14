using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace InterestCalculator
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IInterestCalculations" in both code and config file together.
    [ServiceContract]
    public interface IInterestCalculations
    {
        [OperationContract]
        decimal SimpleInterest(decimal _principal, decimal _rate, float _time);

        [OperationContract]
        decimal SimplePlusPrincipalInterest(decimal _principal, decimal _rate, float _time);

        [OperationContract]
        decimal CompoundInterest(decimal _principal, decimal _rate, float _time, int _n);

        [OperationContract]
        decimal PeriodicCompoundInterest(decimal _principal, decimal _rate, float _time);

        [OperationContract]
        AllInterest CalculateAll(decimal _principal, decimal _rate, float _time, int _n);
    }

    [DataContract]
    public class AllInterest
    {
        // private int x = 4;
        private decimal simpleInterestValue;
        private decimal simplePlusPrincipalInterestValue;
        private decimal compoundInterestValue;
        private decimal periodicCompoundInterestValue;

        [DataMember]
        public decimal SimpleInterestValue
        {
            get { return simpleInterestValue; }
            set { simpleInterestValue = value; }
        }

        [DataMember]
        public decimal SimplePlusPrincipalInterestValue
        {
            get { return simplePlusPrincipalInterestValue; }
            set { simplePlusPrincipalInterestValue = value; }
        }

        [DataMember]
        public decimal CompoundInterestValue
        {
            get { return compoundInterestValue; }
            set { compoundInterestValue = value; }
        }

        [DataMember]
        public decimal PeriodicCompoundInterestValue
        {
            get { return periodicCompoundInterestValue; }
            set { periodicCompoundInterestValue = value; }
        }
    }

   
}
