using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace Biblioteczka.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem (nameof(BookInstance))]
    public class WishList : BaseObject
    {
        public WishList(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Priority = Priority.Normal;
            WishStatus = Status.NotStarted;

        }

        Status wishStatus;
        int wishId;
        Book whichBook;
        Person whoWish;
        DateTime whenWish;
        string cause;
        Priority priority;

        
        public Status WishStatus
        {
            get => wishStatus;
            set => SetPropertyValue(nameof(WishStatus), ref wishStatus, value);
        }

        public Priority Priority
        {
            get => priority;
            set => SetPropertyValue(nameof(Priority), ref priority, value);
        }

        [VisibleInListView(false)]
        [VisibleInDetailView(true)]
        [VisibleInLookupListView(false)]
        public int WishId
        {
            get => wishId;
            set => SetPropertyValue(nameof(WishId), ref wishId, value);
        }
        [Association("Book-WishLists")]
        public Book WhichBook
        {
            get => whichBook;
            set => SetPropertyValue(nameof(WhichBook), ref whichBook, value);
        }
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Cause
        {
            get => cause;
            set => SetPropertyValue(nameof(Cause), ref cause, value);
        }

        public DateTime WhenWish
        {
            get => whenWish;
            set => SetPropertyValue(nameof(WhenWish), ref whenWish, value);
        }

        [Association("Person-WishLists")]
        public Person WhoWish
        {
            get => whoWish;
            set => SetPropertyValue(nameof(WhoWish), ref whoWish, value);
        }
    }
    public enum Priority
    {
        [ImageName("State_Priority_Low")]
        Low,
        [ImageName("State_Priority_Normal")]
        Normal,
        [ImageName("State_Priority_High")]
        High
    }

    public enum Status
    {
        [ImageName("State_Status_InProgress")]
        InProgress,
        [ImageName("State_Status_Completed")]
        Completed,
        [ImageName("State_Status_NotStarted")]
        NotStarted,
        [ImageName("State_Status_WaitingForSomeoneElse")]
        WaitingForSomeoneElse,
        [ImageName("State_Status_Deferred")]
        Deferred,

    }
}