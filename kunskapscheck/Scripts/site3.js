

$('document').ready(function (e) {
    
  

    $.get("/Person/GetAll", function (data) {
        $("#posts").html(data);
    });

    
    //$(window).load(function () {
    //    // this code will run after all other $(document).ready() scripts
    //    // have completely finished, AND all page elements are fully loaded.
    //    if ($("#result").text().length==0)
    //        $("#result").load('@Url.Action("Getfirstperson", "Person")');

    //});
    
       
 


});


function OnCreateBegin(response) {

    $("#divProcessing").show();
    $("#submit").hide();


}

function OnCreateSuccess(response) {

    $("#createform")[0].reset();
    $("#divProcessing").hide();

}



function OnEditSuccess(response) {


    $("#crudfields").html("");
    $("#submit").show();

}



$('#posts').on('click', ".deletebtn", function (e) {
    var thisBtnValue = $(this).attr('value');
    e.preventDefault();
    alertify.confirm("Are you sure you want to delete this item?",
         function (e) {
             if (e) {

                 $.post("/Person/Delete", "id=" + thisBtnValue, function (data) {
                     $.get("/Person/GetAll", function (data) {
                         $("#posts").html(data);
                     });
                 });

                 
                 


                 alertify.success('Item has been removed!');
                 setTimeout(function () {
                     
                 }, 500);

                 //$.get("/Person/Getfirstperson", function (data) {

                 //    $("#post1").html(data);

                 //});


             }

             else {
                 alertify.error('Removal of item canceled');
             }
         }
         )
});




function onWindowChange() {
    $.validator.unobtrusive.parse($("#crudfields"));
    $("#divProcessing").hide();

};