using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLib.WordOfTanks;

namespace Day7_Tanks_
{
    /*Разработать программу, моделирующую танковый бой. 
    В танковом бою участвуют 5 танков «Т-34» и 5 танков «Pantera». 
    Каждый танк («Т-34» и «Pantera») описываются параметрами: «Боекомплект», «Уровень брони», 
    «Уровень маневренности». Значение данных параметров задаются случайными числами от 0 до 100. 
    Каждый танк участвует в парной битве, т.е. первый танк «Т-34» сражается с первым танком 
    «Pantera» и т. д. Победа присуждается тому танку, который превышает противника по двум и более 
    параметрам из трех (пример: см. программу). Основное требование: сражение (проверку на победу в бою) 
    реализовать путем перегрузки оператора «*» (произведение).*/
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Укажите наименование танка первой армии");
                List<Tank> army1 = InitArmy(Console.ReadLine());

                Console.WriteLine("Укажите наименование танка второй армии");
                List<Tank> army2 = InitArmy(Console.ReadLine());

                Console.WriteLine("Базовые характеристики первой армии: ");
                for (int i = 0; i < 5; i++)
                {
                    army1[i].GetParameters();
                }

                Console.WriteLine("*************************************");

                Console.WriteLine("Базовые характеристики второй армии: ");
                for (int i = 0; i < 5; i++)
                {
                    army2[i].GetParameters();
                }

                Console.WriteLine();
                int count = 0;
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine((i + 1) + " бой: ");
                    if (army1[i] * army2[i])
                    {
                        count++;
                        Console.WriteLine("Победил танк первой армии");
                    }
                    else Console.WriteLine("Победил танк второй армии");
                }

                Console.WriteLine();
                if (count > 2) Console.WriteLine("В сражении победила первая армия");
                else Console.WriteLine("В сражении победила вторая армия");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public static List<Tank> InitArmy(string name)
        {
            if (name == "T-34" || name == "Pantera")
            {
                List<Tank> army = new List<Tank>();
                for (int i = 0; i < 5; i++)
                {
                    Tank tank = new Tank(name);
                    army.Add(tank);
                    System.Threading.Thread.Sleep(1); // для того чтобы Random успел выдать разные числа
                }
                return army;
            }
            else
                throw new Exception("Указан не существующий вид танка");
        }

    }
}
