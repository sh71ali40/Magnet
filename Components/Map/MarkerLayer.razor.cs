using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Magnet.Class.Map;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Magnet.Components.Map
{
    public partial class MarkerLayer
    {
        [Parameter] public object Data { get; set; }
        [Parameter] public string LocationField { get; set; }
        [Parameter] public string TooltipField { get; set; }
        [Parameter] public Icon MarkerIcon { get; set; }
        
        [Parameter] public Icon SelectedMarkerIcon { get; set; }
        
        
        [Inject] public IJSRuntime JsRuntime { get; set; }
        private IJSObjectReference _jsModule;
        private DotNetObjectReference<MagnetMap>? objRef;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                var objs = Data.GetType().GetProperty("Item");//.GetValue(Data);
                IList markers = (IList)Data;
     
                _jsModule = await JsRuntime.InvokeAsync<IJSObjectReference>(
                    "import", "./_content/Magnet/Js/MagnetMap.js");

                await _jsModule.InvokeVoidAsync("AddMarkers", markers,LocationField,TooltipField, MarkerIcon,SelectedMarkerIcon);
            }
        }
    }
}
