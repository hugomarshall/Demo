using DemoCore.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoCore.WebUI.ViewComponents
{
    [ViewComponent(Name = "SelectItems")]
    public class SelectItemsViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(ICollection<SelectedItems> request, string nameComponent)
        {
            foreach(var item in request)
            {
                item.NameComponent = nameComponent;
            }
            return View(request);
        }
    }

    [ViewComponent(Name = "SelectItemWithValues")]
    public class SelectItemsWithValuesViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(ICollection<SelectedItemWithValue> request)
        {
            return View(request);
        }
    }
}
