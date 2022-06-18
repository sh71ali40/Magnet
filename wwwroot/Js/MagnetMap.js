
import "./leaflet.js";

var DotnetHelper;
window.cmpInitializer = (dotnetHelper) => {
    DotnetHelper = dotnetHelper;
}

var map= L.map('MagnetMap');;

 

export function AddZoomCenter(center, zoom) {
    
    if (!center[0] || !center[1]) {
        console.error('Center format is not correct');
    }
    map.setView([center[0], center[1]], zoom);

}

export function AddTileLayer(tileUrl, maxZoom, minZoom, attribution) {
     
    L.tileLayer(tileUrl, {
        maxZoom: maxZoom,
        attribution: attribution,
        minZoom: minZoom
    }).addTo(map);
}

export function AddMarkers(markers, locationField, tooltipField, markerIcon, selectedMarkerIcon) {
    
    
    markers.forEach((item, index) => {

        var markerAttribute = { marker: item, isSelected: false };
        if (markerIcon) {
            markerAttribute['icon'] = L.icon(markerIcon);
        }

        var marker = L
            .marker([item[locationField.convertToJsPropertyName()][0], item[locationField.convertToJsPropertyName()][1]], markerAttribute)
            .bindTooltip(item[tooltipField.convertToJsPropertyName()], { direction: 'top'}).openTooltip()
            .addTo(map)
            .on('click', function (e) {
                
                DotnetHelper.invokeMethodAsync('MarkerClick', this.options.marker, !this.options.isSelected).then(res => {
                    if (!this.options.isSelected) {
                        if (selectedMarkerIcon) {
                            marker.setIcon(L.icon(selectedMarkerIcon));
                        }
                        
                        this.options.isSelected = true;
                    } else {
                        this.options.isSelected = false;
                        if (markerIcon) {
                            marker.setIcon(L.icon(markerIcon));
                        }
                        
                    }
                });

            });

    });

}

// convert PascalCase string to camelCase string 
// for example latLng -> LatLng
Object.defineProperty(String.prototype, 'convertToJsPropertyName', {
    value: function convertToJsPropertyName() {
    return this.charAt(0).toLowerCase() + this.slice(1);
}
});
 

 