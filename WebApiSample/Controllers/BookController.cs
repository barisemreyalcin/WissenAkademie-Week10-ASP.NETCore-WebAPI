using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSample.Model;

namespace WebApiSample.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class BookController : ControllerBase
	{
		private List<Book> BookList = new List<Book>()
		{
			new Book
			{
				BookId = 1,
				Title = "Suç ve Ceza",
				PageCount = 800,
				PublishDate = new DateTime(1994,2,12),
				ISBN = Guid.NewGuid().ToString()
			},

			new Book
			{
				BookId = 2,
				Title = "Savaş ve Barış",
				PageCount = 800,
				PublishDate = new DateTime(1996,6,21),
				ISBN = Guid.NewGuid().ToString()
			},

			new Book
			{
				BookId = 3,
				Title = "Yer Altından Notlar",
				PageCount = 600,
				PublishDate = new DateTime(2001,5,10),
				ISBN = Guid.NewGuid().ToString()
			},

			new Book
			{
				BookId = 4,
				Title = "Dönüşüm",
				PageCount = 750,
				PublishDate = new DateTime(1998,11,25),
				ISBN = Guid.NewGuid().ToString()
			},
		};

		// api/Book/Books
		[ActionName("BookList")]
		[HttpGet]
		public List<Book> Books()
		{
			var bookList = BookList.OrderBy(x => x.PublishDate).ToList();
			return bookList;
		}

		// İlla bir tane Get'im olmak zorunda değil
		// api/Book/GetBookById/BookId
		[HttpGet("{BookId}")] // beklediği parametreyi yazdık
		public Book GetBookById(int BookId)
		{
			var book = BookList.SingleOrDefault(x => x.BookId == BookId);
			return book;
		}

		[HttpGet("{BookId}")]
		[ActionName("GetBookByIdStr")] // Farklı imzayla aynı isimli farklı method
		public Book GetBookById(string BookId)
		{
			var book = BookList.SingleOrDefault(x => x.BookId == int.Parse(BookId.ToString()));
			return book;
		}
	}
}
