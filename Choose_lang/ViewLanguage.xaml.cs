using Choose_lang.Models;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Choose_lang
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewLanguage : PopupPage
    {
        public LangBO _objLangBO;
        public LangBODB _objLangBODB;
        public ViewLanguage()
        {
            InitializeComponent();
            _objLangBODB = new LangBODB();
            var show = _objLangBODB.GetAllLoginReg();
            lv_lang.ItemsSource = show;
        }

        private bool _objref;

        public bool Isref
        {
            get { return _objref; }
            set { _objref = value;
                RaisePropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null && propertyname != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            var show = _objLangBODB.GetAllLoginReg();
            lv_lang.ItemsSource = show;
        }

        private void lv_lang_Refreshing(object sender, EventArgs e)
        {
            Isref = true;
            var show = _objLangBODB.GetAllLoginReg();
            lv_lang.ItemsSource = show;
            Isref = false;
        }
    }
}
