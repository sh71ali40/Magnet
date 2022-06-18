using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magnet.Class;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Magnet.Components.Map
{
    public partial class TileLayer
    {
        
        [Parameter] public string TileUrl { get; set; } = "https://{s}.tile-cyclosm.openstreetmap.fr/cyclosm/{z}/{x}/{y}.png";
        [Parameter] public int MinZoom { get; set; } = 1;
        [Parameter] public int MaxZoom { get; set; } = 19;
        [Parameter] public string Attribution { get; set; } = "© OpenStreetMap";

        [Inject] public IJSRuntime JsRuntime { get; set; }
        private IJSObjectReference _jsModule;
        private DotNetObjectReference<MagnetMap>? objRef;
        protected override async Task OnInitializedAsync()
        {
            
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                
                _jsModule = await JsRuntime.InvokeAsync<IJSObjectReference>(
                    "import", "./_content/Magnet/Js/MagnetMap.js");

                await _jsModule.InvokeVoidAsync("AddTileLayer", TileUrl, MaxZoom, MinZoom, Attribution);

            }
        }
    }
}
