When working with the [SfTabView,](https://www.syncfusion.com/maui-controls/maui-tab-view) it's important to ensure that data binding is correctly set up so that the data is displayed within the tabs as expected. This article provides a guide on how to bind data to the respective fields within tab pages of the SfTabView.

**Step 1:** Create a new sample in the .NET MAUI and initialize TabView within the page with `BindingContext.`

**XAML**
```
<contentpage.bindingcontext>
    <local:viewmodel>
</local:viewmodel></contentpage.bindingcontext>
<tabview:sftabview items="{Binding Items}">
```

**Step 2:** Create different content pages that you need to display as a `TabItem` and for each content page, set `BindingContext` from its respective ViewModel. For example,

**XAML**
```
<contentpage xmlns="http://schemas.microsoft.com/dotnet/2021/maui" xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" x:class="TabView.TabViewPage1" title="TabViewPage1" xmlns:local="clr-namespace:TabView">
    <contentpage.bindingcontext>
        <local:tabviewpage1viewmodel>
    </local:tabviewpage1viewmodel></contentpage.bindingcontext>
    <verticalstacklayout verticaloptions="Center">
        <label text="{Binding Title}" verticaloptions="Center" horizontaloptions="Center">
    </label></verticalstacklayout>
</contentpage>
```

**C#**

```
public class TabViewPage1ViewModel
{
    public string Title { get; set; }

    public TabViewPage1ViewModel()
    {
        Title = "Welcome to .NET MAUI!";
    }
}
```

Create as many content pages as you need for display within the `TabItem` and its respective view model, like above.

**Step 3:** To bind data to the tab pages, you need to set up your ViewModel to manage the data for each tab. Here's an example of how you can initialize your tab items and bind the context to each page:

**C#**
```csharp
// ViewModel.cs

public class ViewModel : INotifyPropertyChanged
{
private TabItemCollection items;
public event PropertyChangedEventHandler PropertyChanged;
public TabItemCollection Items
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
    TabViewPage3 page4 = new TabViewPage3();
    SfTabItem firstTabitem = new SfTabItem{ Content = page1.Content, Header = "Page1" };
    firstTabitem.Content.BindingContext = page1.BindingContext;

    SfTabItem secondTabitem = new SfTabItem { Content = page2.Content, Header = "Page2" };
    secondTabitem.Content.BindingContext = page2.BindingContext; 

    SfTabItem thirdTabitem = new SfTabItem { Content = page3.Content, Header = "Page3" };
    thirdTabitem.Content.BindingContext = page3.BindingContext; 

    SfTabItem fourthTabitem = new SfTabItem { Content = page4.Content, Header = "Page4" };
    fourthTabitem.Content.BindingContext = page4.BindingContext;

    Items.Add(firstTabitem);
    Items.Add(secondTabitem);
    Items.Add(thirdTabitem);
    Items.Add(fourthTabitem);

}
}
```

In this example, each `SfTabItem` is initialized with the content and header, and the `BindingContext` of the content is set to the `BindingContext` of the respective page.

Please note that the code snippets provided in this article are for illustrative purposes and may require adjustments to fit the specific requirements of your application.

**Output**

![ezgif.com-video-to-gif (9).gif](https://support.syncfusion.com/kb/agent/attachment/article/14410/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjE0ODg2Iiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.VeZIlJvk_lBwkDgAMxLxp2Uql6ap6gzG1mjYNNBF4_8)


 :::Info
**Important note for prism framework**

If you are using the `Prism framework,` it's important to note that the SfTabView may not work as expected due to the way Prism `auto-wires` the binding context. Since the SfTabView is a `content view` control, and the content of the page is assigned to the tab item content, the page's binding context is set to null. This results in the ViewModel not being recognized when setting the page content to the tab item content. Therefore, the SfTabView may not be suitable for use with the Prism framework.
 :::