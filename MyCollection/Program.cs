using LibraryClass;
namespace MyCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyCollection<BankCard> collection = new MyCollection<BankCard>();
            BankCard card1 = new BankCard();
            card1.RandomInit();
            collection.Add(card1);
            BankCard card2 = new BankCard();
            card2.RandomInit();
            collection.Add(card2);

            //Вывод оригинальной коллекции
            Console.WriteLine("Оригинальная коллекция:");
            collection.PrintCollection();

            //Перебор коллекции с использованием foreach
            Console.WriteLine("\nПеребор оригинальной коллекции:");
            foreach (BankCard card in collection)
            {
                Console.WriteLine(card);
            }

            //Глубокое копирование
            MyCollection<BankCard> deepCopy = collection.DeepClone();

            // Поверхностное копирование
            MyCollection<BankCard> shallowCopy = collection.ShallowCopy();

            // Добавление нового элемента в оригинальную коллекцию
            BankCard cardAdd = new BankCard();
            cardAdd.RandomInit();
            collection.Add(cardAdd);

            //Вывод измененной оригинальной коллекции
            Console.WriteLine("\nОригинальная коллекция после добавления нового элемента:");
            collection.PrintCollection();

            //Вывод глубокой копии(не должен включать новый элемент)
            Console.WriteLine("\nГлубокая копия (не должна включать новый элемент):");
            deepCopy.PrintCollection();

            //Вывод поверхностной копии(должна включать новый элемент)
            Console.WriteLine("\nПоверхностная копия (должна включать новый элемент):");
            shallowCopy.PrintCollection();

            //Проверка метода Contains
            BankCard cardToCheck = new BankCard();
            cardToCheck.Init();
            bool containsCard = collection.Contains(cardToCheck);
            if (containsCard)
            {
                Console.WriteLine($"\nОригинальная коллекция содержит карту {cardToCheck}");
            }
            else
            {
                Console.WriteLine("Карта не найдена в коллекции.");
            }

            //Удаление элемента
            Console.WriteLine("\nУдаление карты:");
            BankCard cardToDelete = new BankCard();
            cardToDelete.Init();
            bool removed = collection.Remove(cardToDelete);
            if (removed)
            {
                Console.WriteLine("Карта успешно удалена.");
            }
            else
            {
                Console.WriteLine("Карта не найдена для удаления.");
            }

            //Перебор коллекции после изменений с использованием foreach
            Console.WriteLine("\nПеребор измененной коллекции:");
            foreach (BankCard card in collection)
            {
                Console.WriteLine(card);
            }
        }
    }
}