using Syncfusion.Maui.TabView;
using System.ComponentModel;

namespace TabViewSample
{
    public class ViewModel : INotifyPropertyChanged
    {
        private TabItemCollection? items;
        public event PropertyChangedEventHandler? PropertyChanged;
        public TabItemCollection? Items
        {
            get { return items; }
            set
            {
                items = value;
                OnPropertyChanged("Items");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ViewModel()
        {
            SetItems();
        }

        internal void SetItems()
        {
            Items = new TabItemCollection();
            TabViewPage1 page1 = new TabViewPage1();
            TabViewPage2 page2 = new TabViewPage2();
            TabViewPage3 page3 = new TabViewPage3();

            SfTabItem firstTabitem = new SfTabItem{ Content = page1.Content, Header = "Page1" };
            firstTabitem.Content.BindingContext = page1.BindingContext;

            SfTabItem secondTabitem = new SfTabItem { Content = page2.Content, Header = "Page2" };
            secondTabitem.Content.BindingContext = page2.BindingContext; 

            SfTabItem thirdTabitem = new SfTabItem { Content = page3.Content, Header = "Page3" };
            thirdTabitem.Content.BindingContext = page3.BindingContext; 

            Items.Add(firstTabitem);
            Items.Add(secondTabitem);
            Items.Add(thirdTabitem);
        }
    }
}
