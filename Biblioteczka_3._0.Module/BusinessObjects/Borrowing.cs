using Biblioteczka.Module.BusinessObjects;
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

namespace Biblioteczka_3._0.Module.BusinessObjects
{
    [DefaultClassOptions]
    [XafDefaultProperty(nameof(WhoBorrow))]

    public class Borrowing : BaseObject
    { 
        public Borrowing(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        [Action(ToolTip = "Postpone the return to the next day")]
        public void Postpone()
        {
            if (ReturnDate == DateTime.MinValue)
            {
                ReturnDate = DateTime.Now;
            }
            ReturnDate = ReturnDate + TimeSpan.FromDays(1);
        }

        DateTime returnDate;
        BookInstance whichBook;
        DateTime whenBorrowed;
        Borrower whoBorrow;

        [Association("Borrower-Borrowings")]
        public Borrower WhoBorrow
        {
            get => whoBorrow;
            set => SetPropertyValue(nameof(WhoBorrow), ref whoBorrow, value);
        }


        [Association("BookInstance-Borrowings")]
        public BookInstance WhichBook
        {
            get => whichBook;
            set => SetPropertyValue(nameof(WhichBook), ref whichBook, value);
        }

        public DateTime WhenBorrowed
        {
            get => whenBorrowed;
            set => SetPropertyValue(nameof(WhenBorrowed), ref whenBorrowed, value);
        }
        
        public DateTime ReturnDate
        {
            get => returnDate;
            set => SetPropertyValue(nameof(ReturnDate), ref returnDate, value);
        }
    }
}