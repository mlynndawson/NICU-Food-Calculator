using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NICU_foodcalculator.Models;
using System.Linq;
using NICU_foodcalculator.DAL;

namespace NICU_foodcalculator.Classes
{
    public class Main_menu
    {
        private IBabyDAO babyDAO;

        public Main_menu(IBabyDAO babyDAO)
        {
            this.babyDAO = babyDAO;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("NICU Nutrition Calculator!");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Main-Menu Type in a command");
                Console.WriteLine(" 1 - View list of infant data");
                Console.WriteLine(" 2 - Add a child to database");
                Console.WriteLine(" 3 - Update current data of a child");
                Console.WriteLine(" Q - Quit");

                string command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case ("1"):
                        ViewListofInfants();
                        break;

                    case ("2"):
                        Console.Clear();
                        Calculation_menu calc = new Calculation_menu();
                        calc.Run();
                        break;

                    case ("3"):
                        break;

                    case ("q"):
                        return;

                    default:
                        Console.WriteLine("Invalid entry. Please try again.");
                        break;
                }
            }
        }

        private void ViewListofInfants()
        {
            IList<Baby> babies = babyDAO.ViewListofInfants();

            foreach (Baby baby in babies)
            {
                Console.WriteLine($"{baby.BabyId.ToString()} ===== {baby.LastName} , {baby.FirstName}");
            }

        }
    }

}
