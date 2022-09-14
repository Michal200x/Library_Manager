using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Biblioteczka.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem(nameof(Book))]
    [XafDisplayName("📚 Books")]
    public class Book : BaseObject
    {
        public Book(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }

        /// <summary>
        /// Klasa opisująca książki z naszej biblioteczki oraz z poza niej.
        /// </summary>
        /// <param name= "IdReading">Unikaowy identwyfikator książki</param>
        /// <param name= "Title">Tytuł książki</param>
        /// <param name= "Part">Część książki</param>

        BookType types;
        int part;
        Author author;
        string title;
        int idReading;

        [VisibleInListView(false)]
        [VisibleInDetailView(true)]
        [VisibleInLookupListView(false)]
        public int IdReading
        {
            get => idReading;
            set => SetPropertyValue(nameof(IdReading), ref idReading, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Title
        {
            get => title;
            set => SetPropertyValue(nameof(Title), ref title, value);
        }

        /// <summary>
        /// Pobranie informacji z klasy BookType do klasy Book.
        /// </summary>
        /// <param name= "Types">Informacje o typie książki</param>

        [Association("BookType-Books")]
        public BookType Types
        {
            get => types;
            set => SetPropertyValue(nameof(Types), ref types, value);
        }

        /// <summary>
        /// Pobranie informacji z klasy Author do klasy Book.
        /// </summary>
        /// <param name= "Author">Informacje o autorze</param>

        [Association("Author-BookAuthor")]
        public Author Author
        {
            get => author;
            set => SetPropertyValue(nameof(Author), ref author, value);
        }

        /// <summary>
        /// Przekazanie informacji z klasy Book do klasy BookInstance.
        /// </summary>
        /// <param name= "Instance">Informacje o książce</param>

        [Association("Book-Instance")]
        public XPCollection<BookInstance> Instance
        {
            get
            {
                return GetCollection<BookInstance>(nameof(Instance));
            }
        }

        public int Part
        {
            get => part;
            set => SetPropertyValue(nameof(Part), ref part, value);
        }
        [Association("Book-WishLists")]
        public XPCollection<WishList> WishLists
        {
            get
            {
                return GetCollection<WishList>(nameof(WishLists));
            }
        }



        //TODO: zrobić wszystkie funkcje
    }
}