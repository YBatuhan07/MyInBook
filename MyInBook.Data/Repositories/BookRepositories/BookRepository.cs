﻿using MyInBook.Core.MyEntities;

namespace MyInBook.Data.Repositories.BookRepositories;

public class BookRepository : BaseRepository<Book>, IBookRepository
{
    public BookRepository(MyInBookDatabaseContext context) : base(context)
    {
    }
}
