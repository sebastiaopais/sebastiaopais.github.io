document.getElementById( 'more' ).addEventListener( 'click', function() {
	
    var body = document.getElementById( 'slide-body' );
	
    if( body.className == 'expanded' ) {
        body.className = '';
         document.getElementById("seta").src="img/seta.png";
    } else {
		
        body.className = 'expanded';
        document.getElementById("seta").src="img/seta1.png";
    };
} );