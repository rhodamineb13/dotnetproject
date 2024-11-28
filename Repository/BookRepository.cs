using dotnetproject.Data;
using dotnetproject.Models.Entities;

namespace dotnetproject.Repository;

public interface IBookRepository {
    public IEnumerable<BookEntity>? GetBooks(BookPaginationEntity page);
    public BookEntity FindByID(int bookId);
    public BookEntity Insert(BookEntity book);
    public void Update(BookEntity book);
    public void Delete(int bookId);
}

public class BookRepository : IBookRepository {
    private readonly ApplicationContext _db;

    public BookRepository(ApplicationContext db) {
        this._db = db;
    }

    public IEnumerable<BookEntity>? GetBooks(BookPaginationEntity page) {
       List<BookEntity> bookList = this._db.Books.ToList();
       return bookList;
    }

    public BookEntity FindByID(int bookId) {
        return new BookEntity();
    }

    public BookEntity Insert(BookEntity book) {
        this._db.Books.Add(book);
        this._db.SaveChanges();

        return book;
    }

    public void Update(BookEntity book) {
    }

    public void Delete(int bookId) {
    }
}