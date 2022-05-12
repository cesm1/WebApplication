//$(document).ready(function () {
    
//    var array = [];
//    array.push(1);
//    array.push(2);
//    array.push(3);
//    array.push(16);
//    array.push(14);

//    var sdse = JSON.stringify(array);

//    console.log(sdse);
//});


var array = [];
$(document).ready(function () {
    $('#txtWeights').keypress(function (e) {

        var charCode = (e.which) ? e.which : event.keyCode


        if (charCode === 13) {
            var value = $("#txtWeights").val();
            if (validateEmpty(value) == true) {
                btnWeights(value);
            }
        } else if (String.fromCharCode(charCode).match(/[^0-9]/g)) {
            return false;
        }

            

    });
    $('#txtWeights').keydown(function () {

    });
    $("#btnWeights").click(function () {
        var value = $("#txtWeights").val();
        if (validateEmpty(value) == true) {
            btnWeights(value);
        }
        
    });
    $("#btnCalculate").click(function () {
        if (array.length > 0) {
            var data = {
                packageWeights: array
            };
            $.ajax({
                url: '../TestAmazon/prueba',
                contentType: "application/json; charset=utf-8",
                type: 'POST',
                datatype: 'json',
                data: JSON.stringify(data),
                async: true,
                success: function (response) {
                    $("#divResult").show();
                    $("#lblresultvalue").val(response.MaxPackageWeights);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert("ocurrio un error")
                }
            });
        }
    });
    $("#btnClear").click(function () {
        clear();
    });
    //$("#btnInstruction").click(function () {
    //    $("#panelsStayOpen-headingOne").addClass("");
    //});
});

function btnWeights(value) {

    array.push( parseInt(value) );
    var html = '<input  type="button" readonly class="btn btn-success btnWeights" value="' + value + '"/>'
    $("#TotalWeights").append(html);
    $("#txtWeights").val('');
    $("#txtWeights").focus();
    $("#btnCalculate").prop("disabled", false);
}
function validateEmpty(value)
{
    var a = false;
    if (value != "") {
        a = true;
    }
   
    return a;

}
function clear() {
    array = [];
    $("#TotalWeights").empty();
    $("#divResult").hide();
    $("#lblresultvalue").val('');
    $("#btnCalculate").prop("disabled", true);

}