if($('#map').length == 1){
	
	function initMap() {
		
		var myLatLng = {lat: 28.460383, lng: 77.017366};

        var map = new google.maps.Map(document.getElementById('map'), {
          	center: myLatLng,
		  	zoom: 12,
		  	panControl: false,
			zoomControl: false,
			scaleControl: false,
			disableDefaultUI: true
          
		});
		
		var marker = new google.maps.Marker({
			position: myLatLng,
			map: map
		  });
      }
}


