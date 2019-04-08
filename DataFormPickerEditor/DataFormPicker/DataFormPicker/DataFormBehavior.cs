using Syncfusion.XForms.DataForm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DataFormPicker
{
    public class DataFormBehavior : Behavior<ContentPage>
    {
        SfDataForm dataForm = null;
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            dataForm = bindable.FindByName<SfDataForm>("dataForm");
            dataForm.DataObject = new ContactInfo();
            dataForm.RegisterEditor("Country", "Picker");
            dataForm.SourceProvider = new SourceProviderExt();
        }
    }

    public class SourceProviderExt : SourceProvider
    {
        public override IList GetSource(string sourceName)
        {
            var CountryName = new List<string>();
            if (sourceName == "Country")
            {
                if(Device.RuntimePlatform == Device.Android)
                    CountryName.Add(" ");
                else
                    CountryName.Add("");
                CountryName.Add("Argentina");
                CountryName.Add("Brazil");
                CountryName.Add("Sweden");
            }
            return CountryName;
        }
    }

    public class ContactInfo
    {
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Birth Time")]
        public DateTime? BirthTime { get; set; }

        public String Country { get; set; }
    }
}
