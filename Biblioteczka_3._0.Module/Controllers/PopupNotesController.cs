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
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteczka_3._0.Module.Controllers
{
     public partial class PopupNotesController : ViewController
    {
        
        public PopupNotesController()
        {
            InitializeComponent();
            TargetObjectType = typeof(Borrower);
            TargetViewType = ViewType.DetailView;

            PopupWindowShowAction showNotesAction = new PopupWindowShowAction(this, "ShowNotesAction", PredefinedCategory.Edit)
            {
                Caption = "Show Notes"
            };

            showNotesAction.CustomizePopupWindowParams += ShowNotesAction_CustomizePopupWindowParams;
            showNotesAction.Execute += ShowNotesAction_Execute;
        }

        private void ShowNotesAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(Note));
            string noteListViewId = Application.FindLookupListViewId(typeof(Note));
            CollectionSourceBase collectionSource = Application.CreateCollectionSource(objectSpace, typeof(Note), noteListViewId);
            e.View = Application.CreateListView(noteListViewId, collectionSource, true);
        }

        private void ShowNotesAction_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            Borrower borrower = (Borrower)View.CurrentObject;
            foreach (Note note in e.PopupWindowViewSelectedObjects)
            {
                if (!string.IsNullOrEmpty(borrower.Description))
                {
                    borrower.Description += Environment.NewLine;
                }
                borrower.Description += note.Text;
            }
            View.ObjectSpace.CommitChanges();
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
