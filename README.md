<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/1306514785/26.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1332455)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# Blazor Ribbon – Modify Blazor Grid Settings and Execute Commands

This example uses `DxRibbon` to modify the following `DxGrid` settings and execute commands:

* Add and delete rows
* Switch Grid edit modes
* Display/hide the column chooser, search box, filter panel, and group panel
* Modify the number of items on a page
* Export data to CSV, PDF, and XLSX

## Implementation Details

### Control States of DxGrid Panels

`DxRibbon` items update properties that are bound to `DxGrid` panel settings. For example, the following code snippet controls the grid's filter panel:

```html
<DxRibbon>
    @* ... *@
	<DxRibbonTab Text="Home">
		<DxRibbonGroup Text="Grid Customization">
			<DxRibbonToggleItem Text="@(ShowFilterPanel ? "Hide Filter Panel" : "Show Filter Panel")"
								Tooltip="Toggle Filter Panel"
								IconUrl="@Icon.Filter"
								Click="Grid_ToggleFilterPanel" />
        </DxRibbonGroup>
    </DxRibbonTab>
</DxRibbon>

<DxGrid ShowFilterRow="@ShowFilterPanel"
        @* ... *@ >
</DxGrid>

@code{
    // ...
	bool ShowFilterPanel { get; set; } = false;

	async Task Grid_ToggleFilterPanel() {
		ShowFilterPanel = !ShowFilterPanel;
		await Task.CompletedTask;
	}
}
```

This approach is also used to control search box, group panel, and column chooser visibility.

### Switch DxGrid Edit Modes

Both `DxRibbonComboBoxItem` and [DxGrid.EditMode](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGrid.EditMode) are bound to `CurrentEditMode`:

```html
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

Define an [EditFormTemplate](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGrid.EditFormTemplate) to use pop-up and inline edit forms:

```html
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

### Synchronize Togge Item States

The `Total Summary` ribbon item's menu contains three independent toggles. You can keep their states in sync as follows:

```html
<DxRibbonItem Text="Total Summary"
              SplitDropDownButton="true"
              Tooltip="Total Summary"
              Click="Grid_ToggleSummaries"
              IsPrimary="true" >
    <DxRibbonToggleItem Text="Product Name" Checked="@productNameSummary" Click="ToggleProductNameSummary" />
    <DxRibbonToggleItem Text="Unit Price" Checked="@unitPriceSummary" Click="ToggleUnitPriceSummary" />
    <DxRibbonToggleItem Text="Units in Stock" Checked="@unitsInStockSummary" Click="ToggleUnitsInStockSummary" />
</DxRibbonItem>

@code{
	async Task Grid_ToggleSummaries() {
		bool allOff = !productNameSummary && !unitPriceSummary && !unitsInStockSummary;

		productNameSummary = allOff;
		unitPriceSummary = allOff;
		unitsInStockSummary = allOff;

		StateHasChanged();
		await Task.CompletedTask;
	}
}
```

Once you change toggle values in code, call the [StateHasChanged](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.componentbase.statehaschanged) method to force a re-render and reflect these changes in the UI.

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
