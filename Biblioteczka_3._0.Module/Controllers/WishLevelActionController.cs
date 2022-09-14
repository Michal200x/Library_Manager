using Biblioteczka.Module.BusinessObjects;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.XtraPrinting.Native;
using System;
using System.Collections;
using System.Linq;
using static Biblioteczka.Module.BusinessObjects.WishList;

namespace Biblioteczka_3._0.Module.Controllers
{
    public partial class WishLevelActionController : ViewController
    {
        private ChoiceActionItem setPriorityItem;
        private ChoiceActionItem setStatusItem;
        public WishLevelActionController()
        {
            InitializeComponent();
            TargetObjectType = typeof(WishList);

            SingleChoiceAction SetWishListAction = new SingleChoiceAction(this, "SetWishListAction", PredefinedCategory.Edit)
            {
                Caption = "Set Level",
                ItemType = SingleChoiceActionItemType.ItemIsOperation,
                SelectionDependencyType = SelectionDependencyType.RequireMultipleObjects

            };

            setPriorityItem =
            new ChoiceActionItem(CaptionHelper.GetMemberCaption(typeof(WishList), "Priority"), null);
            SetWishListAction.Items.Add(setPriorityItem);
            FillItemWithEnumValues(setPriorityItem, typeof(Biblioteczka.Module.BusinessObjects.Priority));

            setStatusItem =
            new ChoiceActionItem(CaptionHelper.GetMemberCaption(typeof(WishList), "Status"), null);
            SetWishListAction.Items.Add(setStatusItem);
            FillItemWithEnumValues(setStatusItem, typeof(TaskStatus));

            SetWishListAction.Execute += SetWishListAction_Execute;
        }

        private void FillItemWithEnumValues(ChoiceActionItem parentItem, Type enumType)
        {
            EnumDescriptor ed = new EnumDescriptor(enumType);
            foreach (object current in ed.Values)
            {
                ChoiceActionItem item = new ChoiceActionItem(ed.GetCaption(current), current);
                item.ImageName = ImageLoader.Instance.GetEnumValueImageName(current);
                parentItem.Items.Add(item);
            }
        }

        private void SetWishListAction_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            IObjectSpace objectSpace = View is ListView ?
                Application.CreateObjectSpace(typeof(WishList)) : View.ObjectSpace;
            ArrayList objectsToProcess = new ArrayList(e.SelectedObjects);
            if (e.SelectedChoiceActionItem.ParentItem == setPriorityItem)
            {
                foreach (Object obj in objectsToProcess)
                {
                    WishList objInNewObjectSpace = (WishList)objectSpace.GetObject(obj);
                    objInNewObjectSpace.Priority = (Biblioteczka.Module.BusinessObjects.Priority)e.SelectedChoiceActionItem.Data;
                }
            }
            else
                if (e.SelectedChoiceActionItem.ParentItem == setStatusItem)
            {
                foreach (Object obj in objectsToProcess)
                {
                    WishList objInNewObjectSpace = (WishList)objectSpace.GetObject(obj);
                    objInNewObjectSpace.WishStatus = (Status)e.SelectedChoiceActionItem.Data;
                }
            }
            objectSpace.CommitChanges();
            View.ObjectSpace.Refresh();
        }

        protected override void OnActivated()
        {
            base.OnActivated();

        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();

        }
        protected override void OnDeactivated()
        {

            base.OnDeactivated();
        }
    }
}
