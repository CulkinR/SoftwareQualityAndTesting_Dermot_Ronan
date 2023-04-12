using System.Security.Claims;

namespace REProject
{

    public class InsuranceService
    {
        private readonly DiscountService _discountService;

        public InsuranceService(DiscountService discountService)
        {
            _discountService = discountService;
        }

        public double CalculatePremium(int age, string location)
        {
            double premium = 0.0;

            if (location == "rural")
            {
                if (age >= 18 && age < 30)
                {
                    premium = 5.0;
                }
                else if (age >= 31)
                {
                    premium = 2.50;
                }
            }
            else if (location == "urban")
            {
                if (age >= 18 && age <= 35)
                {
                    premium = 6.0;
                }
                else if (age >= 36)
                {
                    premium = 5.0;
                }
            }

            double discount = _discountService.GetDiscount();
            if (age >= 50)
            {
                premium *= discount;
            }
            premium = Math.Round(premium, 1);
            return premium;
        }
    }

    public class DiscountService
    {
        public virtual double GetDiscount()
        {
            return 0;
        }
    }

}