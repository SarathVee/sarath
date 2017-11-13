using Choose_lang.Models;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Choose_lang
{
    public class LVsearItem : INotifyPropertyChanged
    {
        public string SName
        {
            get;
            set;
        }
        private bool _isSelected;
       

        public bool IsSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; RaisePropertyChanged(); }
        }
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null && propertyname != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }
        #endregion
    }
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LanguagePage : ContentPage
    {
        public ObservableCollection<LVsearItem> items;
        public LangBO _objLangBO;
        public LangBODB _objLangBODB;
        public LanguagePage()
        {
            InitializeComponent();
            _objLangBO = new LangBO();
            btn_view.Clicked += Btn_view_Clicked;
        }

        private async void Btn_view_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new ViewLanguage());
            var page = new ViewLanguage();
            await PopupNavigation.PushAsync(page);

        }

        private bool _check;

        public bool Ischecked
        {
            get { return _check; }
            set { _check = value; }
        }
        private void sw_on_Toggled(object sender, ToggledEventArgs e)
        {
            if (sw_on.IsToggled == true)
            {
                lvSearch.IsVisible = true;
                items = new ObservableCollection<LVsearItem>();
                items.Add(new LVsearItem() { SName = "Tamil",IsSelected=false });
                items.Add(new LVsearItem() { SName = "English", IsSelected = false });
                items.Add(new LVsearItem() { SName = "Telugu", IsSelected = false });
                items.Add(new LVsearItem() { SName = "Malaiyalam", IsSelected = false });
                items.Add(new LVsearItem() { SName = "Hindi", IsSelected = false });
                items.Add(new LVsearItem() { SName = "Maraththi", IsSelected = false });
                items.Add(new LVsearItem() { SName = "Japanish", IsSelected = false });
                items.Add(new LVsearItem() { SName = "Spanish", IsSelected = false });
                items.Add(new LVsearItem() { SName = "Orudhu", IsSelected = false });
                //Iitem = items;
                lvSearch.ItemsSource = items;
            }
            else if (sw_on.IsToggled == false)
            {
                lvSearch.IsVisible = false;
            }
        }
        private async void Handle_Toggled(object sender, ToggledEventArgs e)
        {
            var selectedSkill = ((Switch)sender).BindingContext as LVsearItem;
            if (e.Value)
            {
                var move = new sample(selectedSkill);
                await PopupNavigation.PushAsync(move);
            }
            else if(e.Value==false)
            {
        
                _objLangBODB = new LangBODB();
                _objLangBODB.Delete(selectedSkill.SName);
            }
            //var action = await DisplayActionSheet("Choose method", null, "ok","Read","Write","Speak");
            //switch(action)
            //{
            //    case "Read":

            //    case "Write":
            //    case "Speak":
            //        break;
            //}
        }
    }
}
