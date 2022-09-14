using Biblioteczka_3._0.Module.BusinessObjects;
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
    [XafDefaultProperty(nameof(Book))]
    [NavigationItem(nameof(BookInstance))]
    public class BookInstance : BaseObject
    {
        public BookInstance(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        /// <summary>
        /// Klasa opisująca książki znajdujące się w biblioteczce.
        /// </summary>
        /// <param name= "BookInstanceID">Unikaowy identwyfikator fizycznej książki</param>
        /// <param name= "Luminaire">Rodzaj okładki</param>
        /// <param name= "Consumption">Zużycie książki</param>
        /// <param name= "Availability">dostępność książki</param>

        Location location;
        Book book;
        bool availability;
        string consumption;
        string luminaire;
        int bookInstanceID;

        [VisibleInListView(false)]
        [VisibleInDetailView(true)]
        [VisibleInLookupListView(false)]
        public int BookInstanceID
        {
            get => bookInstanceID;
            set => SetPropertyValue(nameof(BookInstanceID), ref bookInstanceID, value);
        }

        /// <summary>
        /// Pobranie informacji z klasy Book do klasy BookInstance.
        /// </summary>
        /// <param name= "Book">Informacje o książce</param>

        [Association("Book-Instance")]
        public Book Book
        {
            get => book;
            set => SetPropertyValue(nameof(Book), ref book, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Luminaire
        {
            get => luminaire;
            set => SetPropertyValue(nameof(Luminaire), ref luminaire, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Consumption
        {
            get => consumption;
            set => SetPropertyValue(nameof(Consumption), ref consumption, value);
        }

        public bool Availability
        {
            get => availability;
            set => SetPropertyValue(nameof(Availability), ref availability, value);
        }

        /// <summary>
        /// Pobranie informacji z klasy Location do klasy BookInstance.
        /// </summary>
        /// <param name= "Location">Informacje o lokalizacji książki w biblioteczce</param>

        [Association("Location-BookLocation")]
        public Location Location
        {
            get => location;
            set => SetPropertyValue(nameof(Location), ref location, value);
        }
        [Association("BookInstance-Borrowings")]
        public XPCollection<Borrowing> Borrowings
        {
            get
            {
                return GetCollection<Borrowing>(nameof(Borrowings));
            }
        }
        //TODO: ShowBookInstance zrobić funkcje
        //ToDP: AddBookToTheWishesList zrobić funkcje
    }
}