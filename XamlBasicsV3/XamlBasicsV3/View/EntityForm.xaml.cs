using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamlBasicsV3.Data;
using XamlBasicsV3.Models;
using XamlBasicsV3.ViewModel;

namespace XamlBasicsV3.View
{
    public partial class EntityForm : ContentPage
    {
        public EntityEntryViewModel formEntry { get; set; }
        public long UpdateId { get; set; }
        public EntityForm()
        {
            formEntry = new EntityEntryViewModel("", false);
            BindingContext = formEntry;
            InitializeComponent();
        }
        public EntityForm(Entity entity)
        {
            BindingContext = formEntry;
            UpdateId = entity.Id;
            formEntry = new EntityEntryViewModel(entity.StringValue, entity.Favourite);
            InitializeComponent();
            StringValue.Text = entity.StringValue;
            IsFavourite.IsToggled = entity.Favourite;
        }


        public void OnSave(object o, EventArgs e)
        {
            var database = new EntityDatabase();
            var entity = new Entity()
            {
                StringValue = StringValue.Text,
                Favourite = IsFavourite.IsToggled,
                Id = UpdateId
            };

            database.SaveEntity(entity);
            Navigation.PushAsync(new MainPage());
        }
        public void OnCancel(object o, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
