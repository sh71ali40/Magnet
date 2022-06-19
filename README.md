
# Description

MagnetMap is an easy-to-use Blazor components for using <a href="https://leafletjs.com/">Leaflet API</a> in C#. It provids customizable maps inside .NET ecosystem.

It is still in its early days so it's very lackluster.

Check out the samples project to learn how to use it.


# Installation


Import the project in your solution and paste the below code:

```html
@ShowMessage

<MagnetMap Center="new Double[] { 35, 50 }" Zoom="12" OnMarkerClick="MarkerClick">
    <MapLayers>
        <TileLayer TileUrl="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"></TileLayer>
        <MarkerLayer Data="@MarkerData" LocationField="@nameof(MarkerModel.LatLng)" TooltipField="@nameof(MarkerModel.Title)" SelectedMarkerIcon="@SelectedMarkerIcon" MarkerIcon="@MarkerIcon"></MarkerLayer>
    </MapLayers>
</MagnetMap>

@code
{

    public class MarkerModel
    {
        public double[] LatLng { get; set; }
        public string Title { get; set; }
        public int DistributionOrderId { get; set; }
    }

    public string ShowMessage { get; set; } = "";
    public Icon MarkerIcon { get; set; } = new Icon() { IconUrl = "css/marker-green.png", IconSize = new[] { 24, 12 } };
    public Icon SelectedMarkerIcon { get; set; } = new Icon() { IconUrl = "css/marker-red.png" };
    public List<MarkerModel> MarkerData { get; set; } = new List<MarkerModel>()
        {
            new MarkerModel(){
                Title = "Place 1",
                LatLng = new []{35.1, 50.2}
            },
            new MarkerModel(){
                Title = "Place 2",
                LatLng = new []{35.3, 50.1}
            }
        };

    private void MarkerClick(MapMarkerClickEventArgs obj)
    {
        ShowMessage = "clicked";
        StateHasChanged();
    }
    
}

```

You can now use the components and the rest of the library.

