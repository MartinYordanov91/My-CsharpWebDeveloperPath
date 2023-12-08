namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System.Text;

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TextBook_Constructor()
        {
            TextBook textBook = new("Roman", "Martin Benet", "Comedy");

            Assert.IsNotNull(textBook);
            Assert.AreEqual("Roman", textBook.Title);
            Assert.AreEqual("Martin Benet", textBook.Author);
            Assert.AreEqual("Comedy", textBook.Category);
            Assert.AreEqual(0, textBook.InventoryNumber);
            Assert.AreEqual(null, textBook.Holder);
        }

        [Test]
        public void TextBook_Property()
        {
            TextBook textBook = new(" ", " ", " ");

            Assert.IsNotNull(textBook);
            Assert.AreEqual(" ", textBook.Title);
            Assert.AreEqual(" ", textBook.Author);
            Assert.AreEqual(" ", textBook.Category);

            textBook.Title = "Financy is more";
            textBook.Author = "Mery";
            textBook.Category = "Iconomick";
            textBook.InventoryNumber = 255;
            textBook.Holder = "Martyn";

            Assert.AreEqual("Financy is more", textBook.Title);
            Assert.AreEqual("Mery", textBook.Author);
            Assert.AreEqual("Iconomick", textBook.Category);
            Assert.AreEqual(255, textBook.InventoryNumber);
            Assert.AreEqual("Martyn", textBook.Holder);
        }

        [Test]
        public void TextBook_ToString_Method()
        {
            TextBook textBook = new(" ", " ", " ");

            textBook.Title = "Financy is more";
            textBook.Author = "Mery";
            textBook.Category = "Iconomick";
            textBook.InventoryNumber = 255;
            textBook.Holder = "Martyn";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Book: Financy is more - 255");
            sb.AppendLine($"Category: Iconomick");
            sb.AppendLine($"Author: Mery");

            Assert.AreEqual(sb.ToString().Trim(), textBook.ToString());
        }

        [Test]

        public void UniversityLibrary_Prop()
        {
            UniversityLibrary universityLibrary = new();

            Assert.AreEqual(0, universityLibrary.Catalogue.Count);
        }

        [Test]
        public void UniversityLibrary_AddTextBook()
        {
            UniversityLibrary universityLibrary = new();
            TextBook textBook = new("Financy is more", "Mery", "Iconomick");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Book: Financy is more - 1");
            sb.AppendLine($"Category: Iconomick");
            sb.AppendLine($"Author: Mery");

            Assert.AreEqual(sb.ToString().Trim() , universityLibrary.AddTextBookToLibrary(textBook));

            Assert.AreEqual(1, universityLibrary.Catalogue.Count);
        }

        [Test]
        public void UniversityLibrary_LoanTextBook()
        {
            UniversityLibrary universityLibrary = new();
            TextBook textBook = new("Financy is more", "Mery", "Iconomick");
            universityLibrary.AddTextBookToLibrary(textBook);

            Assert.AreEqual(null, textBook.Holder);
            string expected = $"Financy is more loaned to Marto.";

            Assert.AreEqual(expected, universityLibrary.LoanTextBook(1, "Marto"));
            Assert.AreEqual("Marto", textBook.Holder);

            expected = $"Marto still hasn't returned Financy is more!";
            Assert.AreEqual(expected, universityLibrary.LoanTextBook(1, "Marto"));

        }

        [Test]
        public void UniversityLibrary_ReturnTextBook()
        {
            UniversityLibrary universityLibrary = new();
            TextBook textBook = new("Financy is more", "Mery", "Iconomick");

            Assert.AreEqual(null, textBook.Holder);
            universityLibrary.AddTextBookToLibrary(textBook);
            universityLibrary.LoanTextBook(1, "Marto");
            Assert.AreEqual("Marto", textBook.Holder);

            string expected = $"Financy is more is returned to the library.";
            Assert.AreEqual(expected, universityLibrary.ReturnTextBook(1));
            Assert.AreEqual(string.Empty, textBook.Holder);

        }
    }
}