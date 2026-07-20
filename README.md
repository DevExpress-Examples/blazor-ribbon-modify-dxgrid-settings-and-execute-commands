<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/1306514785/26.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1332455)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# Blazor Ribbon - Control DxGrid Actions and Settings

This repository uses `DxRibbon` to control the following `DxGrid` actions and settings:

* create and delete rows
* change grid's edit mode
* show/hide column chooser, search box, filter panel, and group panel
* change the number of items per page
* export data to CSV, PDF, and XLSX.

This example uses the following DxRibbon elements:

* `DxRibbonApplicationTab` and `DxRibbonApplicationTabItem`
* `DxRibbonTab` and `DxRibbonGroup`
* `DxRibbonToggleItem`, `DxRibbonItem`, `DxRibbonSpinEditItem`, `DxRibbonComboBoxItem`.

## Implementation Details

### Control States of DxGrid Panels

`DxRibbon` items update properties that are bound to `DxGrid` panel settings. For example, the following code snippet controls grid's filter panel:

```
<DxRibbon>
    @* ... *@
	<DxRibbonTab Text="Home">
		<DxRibbonGroup Text="Grid Customization">
			<DxRibbonToggleItem Text="@(showFilterPanel ? "Hide Filter Panel" : "Show Filter Panel")"
								Tooltip="Toggle Filter Panel"
								IconCssClass="rb-icon rb-icon-filter"
								Click="ToggleFilterPanel" />
        </DxRibbonGroup>
    </DxRibbonTab>
</DxRibbon>

<DxGrid ShowFilterRow="@showFilterPanel"
        @* ... *@ >
</DxGrid>

@code{
    // ...
	bool showFilterPanel { get; set; } = false;

	async Task ToggleFilterPanel() {
		showFilterPanel = !showFilterPanel;
		await Task.CompletedTask;
	}
}
```

This approach is also used to control search box, group panel, and column chooser visibility.

### Change DxGrid Edit Modes

`DxRibbonComboBoxItem` binds to `CurrentEditMode`, and `DxGrid` uses this value for its [EditMode](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGrid.EditMode) setting:

```
<DxRibbon>
    @* ... *@
	<DxRibbonTab Text="Data">
		<DxRibbonGroup Text="Data">
            @* ... *@
			<DxRibbonComboBoxItem Data="EditModes"
								  @bind-Value="CurrentEditMode"
								  TextFieldName="@nameof(GridEditMode)" />
        </DxRibbonGroup>
    </DxRibbonTab>
</DxRibbon>

<DxGrid EditMode="@CurrentEditMode"
    @* ... *@ >
</DxGrid>

@code {
    // ...
	public static readonly GridEditMode[] EditModes = new GridEditMode[] {
				GridEditMode.EditCell,
				GridEditMode.EditForm,
				GridEditMode.PopupEditForm,
				GridEditMode.EditRow
	};

	private GridEditMode CurrentEditMode { get; set; } = EditModes[0];
}
```

To use `DxGrid` pop-up and inline edit forms, define an [EditFormTemplate](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGrid.EditFormTemplate):

```
<DxGrid EditMode="@CurrentEditMode"
        @* ... *@ >
	<EditFormTemplate Context="editFormContext">
		@{
			var product = (Product)editFormContext.EditModel;
		}
		<DxFormLayout>
			<DxFormLayoutItem Caption="Product Name:">
				@editFormContext.GetEditor("ProductName")
			</DxFormLayoutItem>
			<DxFormLayoutItem Caption="Category:">
				<DxComboBox Data="@categories"
							Value="@product.CategoryID"
							ValueChanged="@((int? newValue) => product.CategoryID = newValue)"
							ValidationEnabled="false"
							SearchMode="@ListSearchMode.AutoSearch"
							SearchFilterCondition="@ListSearchFilterCondition.Contains"
							TextFieldName="@nameof(Category.CategoryName)"
							ValueFieldName="@nameof(Category.CategoryID)">
				</DxComboBox>
			</DxFormLayoutItem>
			<DxFormLayoutItem Caption="Unit Price:">
				@editFormContext.GetEditor("UnitPrice")
			</DxFormLayoutItem>
			<DxFormLayoutItem Caption="Units In Stock:">
				@editFormContext.GetEditor("UnitsInStock")
			</DxFormLayoutItem>
			<DxFormLayoutItem Caption="Restock Date:">
				@editFormContext.GetEditor("RestockDate")
			</DxFormLayoutItem>
			<DxFormLayoutItem Caption="Discontinued:">
				@editFormContext.GetEditor("Discontinued")
			</DxFormLayoutItem>
		</DxFormLayout>
	</EditFormTemplate>
    @* ... *@
</DxGrid>

```

### Define Ribbon Label Items

In this example, static ribbon text is implemented with `DxRibbonItem` and custom CSS classes:

```xml
<DxRibbonItem Text="Items on Page:"
              Enabled="false"
              CssClass="rb-text-item" />
```
```css
.rb-text-item {
    color: rgb(22, 22, 22)
}
.rb-text-item:hover {
    color: rgb(22, 22, 22)!important
}
```

### Update ToggleItem State

`Total Summary` ribbon item menu contains three independent toggles. Use the following code to keep their states in sync:

```
<DxRibbonItem Text="Total Summary"
              SplitDropDownButton="true"
              Tooltip="Total Summary"
              Click="ToggleSummaries"
              IsPrimary="true" >
    <DxRibbonToggleItem Text="Product Name" Checked="@productNameSummary" Click="ToggleProductNameSummary" />
    <DxRibbonToggleItem Text="Unit Price" Checked="@unitPriceSummary" Click="ToggleUnitPriceSummary" />
    <DxRibbonToggleItem Text="Units in Stock" Checked="@unitsInStockSummary" Click="ToggleUnitsInStockSummary" />
</DxRibbonItem>

@code{
	async Task ToggleSummaries() {
		bool allOff = !productNameSummary && !unitPriceSummary && !unitsInStockSummary;

		productNameSummary = allOff;
		unitPriceSummary = allOff;
		unitsInStockSummary = allOff;

		StateHasChanged();
		await Task.CompletedTask;
	}
}
```

After you change toggle values in code, call [StateHasChanged](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.componentbase.statehaschanged?view=aspnetcore-10.0) to force a re-render and reflect these changes in the UI.

## Files to Review

- [Index.razor](./CS/Components/Pages/Index/Index.razor)
- [site.css](./CS/wwwroot/css/site.css)

## Documentation

- [DxRibbon](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxRibbon)
- [Editing and Validation in Blazor Grid](https://docs.devexpress.com/Blazor/403454/components/grid/editing-and-validation)

<!-- feedback -->
## Does This Example Address Your Development Requirements/Objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=draft-blazor-ribbon-control-dxgrid&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=draft-blazor-ribbon-control-dxgrid&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
