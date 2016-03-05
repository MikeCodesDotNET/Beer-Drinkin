jQuery(function ($) {

    'use strict';
	
	/*==============================================================*/
    // Table of index
    /*==============================================================*/

    /*==============================================================
    # Menu add class
    # Magnific Popup
    # WoW Animation
    ==============================================================*/
	
	// ----------------------------------------------
    // # Demo Chooser
    // ----------------------------------------------

    (function ()
    {
		$('.demo-chooser .toggler').on('click', function(event){
			event.preventDefault();
			$(this).closest('.demo-chooser').toggleClass('opened');
		})
    }());
	
	/*==============================================================*/
    // # Preloader
    /*==============================================================*/
    
    (function () {
        $(window).load(function(){         
            $('.preloader').fadeOut('fast',function(){$(this).remove();});       
        });
    }());
	
	
	/*==============================================================*/
	//Mobile Toggle Control
	/*==============================================================*/
	
	 $(function(){ 
		 var navMain = $("#mainmenu");
		 navMain.on("click", "a", null, function () {
			 navMain.collapse('hide');
		 });
	 });
	 	
		
	/*==============================================================*/
    // Menu add class
    /*==============================================================*/
	(function () {	
		function menuToggle(){
	        $('.navbar').addClass('navbar-fixed-top');	
		}

		menuToggle();
	}());
	
	$('#mainmenu').onePageNav({
		currentClass: 'active',
	});
	
	
	/*==============================================================*/
    // WoW Animation
    /*==============================================================*/
	new WOW().init();

	/*==============================================================*/
    // Owl Carousel
    /*==============================================================*/

	$("#team-slider").owlCarousel({ 	
		pagination	: false,	
		navigation:true,
		navigationText: [
		  "<span class='team-slider-left'><i class=' fa fa-angle-left '></i></span>",
		  "<span class='team-slider-right'><i class=' fa fa-angle-right'></i></span>"
		]
	});
	
	$("#screenshot-slider").owlCarousel({ 
		items : 4,
		pagination	: true,	
	});
	
	/*==============================================================*/
    // Magnific Popup
    /*==============================================================*/
	
	(function () {
		$('.image-link').magnificPopup({
			gallery: {
			  enabled: true
			},		
			type: 'image' 
		});
		$('.feature-image .image-link').magnificPopup({
			gallery: {
			  enabled: false
			},		
			type: 'image' 
		});
		$('.image-popup').magnificPopup({	
			type: 'image' 
		});
		$('.video-link').magnificPopup({type:'iframe'});
	}());
	
	
	
});

