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
    [NavigationItem(nameof(Borrower))]
    [XafDefaultProperty(nameof(Person))]
    public class Borrower : BaseObject
    {
        public Borrower(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        string description;
        /// <summary>
        /// Klasa opisująca wypożyczających książki z naszej biblioteczki.
        /// </summary>
        /// <param name= "PermissionToBorrow">zmienna wykazująca czy wypożyczający może pożyczać książki</param>

        bool permissionToBorrow;
        Person person;

        /// <summary>
        /// Pobranie informacji z klasy Person do klasy Borrower.
        /// </summary>
        /// <param name= "Person">Informacje o osobie (która będzie wypożyczać)</param>

        [Association("Person-Borrowers")]
        public Person Person
        {
            get => person;
            set => SetPropertyValue(nameof(Person), ref person, value);
        }

        public bool PermissionToBorrow
        {
            get => permissionToBorrow;
            set => SetPropertyValue(nameof(PermissionToBorrow), ref permissionToBorrow, value);
        }
        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Description
        {
            get => description;
            set => SetPropertyValue(nameof(Description), ref description, value);
        }
        [Association("Borrower-Borrowings")]
        public XPCollection<Borrowing> Borrowings
        {
            get
            {
                return GetCollection<Borrowing>(nameof(Borrowings));
            }
        }
    }

    public class LibraryOwner : Borrower
    {
        public LibraryOwner(Session session) : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        /// <summary>
        /// Klasa dziedzicząca po klasie Borrower opisująca właściciela wypożyczającego książkę z jego biblioteczki.
        /// </summary>
        /// <summary>
        /// Pobranie informacji z klasy Person do klasy LibraryOwners.
        /// </summary>
        /// <param name= "Owner">Informacje o właścicielu biblioteczki</param>

        Person owner;

        [Association("Person-LibraryOwners")]
        public Person Owner
        {
            get => owner;
            set => SetPropertyValue(nameof(Owner), ref owner, value);
        }
    }
}