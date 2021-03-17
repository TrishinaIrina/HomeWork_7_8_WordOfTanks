using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLib.WordOfTanks
{
    
    public class Tank
    {
        private string Name { get; set; }
        private int Ammunition { get; set; }
        private int Armor { get; set; }
        private int Maneuverability { get; set; }

        Random rnd = new Random();
        public Tank(string Name)
        {
            this.Name = Name;
            Ammunition = rnd.Next(0, 100);
            Armor = rnd.Next(0, 100);
            Maneuverability = rnd.Next(0, 100);
        }

        public static bool operator *(Tank tank1, Tank tank2)
        {
            return (tank1.Ammunition > tank2.Ammunition && tank1.Armor > tank2.Armor ||
                tank1.Ammunition > tank2.Ammunition && tank1.Maneuverability > tank2.Maneuverability ||
                tank1.Armor > tank2.Armor && tank1.Maneuverability > tank2.Maneuverability);
        }

        public void GetParameters()
        {
            Console.WriteLine(Name + " Бое­комплект: " + Ammunition + " Уровень брони: " + Armor + " Уровень маневренности: " + Maneuverability);
        }
    }
}
