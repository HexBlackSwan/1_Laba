using System;

namespace FreightCompanyApp
{
    class FreightCompany
    {
        private string companyName;    
        private double ratePerTon;     
        private double cargoMass;     

        public FreightCompany()
        {
            companyName = "";
            ratePerTon = 0.0;
            cargoMass = 0.0;
        }

        public FreightCompany(string name, double rate, double mass)
        {
            companyName = name;
            ratePerTon = rate;
            cargoMass = mass;
        }


        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }

        public double RatePerTon
        {
            set
            {
                if (value >= 0)
                {
                    ratePerTon = value;
                }
                else
                {
                    Console.WriteLine("Ошибка: ставка не может быть отрицательной!");
                }
            }
        }

        public double CargoMass
        {
            set
            {
                if (value >= 0)
                {
                    cargoMass = value;
                }
                else
                {
                    Console.WriteLine("Ошибка: масса не может быть отрицательной!");
                }
            }
        }


        public double GetRatePerTon()
        {
            return ratePerTon;
        }

        public double GetCargoMass()
        {
            return cargoMass;
        }


        public double CalculateRevenue()
        {
            return ratePerTon * cargoMass;
        }

        public void PrintInfo()
        {
            Console.WriteLine("\n=== Информация о фирме ===");
            Console.WriteLine($"Фирма: {companyName}");
            Console.WriteLine($"Ставка за тонну: {ratePerTon:F2} у.е.");
            Console.WriteLine($"Масса перевезенных грузов: {cargoMass:F2} тонн");
            Console.WriteLine($"Общая выручка: {CalculateRevenue():F2} у.е.");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Программа фирмы грузоперевозок ===\n");

            try
            {
                string name;
                double rate;
                double mass;

                Console.Write("Введите название фирмы: ");
                name = Console.ReadLine();

                bool rateValid = false;
                rate = 0;
                while (!rateValid)
                {
                    Console.Write("Введите оплату за 1 тонну (у.е.): ");
                    string rateInput = Console.ReadLine();
                    if (double.TryParse(rateInput, out rate) && rate >= 0)
                    {
                        rateValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка! Введите корректное положительное число.");
                    }
                }

                bool massValid = false;
                mass = 0;
                while (!massValid)
                {
                    Console.Write("Введите массу перевезенных грузов (тонн): ");
                    string massInput = Console.ReadLine();
                    if (double.TryParse(massInput, out mass) && mass >= 0)
                    {
                        massValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка! Введите корректное положительное число.");
                    }
                }

                FreightCompany company = new FreightCompany();
                company.CompanyName = name;      
                company.RatePerTon = rate;      
                company.CargoMass = mass;          

                company.PrintInfo();

                Console.WriteLine("\n=== Демонстрация свойств только для записи ===");
                Console.WriteLine("Попытка изменить значения через свойства только для записи...");

                company.RatePerTon = 1200.50;
                company.CargoMass = 150.75;

                Console.WriteLine("Значения успешно обновлены!");
                Console.WriteLine("\nОбновленная информация:");
                company.PrintInfo();

                Console.WriteLine("\n=== Доступ к данным через методы ===");
                Console.WriteLine($"Доступ к ставке через метод GetRatePerTon(): {company.GetRatePerTon():F2} у.е.");
                Console.WriteLine($"Доступ к массе через метод GetCargoMass(): {company.GetCargoMass():F2} тонн");

                
                Console.WriteLine("\n=== Проверка валидации данных ===");
                Console.WriteLine("Попытка установить отрицательную ставку...");
                company.RatePerTon = -100;

                Console.WriteLine("Попытка установить отрицательную массу...");
                company.CargoMass = -50; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла непредвиденная ошибка: {ex.Message}");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}