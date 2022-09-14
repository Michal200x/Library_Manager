using Biblioteczka.Module.BusinessObjects;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteczka_3._0.Module.Controllers
{
    public partial class ClearWishList : ViewController
    {
        public ClearWishList()
        {
            InitializeComponent();
            TargetViewType = ViewType.DetailView;
            TargetObjectType = typeof(Book);

            SimpleAction clearTasksAction = new SimpleAction(this, "ClearWishListAction", PredefinedCategory.View)
            {
                Caption = "Clear Wish List",
                ConfirmationMessage = "Are you sure you want to clear the Wish List?",
                ImageName = "Action_Clear"
            };
            clearTasksAction.Execute += ClearWishListAction_Execute;
        }

        private void ClearWishListAction_Execute(Object sender, SimpleActionExecuteEventArgs e)
        {
            while (((Book)View.CurrentObject).WishLists.Count > 0)
            {
                ((Book)View.CurrentObject).WishLists.Remove(((Book)View.CurrentObject).WishLists[0]);
            }
            ObjectSpace.SetModified(View.CurrentObject);
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
