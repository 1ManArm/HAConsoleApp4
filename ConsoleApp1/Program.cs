using System.ComponentModel;

namespace ConsoleApp1
{
    internal class Program
    {
        public class Money
        {
            public int dollars;
            public int cents;

            public Money(int dollars, int cents)
            {
                this.dollars = dollars; this.cents = cents;
            }

            public void DisplayAmount()
            {
                Console.WriteLine($"Сумма:{dollars} долларов, {cents} центов");
            }

            public void SetAmount(int dollars, int cents)
            {
                this.dollars = dollars; this.cents = cents;
            }
        }
        public class Product
        {
            private string name;
            private Money price;

            public Product(string name, int dollars, int cents) 
            {
                this.name = name;
                this.price = new Money(dollars, cents);
            }

            public void ReducePrice(int amount)
            {
                int totalCents = price.dollars * 100 + price.cents;
                totalCents -= amount;

                if (totalCents < 0)
                {
                    Console.WriteLine("Некорректное значение: цена не может быть отрицательной");
                    return;
                }

                int dollars = totalCents / 100;
                int cents = totalCents % 100;

                price.SetAmount(dollars, cents);
            }

            public void DisplayProduct()
            {
                Console.WriteLine($"Наименование: {name}");
                price.DisplayAmount();
            }
        }

        class Device
        {
            protected string name;

            public Device(string deviceName)
            {
                name = deviceName;
            }

            public virtual void Sound()
            {
                Console.WriteLine("Звук устройства");
            }

            public void Show()
            {
                Console.WriteLine($"Название устройства: {name}");
            }

            public virtual void Desc() 
            {
                Console.WriteLine("Описание устройства");
            }
        }

        class Kettle : Device
        {
            public Kettle(string deviceName):base(deviceName) { }
            public override void Sound()
            {
                Console.WriteLine("Звук чайника");
            }
            public override void Desc()
            {
                Console.WriteLine("Описание чайника");
            }
        }
        class Microwave : Device
        {
            public Microwave(string deviceName) : base(deviceName) { }
            public override void Sound()
            {
                Console.WriteLine("Звук микроволновки");
            }
            public override void Desc()
            {
                Console.WriteLine("Описание микроволновки");
            }
        }
        class Car : Device
        {
            public Car(string deviceName) : base(deviceName) { }
            public override void Sound()
            {
                Console.WriteLine("Звук автомобиля");
            }
            public override void Desc()
            {
                Console.WriteLine("Описание автомобиля");
            }
        }
        class Steamship : Device
        {
            public Steamship(string deviceName) : base(deviceName) { }
            public override void Sound()
            {
                Console.WriteLine("Звук парохода");
            }
            public override void Desc()
            {
                Console.WriteLine("Описание парохода");
            }
        }

        class CreditCard
        {
            private decimal balance; //НЕ ЗАБЫТЬ СПРОСИТЬ ПРО DECIMAL!!!

            public CreditCard(decimal initBalance)
            {
                balance = initBalance;
            }

            public void IncreaseBalance(decimal amount) //если это убрать и содержимое переместить в перегрузку, выскочит ошибка
            {
                balance += amount;
                Console.WriteLine(balance);
            }

            public void DecreaseBalance(decimal amount) //если это убрать и содержимое переместить в перегрузку, выскочит ошибка
            {
                if (amount > balance)
                {
                    throw new InvalidOperationException("Недостаточно средств на карте.");
                }

                balance -= amount;
                Console.WriteLine(balance);
            }
            public static CreditCard operator +(CreditCard card, decimal amount)
            {
                card.IncreaseBalance(amount);
                return card;
            }

            public static CreditCard operator -(CreditCard card, decimal amount)
            {
                card.DecreaseBalance(amount);
                return card;
            }

            public static bool operator ==(CreditCard card, int cvc)
            {
                return card.CheckCVC(cvc);
            }

            public static bool operator !=(CreditCard card, int cvc)
            {
                return !card.CheckCVC(cvc);
            }

            public static bool operator <(CreditCard card, decimal amount)
            {
                return card.balance < amount;
            }

            public static bool operator >(CreditCard card, decimal amount)
            {
                return card.balance > amount;
            }

            public bool CheckCVC(int cvc)
            {
                throw new NotImplementedException();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1");
            Console.WriteLine();
            Money money = new Money(10, 50);
            money.DisplayAmount();

            Product product = new Product("Черешня", 5, 99);
            product.DisplayProduct();
            product.ReducePrice(2);
            product.DisplayProduct();
            
            Console.WriteLine();

            Console.WriteLine("Задание 2");
            Console.WriteLine();

            Device kettle = new Kettle("Электрический чайник");
            Device microwave = new Microwave("Микроволновая печь");
            Device car = new Car("Седан");
            Device steamship = new Steamship("Пароход");

            kettle.Show();
            kettle.Sound();
            kettle.Desc();

            Console.WriteLine();

            microwave.Show();
            microwave.Sound();
            microwave.Desc();

            Console.WriteLine();

            car.Show();
            car.Sound();
            car.Desc();

            Console.WriteLine();

            steamship.Show();
            steamship.Sound();
            steamship.Desc();

            Console.WriteLine();

            Console.WriteLine("Задание 3");
            Console.WriteLine();

            CreditCard card1 = new CreditCard(80000);
            card1.IncreaseBalance(20000);
            card1.DecreaseBalance(20000);
            card1.CheckCVC(19); //unhandled exception. Не знаю, как исправить.
        }
    }
}