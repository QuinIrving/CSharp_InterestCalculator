using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace InterestCalculator
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "InterestCalculations" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select InterestCalculations.svc or InterestCalculations.svc.cs at the Solution Explorer and start debugging.
    public class InterestCalculations : IInterestCalculations
    {
        public decimal CompoundInterest(decimal _principal, decimal _rate, float _time, int _n)
        {
            double theBase = (double)(1 + _rate / ((decimal)_n));
            double thePower = (double)(_n * _time);
            return _principal * ((decimal)(Math.Pow(theBase, thePower)));
        }
        public decimal PeriodicCompoundInterest(decimal _principal, decimal _rate, float _time)
        {
            double theBase = (double)(1 + _rate);
            return _principal * ((decimal)Math.Pow(theBase, (double)_time));
        }

        public decimal SimpleInterest(decimal _principal, decimal _rate, float _time)
        {
            return _principal * _rate * ((decimal)_time);
        }

        public decimal SimplePlusPrincipalInterest(decimal _principal, decimal _rate, float _time)
        {
            return _principal * (1 + _rate * ((decimal)_time));
        }

        public AllInterest CalculateAll(decimal _principal, decimal _rate, float _time, int _n)
        {
            AllInterest retVal = new AllInterest();

            retVal.SimpleInterestValue = _principal * _rate * ((decimal)_time);

            retVal.SimplePlusPrincipalInterestValue = _principal * (1 + _rate * ((decimal)_time));

            double compoundBase = (double)(1 + _rate / ((decimal)_n));
            double compoundPower = (double)(_n * _time);
            retVal.CompoundInterestValue = _principal * ((decimal)(Math.Pow(compoundBase, compoundPower)));

            double periodicBase = (double)(1 + _rate);
            retVal.PeriodicCompoundInterestValue = _principal * ((decimal)Math.Pow(periodicBase, (double)_time));

            return retVal;
        }

    }
}
