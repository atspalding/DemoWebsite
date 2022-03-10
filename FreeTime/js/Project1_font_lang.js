$("#fontArial").click(function () {


    $("body").css("font-family", "Arial");


});

$("#fontTimes").click(function () {


    $("body").css("font-family", "TimesNewRoman");


});

$("#fontCalibri").click(function () {


    $("body").css("font-family", "Calibri");


});
$("#fontSizeIncrease").click(function () {


    var mySize = $("body").css("font-size");
    var sizeValue = parseFloat(mySize);
    sizeValue += 2
    var unit = mySize.slice(-2);
    $("body").css("font-size", sizeValue + unit);
    $("button").css("font-size", sizeValue + unit);
    $("textarea").css("font-size", sizeValue + unit);


});
$("#fontSizeDecrease").click(function () {


    var mySize = $("body").css("font-size");
    var sizeValue = parseFloat(mySize);
    sizeValue -= 2
    var unit = mySize.slice(-2);
    $("body").css("font-size", sizeValue + unit);
    $("button").css("font-size", sizeValue + unit);
    $("textarea").css("font-size", sizeValue + unit);


});

$("#fontStyleBold").click(function () {


    if (this.checked) {

        $("body").css("font-weight", "bold");
        $("button").css("font-weight", "bold");
        $("textarea").css("font-weight", "bold");


    }
    else {
        $("body").css("font-weight", "");
        $("button").css("font-weight", "");
        $("textarea").css("font-weight", "");


    }


});
$("#fontStyleUnderLine").click(function () {


    if (this.checked) {

        $("body").css("text-decoration", "underline");
        $("button").css("text-decoration", "underline");
        $("textarea").css("text-decoration", "underline");


    }
    else {
        $("body").css("text-decoration", "");
        $("button").css("text-decoration", "");
        $("textarea").css("text-decoration", "");


    }
});



$("#fontStyleItalic").click(function () {


    if (this.checked) {

        $("body").css("font-style", "italic");
        $("button").css("font-style", "italic");
        $("textarea").css("font-style", "italic");


    }
    else {
        $("body").css("font-style", "");
        $("button").css("font-style", "");
        $("textarea").css("font-style", "");


    }



});
$("#langSP").click(function () {
    $("[data-localize]").localize("lang", { pathPrefix: "lang", language: "sp" });




    setTimeout(function () {

       // textRedo()
    }, 2000);


});

$("#langGR").click(function () {
    $("[data-localize]").localize("lang", { pathPrefix: "lang", language: "gr" });




    setTimeout(function () {

        //textRedo()
    }, 2000);


});



function textRedo() {




    var array = $("#showLog").val().split("\n");

    var spot = 0;
    var arrayString = "";
    while (spot <= array.length - 1) {
        if (array[spot] == "was push to the top of the stack") {
            array[spot] = $("#infoPush").html();


        }
        else if (array[spot] == "スタックの一番上に押し込まれた") {
            array[spot] = $("#infoPush").html();


        }
        else if (array[spot] == "Fue empujado a la pila!") {
            array[spot] = $("#infoPush").html();


        }
        else if (array[spot] == "είχε ωθήσει στην κορυφή της στοίβας") {
            array[spot] = $("#infoPush").html();


        }
        else if (array[spot] == "Input box can not be empty") {
            array[spot] = $("#infoError").html();


        }
        else if (array[spot] == "入力ボックスを空にすることはできません") {
            array[spot] = $("#infoError").html();


        }
        else if (array[spot] == "El cuadro de entrada no puede estar vacío") {
            array[spot] = $("#infoError").html();


        }
        else if (array[spot] == "πλαίσιο εισαγωγής δεν μπορεί να είναι κενό") {
            array[spot] = $("#infoError").html();


        }

        else if (array[spot] == "Was removed from the top of the stack") {
            array[spot] = $("#infoPop").html();

        }
        else if (array[spot] == "スタックの上部から取り外されました") {
            array[spot] = $("#infoPop").html();

        }
        else if (array[spot] == "Fue quitado de la tapa de la pila!") {
            array[spot] = $("#infoPop").html();

        }
        else if (array[spot] == "Απομακρύνθηκε από την κορυφή της στοίβας") {
            array[spot] = $("#infoPop").html();

        }
        else if (array[spot] == "The Stack is empty") {
            array[spot] = $("#infoEmpty").html();


        }
        else if (array[spot] == "スタックは空です") {
            array[spot] = $("#infoEmpty").html();


        }
        else if (array[spot] == "La pila está vacía") {
            array[spot] = $("#infoEmpty").html();


        }
        else if (array[spot] == "Η στοίβα είναι κενή") {
            array[spot] = $("#infoEmpty").html();


        }
        else if (array[spot] == "The Stack is not empty") {
            array[spot] = $("#infoNotEmpty").html();


        }
        else if (array[spot] == "スタックは空ではありません") {
            array[spot] = $("#infoNotEmpty").html();


        }
        else if (array[spot] == "La pila no está vacía") {
            array[spot] = $("#infoNotEmpty").html();


        }
        else if (array[spot] == "Η στοίβα δεν είναι κενή") {
            array[spot] = $("#infoNotEmpty").html();


        }
        else if (array[spot] == "The size of the stack is") {
            array[spot] = $("#infoSize").html();


        }
        else if (array[spot] == "スタックのサイズは") {
            array[spot] = $("#infoSize").html();


        }
        else if (array[spot] == "El tamaño de la pila es") {
            array[spot] = $("#infoSize").html();


        }
        else if (array[spot] == "Το μέγεθος της στοίβας είναι") {
            array[spot] = $("#infoSize").html();


        }
        else if (array[spot] == "The top of the stack is") {
            array[spot] = $("#infoPeek").html();


        }

        else if (array[spot] == "スタックの最上部は") {
            array[spot] = $("#infoPeek").html();


        }
        else if (array[spot] == "La parte superior de la pila es") {
            array[spot] = $("#infoPeek").html();


        }
        else if (array[spot] == "Η κορυφή της στοίβας είναι") {
            array[spot] = $("#infoPeek").html();


        }
        else if (array[spot] == "You cannot peek from an empty stack") {
            array[spot] = $("#infoPeekNot").html();


        }
        else if (array[spot] == "空のスタックを見ることはできません") {
            array[spot] = $("#infoPeekNot").html();


        }
        else if (array[spot] == "No se puede mirar desde una pila vacía") {
            array[spot] = $("#infoPeekNot").html();


        }
        else if (array[spot] == "Yδεν μπορείτε να κρυφοκοιτάζει από ένα άδειο στοίβα") {
            array[spot] = $("#infoPeekNot").html();


        }
        else if (array[spot] == "You can not pop from a empty stack!") {
            array[spot] = $("#infoPopError").html();


        }
        else if (array[spot] == "空のスタックからポップすることはできません!") {
            array[spot] = $("#infoPopError").html();


        }
        else if (array[spot] == "No se puede saltar de la pila vacía!") {
            array[spot] = $("#infoPopError").html();


        }
        else if (array[spot] == "Δεν μπορείτε να σκάσει από ένα άδειο στοίβα!") {
            array[spot] = $("#infoPopError").html();


        }
        else if (array[spot] == "\n") {


        }
        else {

        }

        arrayString = arrayString + array[spot].toString() + "\n";


        $("#showLog").val(arrayString);
        spot = spot + 1;

    }




}

//$(document).bind('function_a_complete', textRedo());


$("#langJA").click(function () {
    $("[data-localize]").localize("lang", { pathPrefix: "lang", language: "ja" });

    setTimeout(function () {

        //textRedo()
    }, 2000);


});

$("#langEN").click(function () {
    $("[data-localize]").localize("lang", { pathPrefix: "lang", language: "en" });

    setTimeout(function () {

       // textRedo()
    }, 2000);


});

