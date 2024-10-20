using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace GutenbergBookSearchApp
{
    public partial class Form1 : Form
    {
        private const string TopBooksUrl = "https://www.gutenberg.org";
        private List<Book> books = new List<Book>();

        public Form1()
        {
            InitializeComponent();
            LoadTopBooks();
        }

        private async void LoadTopBooks()
        {
            try
            {
                var bookList = await GetTopBooksAsync();
                books = bookList;
                DisplayBooks(books);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке списка книг: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<List<Book>> GetTopBooksAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(TopBooksUrl);
                response.EnsureSuccessStatusCode();

                string html = await response.Content.ReadAsStringAsync();
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);

                var bookNodes = doc.DocumentNode.SelectNodes("//ol[@class='books']//li[contains(@class, 'booklink')]");

                if (bookNodes == null || !bookNodes.Any())
                {
                    throw new Exception("Не удалось найти узлы с книгами. Проверьте структуру HTML.");
                }

                List<Book> bookList = new List<Book>();
                foreach (var bookNode in bookNodes)
                {
                    var titleNode = bookNode.SelectSingleNode(".//h3/a");
                    var coverNode = bookNode.SelectSingleNode(".//img");

                    if (titleNode != null && coverNode != null)
                    {
                        string title = titleNode.InnerText.Trim();
                        string bookUrl = "https://www.gutenberg.org" + titleNode.GetAttributeValue("href", "");
                        string coverUrl = coverNode.GetAttributeValue("src", "");

                        bookList.Add(new Book { Title = title, Url = bookUrl, CoverUrl = coverUrl });
                    }
                }
                return bookList;
            }
        }

        private void DisplayBooks(List<Book> booksToDisplay)
        {
            listBoxBooks.Items.Clear(); 

            foreach (var book in booksToDisplay)
            {
                listBoxBooks.Items.Add(book); 
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text.ToLower();
            var filteredBooks = books.FindAll(b => b.Title.ToLower().Contains(searchText));
            DisplayBooks(filteredBooks);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text.ToLower();
            var filteredBooks = books.FindAll(b => b.Title.ToLower().Contains(searchText));
            DisplayBooks(filteredBooks);
        }

        private void listBoxBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxBooks.SelectedItem is Book selectedBook)
            {
                pictureBoxCover.Load(selectedBook.CoverUrl); 
            }
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string CoverUrl { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
