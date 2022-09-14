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
    [XafDefaultProperty(nameof(FullName))]
    [NavigationItem(nameof(Book))]

    public class Author : BaseObject
    {
        public Author(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        /// <summary>
        /// Klasa opisująca Autorów książek z naszej biblioteczki oraz z poza niej.
        /// </summary>
        /// <param name= "authorID">Unikaowy identwyfikator autora</param>
        /// <param name= "name">Imie autora</param>
        /// <param name= "surname">Nazwisko autora</param>
        /// <param name= "bornDate">Data urodzenia autora</param>
        /// <param name= "bornWhere">Gdzie autor się urodził</param>

        string bornWhere;
        DateTime bornDate;
        string surname;
        string name;
        int authorID;

        /// <summary>
        /// Zmienna przyjmująca niepowtarzalny indentyfikator autora.
        /// </summary>
        /// <param name= "authorID">Unikaowy identwyfikator autora</param>

        [VisibleInListView(false)]
        [VisibleInDetailView(true)]
        [VisibleInLookupListView(false)]
        public int AuthorID
        {
            get => authorID;
            set => SetPropertyValue(nameof(AuthorID), ref authorID, value);
        }

        /// <summary>
        /// Zmienna przechowująca imie autora.
        /// </summary>
        /// <param name= "Name">Imie autora</param>

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

        /// <summary>
        /// Zmienna przechowująca Nazwisko autora.
        /// </summary>
        /// <param name= "Surname">Nazwisko autora</param>

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Surname
        {
            get => surname;
            set => SetPropertyValue(nameof(Surname), ref surname, value);
        }

        /// <summary>
        /// Zmienna przechowująca datę urodzin autora.
        /// </summary>
        /// <param name= "BornDate">Data urodzenia autora</param>

        public DateTime BornDate
        {
            get => bornDate;
            set => SetPropertyValue(nameof(BornDate), ref bornDate, value);
        }

        /// <summary>
        /// Zmienna przechowująca miejsce narodzin autora.
        /// </summary>
        /// <param name= "BornWhere">Gdzie autor się urodził</param>

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string BornWhere
        {
            get => bornWhere;
            set => SetPropertyValue(nameof(BornWhere), ref bornWhere, value);
        }

        /// <summary>
        /// Przekazanie informacji z klasy Author do klasy Book.
        /// </summary>
        /// <param name= "BookAuthor">Informacje o autorze</param>


        [Association("Author-BookAuthor")]
        public XPCollection<Book> BookAuthor
        {
            get
            {
                return GetCollection<Book>(nameof(BookAuthor));
            }
        }

        /// <summary>
        /// W celu wyświetlenia imienia i nazwiska autora razem utworzenie zmiennej FullName.
        /// </summary>
        /// <param name= "FullName">Połączenie imienia z nazwiskiem autora</param>

        [VisibleInListView(false)]
        [VisibleInDetailView(true)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string FullName
        {
            get => name + " " + surname;
        }
    }
}