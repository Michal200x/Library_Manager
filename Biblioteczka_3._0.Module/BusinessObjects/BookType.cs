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
    [XafDefaultProperty(nameof(LiteraryGenre))]
    [NavigationItem(nameof(Book))]
    public class BookType : BaseObject
    {
        public BookType(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        /// <summary>
        /// Klasa opisująca Typ książki.
        /// </summary>
        /// <param name= "LiteraryGenre">Gatunek literacki</param>
        /// <param name= "Addressee">Grupa adresatów książki</param>

        string addressee;
        string literaryGenre;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string LiteraryGenre
        {
            get => literaryGenre;
            set => SetPropertyValue(nameof(LiteraryGenre), ref literaryGenre, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Addressee
        {
            get => addressee;
            set => SetPropertyValue(nameof(Addressee), ref addressee, value);
        }

        /// <summary>
        /// Przekazanie informacji z klasy BookType do klasy Book.
        /// </summary>
        /// <param name= "Books">Informacje o typie książki</param>

        [Association("BookType-Books")]
        public XPCollection<Book> Books
        {
            get
            {
                return GetCollection<Book>(nameof(Books));
            }
        }
        //TODO: ShowAvailableTypes zrobić funkcje
    }
}