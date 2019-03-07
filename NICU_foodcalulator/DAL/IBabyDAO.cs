using NICU_foodcalculator.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace NICU_foodcalculator.DAL
{
    public interface IBabyDAO
    {
        IList<Baby> ViewListofInfants();
    }
}
