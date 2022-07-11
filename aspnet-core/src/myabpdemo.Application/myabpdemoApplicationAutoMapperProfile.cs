using AutoMapper;
using myabpdemo.Books;
using myabpdemo.Bookss;
using myabpdemo.Migrations;

namespace myabpdemo
{
    public class myabpdemoApplicationAutoMapperProfile : Profile
    {
        public myabpdemoApplicationAutoMapperProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Book, CreateUpdateBookDto>().ReverseMap();
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
        }
    }
}
