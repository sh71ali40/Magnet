using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magnet.Class;
using Magnet.Class.Map;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace Magnet.Components.Map
{
    public partial class MagnetMap
    {
        [Parameter] public string Height { get; set; } = "480px";
        
        [Parameter] public double[] Center { get; set; } = new[] { 35.6892, 51.3890 };
        [Parameter] public int Zoom { get; set; } = 13;
        [Parameter] public RenderFragment MapLayers { get; set; }

        [Parameter] public Action<MapMarkerClickEventArgs> OnMarkerClick{ get; set; }
        

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


                //if (LoadLeaflet)
                //{
                //    await JsRuntime.InvokeAsync<IJSObjectReference>(
                //        "import", "./_content/Magnet/Js/leaflet.js");
                    
                //}
                _jsModule = await JsRuntime.InvokeAsync<IJSObjectReference>(
                    "import", "./_content/Magnet/Js/MagnetMap.js");

                objRef = DotNetObjectReference.Create(this);
                await JsRuntime.InvokeAsync<string>("cmpInitializer", objRef);

                await _jsModule.InvokeVoidAsync("AddZoomCenter", Center, Zoom);
            }
        }

  
        
        [JSInvokableAttribute]
        public void MarkerClick(object marker,bool isSelected)
        {
            var mapMarekerClick = new MapMarkerClickEventArgs()
            {
                IsSelected = isSelected,
                DataItem = marker
            };
            OnMarkerClick.Invoke(mapMarekerClick);
        }
        
        
    }
}
