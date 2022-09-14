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
    [XafDefaultProperty(nameof(Bookcase))]
    [NavigationItem(nameof(BookInstance))]
    public class Location : BaseObject
    {
        public Location(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        /// <summary>
        /// Klasa przechowująca informacje o Lokalizacji książek z biblioteczki.
        /// </summary>
        /// <param name="Bookcase">inforumje na jakiej półce w jakiej szafie oraz 
        /// po jakiej stronie znajduje się książka
        /// </param>

        Bookcase bookcase;

        [Association("Bookcase-Locations")]
        public Bookcase Bookcase
        {
            get => bookcase;
            set => SetPropertyValue(nameof(Bookcase), ref bookcase, value);
        }

        /// <summary>
        /// Przekazanie informacji o lokalizacji książek do klasy BookInstance
        /// </summary>
        /// <param name="BookLocation"> Informacje o lokalizacji</param>

        [Association("Location-BookLocation")]
        public XPCollection<BookInstance> BookLocation
        {
            get
            {
                return GetCollection<BookInstance>(nameof(BookLocation));
            }
        }
    }
}