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
    [XafDefaultProperty(nameof(FullLocation))]
    [NavigationItem(nameof(Location))]
    public class Bookcase : BaseObject
    {
        public Bookcase(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        /// <summary>
        /// Klasa przechowująca informacje w jakim regale przechowywane są książki.
        /// </summary>
        /// <param name="IdBookcase">Unikaowy identwyfikator regału</param>
        /// <param name="BookcaseNumber">numer regału</param>
        /// <param name="LibrarySide">strona biblioteki</param>
        /// <param name="Shelf">półka</param>

        Shelf shelf;
        string librarySide;
        int bookcaseNumber;
        int idBookcase;

        [VisibleInListView(false)]
        [VisibleInDetailView(true)]
        [VisibleInLookupListView(false)]
        public int IdBookcase
        {
            get => idBookcase;
            set => SetPropertyValue(nameof(IdBookcase), ref idBookcase, value);
        }

        public int BookcaseNumber
        {
            get => bookcaseNumber;
            set => SetPropertyValue(nameof(BookcaseNumber), ref bookcaseNumber, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string LibrarySide
        {
            get => librarySide;
            set => SetPropertyValue(nameof(LibrarySide), ref librarySide, value);
        }

        /// <summary>
        /// Pobiera informacje z klasy Shelf do klasy Bookcase.
        /// </summary>
        /// <param name= "Shelf">Informacje o półce</param>

        [Association("Shelf-Cases")]
        public Shelf Shelf
        {
            get => shelf;
            set => SetPropertyValue(nameof(Shelf), ref shelf, value);
        }

        /// <summary>
        /// Przelazuje informacje z klasy Bookcase do klasy Location.
        /// </summary>
        /// <param name= "Locations">Informacje o regale</param>

        [Association("Bookcase-Locations")]
        public XPCollection<Location> Locations
        {
            get
            {
                return GetCollection<Location>(nameof(Locations));
            }
        }

        /// <summary>
        /// W celu wyświetlenia Pełnej lokalizacji (regału, półki i strony po której się znajduje) 
        /// utworzenie zmiennej FullLocation.
        /// </summary>
        /// <param name= "FullLocation">Łączy numer regału, literę półki i strony biblioteki</param>

        [VisibleInListView(false)]
        [VisibleInDetailView(true)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string FullLocation
        {
            get => "Bookcase " + BookcaseNumber + ", shelf " + Shelf + ", on " + LibrarySide + " side";
        }
        //TODO: Zrobić funkcje SearchShelf
    }
}