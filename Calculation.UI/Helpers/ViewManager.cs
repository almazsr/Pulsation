using System;
using System.Windows.Forms;

namespace Calculation.UI.Helpers
{
    public static class ViewManager
    {
         public static TView GetView<TView>(bool alwaysNew = false) where TView : Form
         {
             var form = Application.OpenForms[typeof (TView).Name];
             if (alwaysNew || form == null)
             {
                 return Activator.CreateInstance<TView>();
             }
             return form as TView;
         }
    }
}