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
    [XafDefaultProperty(nameof(ShelfLetter))]
    [NavigationItem(nameof(Location))]

    public class Shelf : BaseObject
    {
        public Shelf(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        /// <summary>
        /// Klasa opisująca półkę w której znajduje się dana książka.
        /// </summary>
        /// <param name= "IdShelf">Unikaowy identwyfikator półki</param>
        /// <param name= "ShelfLetter">Litera półki</param>
        /// <param name= "TopMiddleBottom">Czy znajduje się na górze, na środku czy na dole</param>

        string shelfLetter;
        string topMiddleBottom;
        int idShelf;

        [VisibleInListView(false)]
        [VisibleInDetailView(true)]
        [VisibleInLookupListView(false)]
        public int IdShelf
        {
            get => idShelf;
            set => SetPropertyValue(nameof(IdShelf), ref idShelf, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ShelfLetter
        {
            get => shelfLetter;
            set => SetPropertyValue(nameof(ShelfLetter), ref shelfLetter, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string TopMiddleBottom
        {
            get => topMiddleBottom;
            set => SetPropertyValue(nameof(TopMiddleBottom), ref topMiddleBottom, value);
        }

        /// <summary>
        /// Przekazanie informacji z klasy Shelf do klasy Bookcase.
        /// </summary>
        /// <param name= "Cases">Informacje o półce</param>

        [Association("Shelf-Cases")]
        public XPCollection<Bookcase> Cases
        {
            get
            {
                return GetCollection<Bookcase>(nameof(Cases));
            }
        }
        //TODO: zrobić funkcje SearchBook
    }
}