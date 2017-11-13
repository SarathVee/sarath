using Choose_lang.Models;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Choose_lang
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class sample : PopupPage
    {
        LVsearItem lvitem;
        public LangBO _objLangBO;
        public LangBODB _objLangBODB;
        public sample(LVsearItem lvItem)
        {
            InitializeComponent();
            lvitem = lvItem;
            btn_apply.Clicked += Btn_apply_Clicked;
            _objLangBODB = new LangBODB();
            _objLangBO = new LangBO();

        }

        private async void Btn_apply_Clicked(object sender, EventArgs e)
        {
            
            string lang = lvitem.SName;
            bool isSelected = lvitem.IsSelected;
            bool IsReadChecked = false;
            bool IsWriteChecked = false;
            bool IsSpeakChecked = false;
            if (cb_read.Checked == true)
            {
                IsReadChecked = true;

            }
            if (cb_speak.Checked == true)
            {
                IsSpeakChecked = true;
            }
            if (cb_write.Checked == true)
            {
                IsWriteChecked = true;
            }
                 _objLangBO.Language = lang;
                _objLangBO.Read = IsReadChecked;
                _objLangBO.Write = IsWriteChecked;
                _objLangBO.Speak = IsSpeakChecked;
                _objLangBODB.SaveLoginReg(_objLangBO);
            await PopupNavigation.PopAsync();

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        // Method for animation child in PopupPage
        // Invoced after custom animation end
        protected virtual Task OnAppearingAnimationEnd()
        {
            return Content.FadeTo(1);
        }

        // Method for animation child in PopupPage
        // Invoked before custom animation begin
        protected virtual Task OnDisappearingAnimationBegin()
        {
            return Content.FadeTo(1); ;
        }

        protected override bool OnBackButtonPressed()
        {
            // Prevent hide popup
            //return base.OnBackButtonPressed();
            return true;
        }

        // Invoced when background is clicked
        protected override bool OnBackgroundClicked()
        {
            // Return default value - CloseWhenBackgroundIsClicked
           //return base.OnBackgroundClicked();
            return false;
        }
    }
}
