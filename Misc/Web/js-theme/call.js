/* =============================================================
    Smooth Scroll 1.1
    Animated scroll to anchor links.

    Script by Charlie Evans.
    http://www.sycha.com/jquery-smooth-scrolling-internal-anchor-links

    Rebounded by Chris Ferdinandi.
    http://gomakethings.com

    Free to use under the MIT License.
    http://gomakethings.com/mit/
 * ============================================================= */
////////////// DOCUMENT READY
$(document).ready(function(){
// SMOOTH-SCROLL
$(".scroll-smooth").click(function(event){   
  event.preventDefault();
  $('html,body').animate({scrollTop:$(this.hash).offset().top}, 700);
});
// SLIDER-INTRO
$('#slider-intro').bxSlider({
  speed: 250,
  nextSelector: '#n-intro',
  prevSelector: '#p-intro',
  nextText: '<i class="fa fa-chevron-right fa-n"></i>',
  prevText: '<i class="fa fa-chevron-left fa-p"></i>',
  auto: true,
  pager: false
});
// SLIDER-IMAC
$('#slider-imac').bxSlider({
  speed: 200,
  nextSelector: '#n-imac',
  prevSelector: '#p-imac',
  nextText: '<i class="fa fa-chevron-right fa-n"></i>',
  prevText: '<i class="fa fa-chevron-left fa-p"></i>',
  auto: true,
  pager: false
});
// MIXITUP
  $('#Grid').mixitup();
// NIVO-LIGHTBOX  
  $('a.nivoz').nivoLightbox({
  effect: 'slideUp',  

  });

  $('a.video').nivoLightbox({
  errorMessage: 'The requested content cannot be loaded. Please try again later.',
  effect: 'nonexisent'
  });
  
 });
// END DOCUMENT READY

// GOOGLE MAPS  
  function initialize() {
  var myLatlng = new google.maps.LatLng(56.948500,24.108220);
  var mapOptions = {
    zoom:16,
    center: myLatlng,
    scrollwheel: false  

  }
  var map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);
  var marker = new google.maps.Marker({
      position: myLatlng,
      map: map,
      title: 'Hello World!'
  });
}
google.maps.event.addDomListener(window, 'load', initialize);  


// CONTACT
$(document).ready(function(){
  
  $('form#ajax_form .submit').click(function(){

    $('#ajax_form .error').hide();  //if error visibile, hide on new click
    
    var name = $('input#name').val();
    if (name == "" || name == " " || name == "Name") {
        $('input#name').focus().before('<div class="error">Please enter your name.</div>');
        return false;
    }
    
    var email_test = /^([a-z0-9_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})$/;
    var email = $('input#email').val();
    if (email == "" || email == " ") {
       $('input#email').focus().before('<div class="error">Please enter your email address.</div>');
       return false;
    } else if (!email_test.test(email)) {
       $('input#email').select().before('<div class="error">Email address might be wrong.</div>');
       return false;
    }
    
    var message = $('#message').val();
    if (message == "" || message == " " || message == "Message") {
        $('#message').focus().fadeIn('slow').before('<div class="error">Please enter your message.</div>');
        return false;
    }
    
    var data_string = $('form#ajax_form').serialize();

    $.ajax({
        type:       "POST",
        url:        "email.php",
        data:       data_string,
        success:    function() {

    $('form#ajax_form').slideUp('fast').before('<div id="success"></div>');
    $('#success').html('<h3>Success</h3><p>Your email has been sent.</p>').slideDown(9000);

        }//end success function


    }) //end ajax call

    return false;


  }) //end click function
  
  var current_data = new Array();

  $('.clear').each(function(i){
    $(this).removeClass('clear').addClass('clear'+i);
    current_data.push($(this).val());

    $(this).focus(function(){
      if($(this).val() == current_data[i]) {
        $(this).val('');
      }
    });
    $(this).blur(function(){
      var stored_data = current_data[i];
      if($(this).val()==''){
        $(this).val(stored_data);
      }
    })
  })
});