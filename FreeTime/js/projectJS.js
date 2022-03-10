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