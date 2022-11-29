$(document).ready(function () {
    var max_fields = 10; //maximum input boxes allowed
    var wrapper = $(".input_fields_wrap"); //Fields wrapper
    var add_button = $(".add_field_button"); //Add button ID
    var x = 0; //initlal text box count

    $(add_button).click(function (e) { //on add input button click
        e.preventDefault();
        if (x < max_fields) { //max input box allowed
            x++; //text box increment
            $(wrapper).append('<div class="input-group mb-3"><input class="form-control" name="file" type="file" placeholder="Choose a file" ><div class="input-group-append"><button class="btn btn-outline-danger remove_field" type="button">Remove</button></div></div>'); //add input box
        }
        else {
            alert('vous avez atteind la limite de 10 possibilites maximun par envoie');
        }
    });

    $(wrapper).on("click", ".remove_field", function (e) { //user click on remove text
        e.preventDefault(); $(this).parent('div').parent('div').remove(); x--;
    })
});
