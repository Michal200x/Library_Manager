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
    [NavigationItem(nameof(Borrower))]
    public class Person : BaseObject
    {
        public Person(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        /// <summary>
        /// Klasa przechowująca informacje o osobach korzystających z biblioteczki.
        /// </summary>
        /// <param name="AmountOfBook">inforumje ile książek przeczytała dana osoba</param>
        /// <param name="BorrowerNumber">numer przypisywany wypożyczającemu</param>
        /// <param name="Surname">nazwisko osoby</param>
        /// <param name="Name">imie osoby</param>
        /// <param name="IdPerson">Unikaowy identwyfikator osoby</param>

        int amountOfBook;
        string borrowerNumber;
        string surname;
        string name;
        int idPerson;

        [VisibleInListView(false)]
        [VisibleInDetailView(true)]
        [VisibleInLookupListView(false)]
        public int IdPerson
        {
            get => idPerson;
            set => SetPropertyValue(nameof(IdPerson), ref idPerson, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Surname
        {
            get => surname;
            set => SetPropertyValue(nameof(Surname), ref surname, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string BorrowerNumber
        {
            get => borrowerNumber;
            set => SetPropertyValue(nameof(BorrowerNumber), ref borrowerNumber, value);
        }

        public int AmountOfBook
        {
            get => amountOfBook;
            set => SetPropertyValue(nameof(AmountOfBook), ref amountOfBook, value);
        }

        /// <summary>
        /// Przekazanie informacji z klasy Person do klasy Borrower.
        /// </summary>
        /// <param name= "Borrowers">Informacje o osobie</param>

        [Association("Person-Borrowers")]
        public XPCollection<Borrower> Borrowers
        {
            get
            {
                return GetCollection<Borrower>(nameof(Borrowers));
            }
        }

        /// <summary>
        /// Przekazanie informacji z klasy Person do klasy LibraryOwner.
        /// </summary>
        /// <param name= "LibraryOwners">Informacje o osobie</param>

        [Association("Person-LibraryOwners")]
        public XPCollection<LibraryOwner> LibraryOwners
        {
            get
            {
                return GetCollection<LibraryOwner>(nameof(LibraryOwners));
            }
        }

        /// <summary>
        /// W celu wyświetlenia imienia i nazwiska osoby razem utworzenie zmiennej FullName.
        /// </summary>
        /// <param name= "FullName">Połączenie imienia z nazwiskiem osoby</param>

        [VisibleInListView(false)]
        [VisibleInDetailView(true)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string FullName
        {
            get => Name + " " + Surname;
        }

        [Association("Person-WishLists")]
        public XPCollection<WishList> WishLists
        {
            get
            {
                return GetCollection<WishList>(nameof(WishLists));
            }
        }
    }
}