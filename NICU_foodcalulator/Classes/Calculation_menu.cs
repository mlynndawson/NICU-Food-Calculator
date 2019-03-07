using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NICU_foodcalculator.Classes
{
    public class Calculation_menu
    {
        //public NICU_calculations();
        public void Run()
        {
            Console.WriteLine("NICU Nutrition Calculator!");
            Console.Write("Enter infant's name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Birth weight (kg): ");
            decimal birthWeight = decimal.Parse(Console.ReadLine());

            Console.Write("Today's Weight (kg): ");
            decimal todayWeight = decimal.Parse(Console.ReadLine());

            Console.Write("Food in-take by mouth (mL): ");
            decimal foodMouth = decimal.Parse(Console.ReadLine());
            Console.Write("Cal/oz intake by mouth: ");
            decimal calOzMouth = decimal.Parse(Console.ReadLine());

            Console.Write("Food in-take by tube (mL): ");
            decimal foodTube = decimal.Parse(Console.ReadLine());
            Console.Write("Cal/oz intake by tube: ");
            decimal calOzTube = decimal.Parse(Console.ReadLine());

            Console.Write("Food in-take by IV (mL): ");
            decimal foodIV = decimal.Parse(Console.ReadLine());
            Console.Write("TPN Cal/kg: ");
            decimal calKgIV = decimal.Parse(Console.ReadLine()); //TODO make similar as other forms of feeding

            Console.WriteLine("================================================");


            decimal changeInWeight = (todayWeight - birthWeight) / birthWeight;
            Console.WriteLine($"Change in weight {changeInWeight:P}");

            decimal totalFoodIntake = foodMouth + foodTube + foodIV;
            Console.WriteLine($"Total intake (mL): {totalFoodIntake}mL");

            decimal totalIntakeMLKG = 0;
            decimal calKgMouth = 0;
            decimal calKgTube = 0;
            decimal totalCalKg = 0;

            if (birthWeight > todayWeight)
            {
                totalIntakeMLKG = totalFoodIntake / birthWeight;
                Console.WriteLine($"Total intake (mL/kg): {totalIntakeMLKG:N1}mL/kg");

                calKgMouth = (calOzMouth / 30) * (foodMouth / birthWeight);
                calKgTube = (calOzTube / 30) * (foodTube / birthWeight);
                totalCalKg = calKgMouth + calKgTube + calKgIV;
                Console.WriteLine($"Total cal/kg: {totalCalKg:N2} cal/kg");

                if (totalCalKg < 110)
                {
                    decimal deficitCalKg = 0;
                    decimal deficitMlMouth = 0;
                    decimal deficitMlTube = 0;

                    deficitCalKg = 110 - totalCalKg;
                    deficitMlMouth = ((deficitCalKg * birthWeight) / calOzMouth) * 30;
                    deficitMlTube = ((deficitCalKg * birthWeight) / calOzTube) * 30;


                    Console.WriteLine($"Increase total intake by mouth by {deficitMlMouth:N2}mL or tube by {deficitMlTube:N2}mL");

                }
            }
            else if (todayWeight > birthWeight)
            {
                totalIntakeMLKG = totalFoodIntake / todayWeight;
                Console.WriteLine($"Total intake (mL/kg): {totalIntakeMLKG:N1}mL/kg");

                calKgMouth = (calOzMouth / 30) * (foodMouth / todayWeight);
                calKgTube = (calOzTube / 30) * (foodTube / todayWeight);
                totalCalKg = calKgMouth + calKgTube + calKgIV;
                Console.WriteLine($"Total cal/kg: {totalCalKg:N2} cal/kg");

                if (totalCalKg < 110)
                {

                    decimal deficitCalKg = 0;
                    decimal deficitMlMouth = 0;
                    decimal deficitMlTube = 0;

                    deficitCalKg = 110 - totalCalKg;
                    deficitMlMouth = ((deficitCalKg * todayWeight) / calOzMouth) * 30;
                    deficitMlTube = ((deficitCalKg * todayWeight) / calOzTube) * 30;

                    Console.WriteLine($"Increase total intake by mouth by {deficitMlMouth:N2}mL");

                }
            }
        }
    }
}
