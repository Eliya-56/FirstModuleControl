using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleControl
{
    //описание города
    struct City
    {
        public string Name;
        public int Population;
        public int Area;
        public double Destiny;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the input data");
            string inputString = Console.ReadLine();

            //Узнать кол-во городов
            int cityNum = 0;
            for (int charCount = 0; charCount < inputString.Length; charCount++)
            {
                if (inputString[charCount] == '=')
                {
                    cityNum++;
                }
            }

            //Массив городов
            City[] cities = new City[cityNum];

            //Разбор строки
            string temp = "";
            for (int charCount = 0, cityCount = 0; charCount < inputString.Length; charCount++)
            {
                if (inputString[charCount] == '=')
                {
                    cities[cityCount].Name = temp;
                    string newTemp = "";
                    temp = newTemp;
                    charCount++;
                }
                if (inputString[charCount] == ',')
                {
                    cities[cityCount].Population = int.Parse(temp);
                    string newTemp = "";
                    temp = newTemp;
                    charCount++;
                }
                if ((inputString[charCount] == ';'))
                {
                    cities[cityCount].Area = int.Parse(temp);
                    string newTemp = "";
                    temp = newTemp;
                    cityCount++;
                    charCount++;
                }
                if(charCount == inputString.Length - 1)
                {
                    temp += inputString[charCount];
                    cities[cityCount].Area = int.Parse(temp);
                    break;
                }

                temp += inputString[charCount];
            }


            //Поиск нужный городов и нахождение плотности
            City MostPop = cities[0];
            City LongestName = cities[0];
            for (int cityCount = 0; cityCount < cities.Length; cityCount++)
            {
                cities[cityCount].Destiny = (double)cities[cityCount].Population / (double)cities[cityCount].Area;
                if(cities[cityCount].Population > MostPop.Population)
                {
                    MostPop = cities[cityCount];
                }
                if(cities[cityCount].Name.Length > LongestName.Name.Length)
                {
                    LongestName = cities[cityCount];
                }
            }

            //Вывод в нужном формате
            Console.WriteLine("Most populated:" + MostPop.Name + "(" + MostPop.Population + ")");
            Console.WriteLine("Longest Name:" + LongestName.Name + "(" + LongestName.Name.Length + " letters)");
            Console.WriteLine("Destiny:");
            for (int cityCount = 0; cityCount < cities.Length; cityCount++)
            {
                Console.WriteLine("      " + cities[cityCount].Name + " - " + Math.Round(cities[cityCount].Destiny,2));
            }
        }
    }
}
