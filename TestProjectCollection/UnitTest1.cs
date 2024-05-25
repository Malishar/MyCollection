using LibraryClass;
using MyCollection;
namespace TestProjectCollection
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Add_AddsItemToCollection()
        {
            // Arrange
            MyCollection<BankCard> collection = new MyCollection<BankCard>();
            BankCard card = new BankCard();

            // Act
            collection.Add(card);

            // Assert
            Assert.IsTrue(collection.Contains(card));
        }

        [TestMethod]
        public void Count_ReturnsCorrectNumberOfItems()
        {
            // Arrange
            MyCollection<BankCard> collection = new MyCollection<BankCard>();
            BankCard card1 = new BankCard();
            BankCard card2 = new BankCard();
            BankCard card3 = new BankCard();

            // Act
            collection.Add(card1);
            collection.Add(card2);
            collection.Add(card3);

            // Assert
            Assert.AreEqual(2, collection.Count);
        }

        [TestMethod]
        public void IsReadOnly_ReturnsFalse()
        {
            // Arrange
            MyCollection<BankCard> collection = new MyCollection<BankCard>();

            // Assert
            Assert.IsFalse(collection.IsReadOnly);
        }

        [TestMethod]
        public void Clear_RemovesAllItemsFromCollection()
        {
            // Arrange
            MyCollection<BankCard> collection = new MyCollection<BankCard>();
            BankCard card1 = new BankCard();
            BankCard card2 = new BankCard();
            collection.Add(card1);
            collection.Add(card2);

            // Act
            collection.Clear();

            // Assert
            Assert.AreEqual(0, collection.Count);
            Assert.IsFalse(collection.Contains(card1));
            Assert.IsFalse(collection.Contains(card2));
        }

        [TestMethod]
        public void Contains_ReturnsTrueIfItemExists()
        {
            // Arrange
            MyCollection<BankCard> collection = new MyCollection<BankCard>();
            BankCard card = new BankCard();
            collection.Add(card);

            // Act
            bool containsItem = collection.Contains(card);

            // Assert
            Assert.IsTrue(containsItem);
        }

        [TestMethod]
        public void Contains_ReturnsFalseIfItemDoesNotExist()
        {
            // Arrange
            MyCollection<BankCard> collection = new MyCollection<BankCard>();
            BankCard card = new BankCard();

            // Act
            bool containsItem = collection.Contains(card);

            // Assert
            Assert.IsFalse(containsItem);
        }

        [TestMethod]
        public void CopyTo_CopiesItemsToProvidedArray()
        {
            // Arrange
            MyCollection<BankCard> collection = new MyCollection<BankCard>();
            BankCard card1 = new BankCard();
            BankCard card2 = new BankCard();
            collection.Add(card1);
            collection.Add(card2);
            BankCard[] array = new BankCard[2];

            // Act
            collection.CopyTo(array, 0);

            // Assert
            Assert.AreEqual(card1, array[0]);
            Assert.AreEqual(card2, array[1]);
        }

        [TestMethod]
        public void Remove_RemovesItemFromCollection()
        {
            // Arrange
            MyCollection<BankCard> collection = new MyCollection<BankCard>();
            BankCard card = new BankCard();
            collection.Add(card);

            // Act
            bool removed = collection.Remove(card);

            // Assert
            Assert.IsTrue(removed);
            Assert.IsFalse(collection.Contains(card));
        }

        [TestMethod]
        public void GetEnumerator_ReturnsCorrectEnumerator()
        {
            // Arrange
            MyCollection<BankCard> collection = new MyCollection<BankCard>();
            BankCard card1 = new BankCard();
            BankCard card2 = new BankCard();
            collection.Add(card1);
            collection.Add(card2);

            // Act
            var enumerator = collection.GetEnumerator();

            // Assert
            int count = 0;
            while (enumerator.MoveNext())
            {
                count++;
            }
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void DeepClone_CreatesDeepClone()
        {
            // Arrange
            MyCollection<BankCard> original = new MyCollection<BankCard>();
            BankCard card1 = new BankCard();
            BankCard card2 = new BankCard();
            original.Add(card1);
            original.Add(card2);

            // Act
            MyCollection<BankCard> clone = original.DeepClone();

            // Assert
            Assert.AreEqual(original.Count, clone.Count);
            foreach (var item in original)
            {
                Assert.IsTrue(clone.Contains(item));
            }
        }

        [TestMethod]
        public void ShallowCopy_CreatesShallowCopy()
        {
            // Arrange
            MyCollection<BankCard> original = new MyCollection<BankCard>();
            BankCard card1 = new BankCard();
            BankCard card2 = new BankCard();
            original.Add(card1);
            original.Add(card2);

            // Act
            MyCollection<BankCard> copy = original.ShallowCopy();

            // Assert
            Assert.AreEqual(original.Count, copy.Count);
            foreach (var item in original)
            {
                Assert.IsTrue(copy.Contains(item));
            }
        }

        [TestMethod]
        public void Constructor_WithCapacity_CreatesCollectionWithSpecifiedCapacity()
        {
            // Arrange
            int capacity = 5;

            // Act
            MyCollection<BankCard> collection = new MyCollection<BankCard>(capacity);

            // Assert
            Assert.AreEqual(0, collection.Count);
        }

        [TestMethod]
        public void Constructor_WithCollection_CreatesCollectionWithSameItems()
        {
            // Arrange
            MyCollection<BankCard> original = new MyCollection<BankCard>();
            BankCard card1 = new BankCard();
            BankCard card2 = new BankCard();
            original.Add(card1);
            original.Add(card2);

            // Act
            MyCollection<BankCard> collection = new MyCollection<BankCard>(original);

            // Assert
            Assert.AreEqual(original.Count, collection.Count);
            foreach (var item in original)
            {
                Assert.IsTrue(collection.Contains(item));
            }
        }


        [TestMethod]
        public void AddPoint_AddsDataToHashTable()
        {
            // Arrange
            MyHashTable<BankCard> hashTable = new MyHashTable<BankCard>();
            BankCard card = new BankCard("1234567890", "John Doe", 123, 456);

            // Act
            hashTable.AddPoint(card);

            // Assert
            Assert.IsTrue(hashTable.Contains(card));
        }

        [TestMethod]
        public void Contains_ReturnsTrueIfDataExists()
        {
            // Arrange
            MyHashTable<BankCard> hashTable = new MyHashTable<BankCard>();
            BankCard card = new BankCard("1234567890", "John Doe", 123, 456);
            hashTable.AddPoint(card);

            // Act
            bool containsData = hashTable.Contains(card);

            // Assert
            Assert.IsTrue(containsData);
        }

        [TestMethod]
        public void Contains_ReturnsFalseIfDataDoesNotExist()
        {
            // Arrange
            MyHashTable<BankCard> hashTable = new MyHashTable<BankCard>();

            // Act
            bool containsData = hashTable.Contains(new BankCard("0987654321", "Jane Doe", 789, 321));

            // Assert
            Assert.IsFalse(containsData);
        }

        [TestMethod]
        public void RemoveData_RemovesExistingData()
        {
            // Arrange
            MyHashTable<BankCard> hashTable = new MyHashTable<BankCard>();
            BankCard card1 = new BankCard("1234567890", "John Doe", 123, 456);
            BankCard card2 = new BankCard("0987654321", "Jane Doe", 789, 321);
            hashTable.AddPoint(card1);
            hashTable.AddPoint(card2);

            // Act
            bool removed = hashTable.RemoveData(card1);

            // Assert
            Assert.IsTrue(removed);
            Assert.IsFalse(hashTable.Contains(card1));
        }

        [TestMethod]
        public void RemoveData_ReturnsFalseForNonExistingData()
        {
            // Arrange
            MyHashTable<BankCard> hashTable = new MyHashTable<BankCard>();
            BankCard card = new BankCard("1234567890", "John Doe", 123, 456);
            hashTable.AddPoint(card);

            // Act
            bool removed = hashTable.RemoveData(new BankCard("0987654321", "Jane Doe", 789, 321));

            // Assert
            Assert.IsFalse(removed);
        }

        [TestMethod]
        public void RemoveData_RemovesDataWithMultipleItemsInTheSameSlot()
        {
            // Arrange
            MyHashTable<BankCard> hashTable = new MyHashTable<BankCard>();
            BankCard card1 = new BankCard("1234567890", "John Doe", 123, 456);
            BankCard card2 = new BankCard("0987654321", "Jane Doe", 789, 321);
            BankCard card3 = new BankCard("1357924680", "Bob Smith", 111, 222);
            hashTable.AddPoint(card1);
            hashTable.AddPoint(card2);
            hashTable.AddPoint(card3);

            // Act
            bool removed = hashTable.RemoveData(card2);

            // Assert
            Assert.IsTrue(removed);
            Assert.IsFalse(hashTable.Contains(card2));
            Assert.IsTrue(hashTable.Contains(card1));
            Assert.IsTrue(hashTable.Contains(card3));
        }

        [TestMethod]
        public void Constructor_Parameterized()
        {
            // Arrange
            int data = 10;

            // Act
            Point<int> point = new Point<int>(data);

            // Assert
            Assert.AreEqual(data, point.Data);
            Assert.IsNull(point.Next);
            Assert.IsNull(point.Pred);
        }

        [TestMethod]
        public void ToString_Returns()
        {
            // Arrange
            int data = 10;
            Point<int> point = new Point<int>(data);

            // Act
            string result = point.ToString();

            // Assert
            Assert.AreEqual(data.ToString(), result);
        }

        [TestMethod]
        public void GetHashCode_ReturnsData()
        {
            // Arrange
            int data = 10;
            Point<int> point = new Point<int>(data);

            // Act
            int hashCode = point.GetHashCode();

            // Assert
            Assert.AreEqual(data.GetHashCode(), hashCode);
        }

        [TestMethod]
        public void NextProperty_Setter_SetsNextCorrectly()
        {
            // Arrange
            Point<int> point1 = new Point<int>();
            Point<int> point2 = new Point<int>();

            // Act
            point1.Next = point2;

            // Assert
            Assert.AreEqual(point2, point1.Next);
        }

        [TestMethod]
        public void PredProperty_Setter_SetsPredCorrectly()
        {
            // Arrange
            Point<int> point1 = new Point<int>();
            Point<int> point2 = new Point<int>();

            // Act
            point1.Pred = point2;

            // Assert
            Assert.AreEqual(point2, point1.Pred);
        }

        [TestMethod]
        public void GetIndex_DistributesIndicesCorrectly()
        {
            // Arrange
            MyHashTable<BankCard> hashTable = new MyHashTable<BankCard>(10);
            BankCard bankCard1 = new BankCard { Number = "123456789", Owner = "John Doe", Date = 2023 };
            BankCard bankCard2 = new BankCard { Number = "987654321", Owner = "Jane Smith", Date = 2023 };
            BankCard bankCard3 = new BankCard { Number = "555555555", Owner = "Jack Johnson", Date = 2023 };

            // Act
            int index1 = hashTable.GetIndex(bankCard1);
            int index2 = hashTable.GetIndex(bankCard2);
            int index3 = hashTable.GetIndex(bankCard3);

            // Assert
            Assert.IsTrue(index1 >= 0 && index1 < hashTable.Capacity, "Index1 is out of range.");
            Assert.IsTrue(index2 >= 0 && index2 < hashTable.Capacity, "Index2 is out of range.");
            Assert.IsTrue(index3 >= 0 && index3 < hashTable.Capacity, "Index3 is out of range.");
        }

        [TestMethod]
        public void AddMultipleElements_WithSameHashCode_AddsToSameBucket()
        {
            // Arrange
            MyHashTable<BankCard> hashTable = new MyHashTable<BankCard>(1); // Force all elements to same bucket
            BankCard bankCard1 = new BankCard { Number = "111", Owner = "Alice", Date = 2023 };
            BankCard bankCard2 = new BankCard { Number = "222", Owner = "Bob", Date = 2063 };
            BankCard bankCard3 = new BankCard { Number = "333", Owner = "Charlie", Date = 2025 };

            // Act
            hashTable.AddPoint(bankCard1);
            hashTable.AddPoint(bankCard2);
            hashTable.AddPoint(bankCard3);

            // Assert
            Assert.IsTrue(hashTable.Contains(bankCard1));
            Assert.IsTrue(hashTable.Contains(bankCard2));
            Assert.IsTrue(hashTable.Contains(bankCard3));
        }

        [TestMethod]
        public void RemoveData_ChecksPredAndNextPointers_AfterRemoval()
        {
            // Arrange
            MyHashTable<BankCard> hashTable = new MyHashTable<BankCard>(3);
            BankCard bankCard1 = new BankCard { Number = "111", Owner = "Alice", Date = 2023 };
            BankCard bankCard2 = new BankCard { Number = "222", Owner = "Bob", Date = 2063 };
            BankCard bankCard3 = new BankCard { Number = "333", Owner = "Charlie", Date = 2025 };
            hashTable.AddPoint(bankCard1);
            hashTable.AddPoint(bankCard2);
            hashTable.AddPoint(bankCard3);

            // Act
            hashTable.RemoveData(bankCard2);

            // Assert
            Assert.IsTrue(hashTable.Contains(bankCard1));
            Assert.IsFalse(hashTable.Contains(bankCard2));
            Assert.IsTrue(hashTable.Contains(bankCard3));
            Assert.AreEqual(hashTable.GetIndex(bankCard1), hashTable.GetIndex(bankCard3));
        }

        [TestMethod]
        public void Constructor_WithZeroCapacity_ThrowsException()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new MyHashTable<BankCard>(0));
        }

        [TestMethod]
        public void RemoveData_WithMultipleElementsInBucket_RemovesCorrectElement()
        {
            // Arrange
            MyHashTable<BankCard> hashTable = new MyHashTable<BankCard>(3);
            BankCard bankCard1 = new BankCard { Number = "111", Owner = "Alice", Date = 20230101 };
            BankCard bankCard2 = new BankCard { Number = "222", Owner = "Bob", Date = 20230101 };
            BankCard bankCard3 = new BankCard { Number = "333", Owner = "Charlie", Date = 20230101 };
            hashTable.AddPoint(bankCard1);
            hashTable.AddPoint(bankCard2);
            hashTable.AddPoint(bankCard3);

            // Act
            hashTable.RemoveData(bankCard2);

            // Assert
            Assert.IsTrue(hashTable.Contains(bankCard1));
            Assert.IsFalse(hashTable.Contains(bankCard2));
            Assert.IsTrue(hashTable.Contains(bankCard3));
        }

        [TestMethod]
        public void Contains_AfterRemovingElement_ReturnsFalse()
        {
            // Arrange
            MyHashTable<BankCard> hashTable = new MyHashTable<BankCard>(3);
            BankCard bankCard = new BankCard { Number = "111", Owner = "Alice", Date = 20230101 };
            hashTable.AddPoint(bankCard);
            hashTable.RemoveData(bankCard);

            // Act
            bool result = hashTable.Contains(bankCard);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RemoveAllData_FromBucket_RemovesAllElements()
        {
            // Arrange
            MyHashTable<BankCard> hashTable = new MyHashTable<BankCard>(3);
            BankCard bankCard1 = new BankCard { Number = "111", Owner = "Alice", Date = 20230101 };
            BankCard bankCard2 = new BankCard { Number = "222", Owner = "Bob", Date = 20230101 };
            hashTable.AddPoint(bankCard1);
            hashTable.AddPoint(bankCard2);

            // Act
            hashTable.RemoveData(bankCard1);
            hashTable.RemoveData(bankCard2);

            // Assert
            Assert.IsFalse(hashTable.Contains(bankCard1));
            Assert.IsFalse(hashTable.Contains(bankCard2));
        }

        [TestMethod]
        public void PrintTable_ForEmptyTable_ReturnsEmpty()
        {
            // Arrange
            MyHashTable<BankCard> hashTable = new MyHashTable<BankCard>(3);
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            hashTable.PrintTable();
            string result = sw.ToString();

            // Assert
            Assert.AreEqual(string.Empty, result.Trim());
        }

        [TestMethod]
        public void AddPoint_WhenCalled_AddsElementToHashTable()
        {
            // Arrange
            MyHashTable<BankCard> hashTable = new MyHashTable<BankCard>(10);
            BankCard bankCard = new BankCard { Number = "123456789", Owner = "John Doe", Date = 20230501 };

            // Act
            hashTable.AddPoint(bankCard);

            // Assert
            Assert.IsTrue(hashTable.Contains(bankCard));
        }

        [TestMethod]
        public void RemovePoint_WhenElementExists_RemovesElementFromHashTable()
        {
            // Arrange
            MyHashTable<BankCard> hashTable = new MyHashTable<BankCard>(10);
            BankCard bankCard = new BankCard { Number = "123456789", Owner = "John Doe", Date = 2023 };
            hashTable.AddPoint(bankCard);

            // Act
            bool result = hashTable.RemoveData(bankCard);

            // Assert
            Assert.IsTrue(result);
            Assert.IsFalse(hashTable.Contains(bankCard));
        }

        [TestMethod]
        public void RemoveData_RemovesExistingData_WhenDataIsTheOnlyOneInBucket()
        {
            // Arrange
            MyHashTable<BankCard> hashTable = new MyHashTable<BankCard>(10);
            BankCard dataToRemove = new BankCard { Number = "123456789", Owner = "John Doe", Date = 2023 };
            hashTable.AddPoint(dataToRemove);

            // Act
            bool result = hashTable.RemoveData(dataToRemove);

            // Assert
            Assert.IsTrue(result);
            Assert.IsFalse(hashTable.Contains(dataToRemove));
        }

        [TestMethod]
        public void AddPoint_WhenCalledWithCollision_AddsElementToLinkedList()
        {
            // Arrange
            MyHashTable<BankCard> hashTable = new MyHashTable<BankCard>(1); // Force collision
            BankCard bankCard1 = new BankCard { Number = "123456789", Owner = "John Doe", Date = 2023 };
            BankCard bankCard2 = new BankCard { Number = "987654321", Owner = "Jane Smith", Date = 2023 };

            // Act
            hashTable.AddPoint(bankCard1);
            hashTable.AddPoint(bankCard2);

            // Assert
            Assert.IsTrue(hashTable.Contains(bankCard1));
            Assert.IsTrue(hashTable.Contains(bankCard2));
        }

        [TestMethod]
        public void RemoveData_RemovesExistingData_WhenDataIsInLinkedList()
        {
            // Arrange
            MyHashTable<BankCard> hashTable = new MyHashTable<BankCard>(1); // Force collision
            BankCard bankCard1 = new BankCard { Number = "123456789", Owner = "John Doe", Date = 2023 };
            BankCard bankCard2 = new BankCard { Number = "987654321", Owner = "Jane Smith", Date = 2023 };
            hashTable.AddPoint(bankCard1);
            hashTable.AddPoint(bankCard2);

            // Act
            bool result = hashTable.RemoveData(bankCard2);

            // Assert
            Assert.IsTrue(result);
            Assert.IsFalse(hashTable.Contains(bankCard2));
            Assert.IsTrue(hashTable.Contains(bankCard1));
        }

        [TestMethod]
        public void PrintTable_PrintsAllElements()
        {
            // Arrange
            MyHashTable<BankCard> hashTable = new MyHashTable<BankCard>(10);
            BankCard bankCard1 = new BankCard { Number = "123456789", Owner = "John Doe", Date = 2023 };
            BankCard bankCard2 = new BankCard { Number = "987654321", Owner = "Jane Smith", Date = 2023 };
            hashTable.AddPoint(bankCard1);
            hashTable.AddPoint(bankCard2);
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            hashTable.PrintTable();
            string result = sw.ToString();

            // Assert
            Assert.IsTrue(result.Contains(bankCard1.ToString()));
            Assert.IsTrue(result.Contains(bankCard2.ToString()));
        }

        [TestMethod]
        public void Contains_ReturnsFalse_ForEmptyTable()
        {
            // Arrange
            MyHashTable<BankCard> hashTable = new MyHashTable<BankCard>(10);
            BankCard bankCard = new BankCard { Number = "123456789", Owner = "John Doe", Date = 2023 };

            // Act
            bool result = hashTable.Contains(bankCard);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Contains_ReturnsTrue_ForExistingElement()
        {
            // Arrange
            MyHashTable<BankCard> hashTable = new MyHashTable<BankCard>(10);
            BankCard bankCard = new BankCard { Number = "123456789", Owner = "John Doe", Date = 2023 };
            hashTable.AddPoint(bankCard);

            // Act
            bool result = hashTable.Contains(bankCard);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Contains_ReturnsFalse_ForNonExistingElement()
        {
            // Arrange
            MyHashTable<BankCard> hashTable = new MyHashTable<BankCard>(10);
            BankCard existingBankCard = new BankCard { Number = "123456789", Owner = "John Doe", Date = 2024 };
            BankCard nonExistingBankCard = new BankCard { Number = "987654321", Owner = "Jane Smith", Date = 2023 };
            hashTable.AddPoint(existingBankCard);

            // Act
            bool result = hashTable.Contains(nonExistingBankCard);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RemoveData_ReturnsFalse_ForNonExistingElement()
        {
            // Arrange
            MyHashTable<BankCard> hashTable = new MyHashTable<BankCard>(10);
            BankCard bankCard = new BankCard { Number = "987654321", Owner = "Jane Smith", Date = 2023 };

            // Act
            bool result = hashTable.RemoveData(bankCard);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DeepCopy_CreatesIndependentCopyOfCollection()
        {
            // Arrange
            var original = new MyCollection<BankCard>();
            original.Add(new BankCard { Number = "123456789", Owner = "John Doe", Date = 2023 });
            original.Add(new BankCard { Number = "987654321", Owner = "Jane Smith", Date = 2023 });

            // Act
            var copy = original.DeepClone();
            BankCard newCard = new BankCard { Number = "555555555", Owner = "Alice", Date = 2024 };
            copy.Add(newCard);

            // Assert
            Assert.AreEqual(2, original.Count);
            Assert.AreEqual(3, copy.Count);
            Assert.IsFalse(original.Contains(newCard));
        }

        [TestMethod]
        public void ShallowCopy_CreatesShallowCopyOfCollection()
        {
            // Arrange
            var original = new MyCollection<BankCard>();
            original.Add(new BankCard { Number = "123456789", Owner = "John Doe", Date = 2023 });
            original.Add(new BankCard { Number = "987654321", Owner = "Jane Smith", Date = 2023 });

            // Act
            var copy = original.ShallowCopy();
            BankCard newCard = new BankCard { Number = "555555555", Owner = "Alice", Date = 2024 };
            copy.Add(newCard);

            // Assert
            Assert.AreEqual(2, original.Count);
            Assert.AreEqual(3, copy.Count);
            Assert.IsTrue(original.Contains(newCard));
        }
    }
}