//$('#drawerMenu').drawer({ toggle: false });//temp remove
$(document).ready(function () {//added whole document ready runction
    $('#drawerMenu').drawer({ toggle: false });
    //$('#main-slider').liquidSlider({
    //autoSlide: true
//});
//});//end of document ready function
$('#en').click(function () {
    var opts = { language: "en", pathPrefix: "/lang" };
    $("[data-localize]").localize("homepage", opts);//changed homepage to Home
});
$('#ch').click(function () {//changed '' to ""
    var opts = { language: "ch", pathPrefix: "/lang" };
$("[data-localize]").localize("homepage", opts);
});
});
$('#main-slider').liquidSlider({//temp remove//temp remove
    autoSlide: true
});

//$('#main-slider').liquidSlider({//temp remove//temp remove
  //  autoSlide: true
//});
//$('#en').click(function () {
    //var opts = { language: "en", pathPrefix: "/lang" };
   // $("[data-localize]").localize("homepage", opts);//changed homepage to Home
//});
//$('#ch').click(function () {//changed '' to ""
  //  var opts = { language: "ch", pathPrefix: "/lang" };
  //  $("[data-localize]").localize("homepage", opts);
//});
function startIntro() {
    var intro = introJs();
    intro.setOptions({
        steps: [
          {
              intro: "Welcome to BSUPizza!"
          },
          {
              intro: "You can get <b>THE BEST PIZZA</b> here."
          },
          {
              element: document.querySelector('#navBar'),
              intro: "This is a navigation bar."
          },
          {
              element: document.querySelector('#main-slider'),
              intro: "View our products here."
          }
             //add two more steps for Home page
        ]
    });
    intro.start();
}

