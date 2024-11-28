using dotnetproject.Models.DTO;
using dotnetproject.Models.Entities;
using dotnetproject.Repository;
using dotnetproject.Models;

namespace dotnetproject.Usecase;

public interface IBookUsecase {
    public IEnumerable<BookDTO>? GetBooks(BookPagination page);
    public BookDTO? FindBookByID(int bookID);
    public BookDTO? CreateNewBook(BookDTO bookDTO);
    public void UpdateBook(BookDTO bookDTO);
    public void DeleteBook(int bookId);
}

public class BookUsecase : IBookUsecase{
    private readonly IBookRepository _bookRepo;

    public BookUsecase(IBookRepository bookRepo) {
        this._bookRepo = bookRepo;
    }

    public IEnumerable<BookDTO>? GetBooks(BookPagination page) {
        try {
            List<BookDTO> booksDTO = new List<BookDTO>();
            IEnumerable<BookEntity>? books = this._bookRepo.GetBooks(new BookPaginationEntity());
            foreach (BookEntity book in books) {
                booksDTO.Add(new BookDTO{
                    ID = book.Id,
                    Author = book.Author,
                    Title = book.Title,
                    Qty = book.Qty,
                    CreatedAt = book.CreatedAt,
                    UpdatedAt = book.UpdatedAt
                });
            }
            
            return booksDTO;
        }
        catch (Exception ex) {
            throw new UnknownException("Unknown error from making the request: ", ex);
        }
        
    }

    public BookDTO? FindBookByID(int bookId) {
        try
        {
            BookEntity bookEntity = this._bookRepo.FindByID(bookId);
            return new BookDTO();
        }
        catch (Exception)
        {
            throw new NotFoundException($"Book with ID {bookId} cannot be found");
        }
    }

    public BookDTO? CreateNewBook(BookDTO bookDTO) {
        try
        {
            BookEntity bookCreate = new BookEntity {
                Title = bookDTO.Title,
                Author = bookDTO.Author,
                Qty = bookDTO.Qty,
            };
            BookEntity bookEntityResp = this._bookRepo.Insert(bookCreate);

            return new BookDTO {
                ID = bookEntityResp.Id,
                Title = bookDTO.Title,
                Author = bookDTO.Author,
                Qty = bookDTO.Qty,
                CreatedAt = bookEntityResp.CreatedAt,
                UpdatedAt = bookEntityResp.UpdatedAt
            };
        }
        catch (Exception ex)
        {
            throw new NotCreatedException($"failed to create new book: {ex}");
        }
    }

    public void UpdateBook(BookDTO bookDTO) {

    }

    public void DeleteBook(int bookId) {

    }
}