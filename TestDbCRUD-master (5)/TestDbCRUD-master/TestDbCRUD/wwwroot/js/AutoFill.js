// This sample uses the Place Autocomplete widget to allow the user to search
// for and select a place. The sample then displays an info window containing
// the place ID and other information about the place that the user has
// selected.
// This example requires the Places library. Include the libraries=places
// parameter when you first load the API. For example:
// <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBRh0MvECIb_kKZyEdI4KaTFDipuHno19w&libraries=places">
function initMap() {
    const map = new google.maps.Map(document.getElementById("map"), {
        center: { lat: -33.8688, lng: 151.2195 },
        zoom: 13,
    });

    const pacInput = document.getElementById("pac-input");
    const destInput = document.getElementById("dest-input");

    // Autocomplete for the "pac-input" field
    const autocompletePac = new google.maps.places.Autocomplete(pacInput, {
        fields: ["place_id", "geometry", "formatted_address", "name"],
    });
    autocompletePac.bindTo("bounds", map);

    // Autocomplete for the "dest-input" field
    const autocompleteDest = new google.maps.places.Autocomplete(destInput, {
        fields: ["place_id", "geometry", "formatted_address", "name"],
    });
    autocompleteDest.bindTo("bounds", map);

    const infowindow = new google.maps.InfoWindow();
    const infowindowContent = document.getElementById("infowindow-content");
    infowindow.setContent(infowindowContent);

    const marker = new google.maps.Marker({ map: map });
    marker.addListener("click", () => {
        infowindow.open(map, marker);
    });

    autocompletePac.addListener("place_changed", () => {
        infowindow.close();
        const place = autocompletePac.getPlace();
        var placepickIdInput;
        if (!place.geometry || !place.geometry.location) {
            return;
        }
        if (place.geometry.viewport) {
            map.fitBounds(place.geometry.viewport);
        } else {
            map.setCenter(place.geometry.location);
            map.setZoom(17);
        }
        marker.setPlace({
            placeId: place.place_id,
            location: place.geometry.location,
        });
        marker.setVisible(true);
        infowindowContent.children.namedItem("place-name").textContent = place.name;
        infowindowContent.children.namedItem("place-id").textContent = place.place_id;
        console.log("Place ID:", place.place_id);
        placepickIdInput = document.getElementById("pickup-place-id");
        placepickIdInput.value = place.place_id;
        infowindowContent.children.namedItem("place-address").textContent = place.formatted_address;
        infowindow.open(map, marker);
    });

    autocompleteDest.addListener("place_changed", () => {
        infowindow.close();
        const placeDest = autocompleteDest.getPlace();
        var placeIdInput;
        if (!placeDest.geometry || !placeDest.geometry.location) {
            return;
        }
        if (placeDest.geometry.viewport) {
            map.fitBounds(placeDest.geometry.viewport);
        } else {
            map.setCenter(placeDest.geometry.location);
            map.setZoom(17);
        }
        marker.setPlace({
            placeId: placeDest.place_id,
            location: placeDest.geometry.location,
        });
        marker.setVisible(true);
        infowindowContent.children.namedItem("place-name").textContent = placeDest.name;
        infowindowContent.children.namedItem("place-id").textContent = placeDest.place_id;
        console.log("Place ID for dest-input:", placeDest.place_id);
        placeIdInput = document.getElementById("dest-place-id");
        placeIdInput.value = placeDest.place_id;
        infowindowContent.children.namedItem("place-address").textContent = placeDest.formatted_address;
        infowindow.open(map, marker);
    });
}

window.initMap = initMap;
