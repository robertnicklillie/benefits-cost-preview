// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function Preview() {
    $.ajax({
        url: '/Home/CalculateBenefitsCost',
        type: 'POST',
        data: $('form').serialize(),
        dataType: 'json',
        success: function (data) {
            if (data.canCalculate) {
                $('#preview-message').hide();
                $('#preview-gross').text(data.employeeGrossPerPayPeriod.toFixed(2));
                $('#preview-deduction').text(data.employeeCostPerPayPeriod.toFixed(2));
                $('#preview-net').text(data.employeeNetPerPayPeriod.toFixed(2));
            } else {
                $('#preview-message').show();
            }
        },
        error: function (request, error) {
            alert("Request: " + JSON.stringify(request));
        }
    });
}

$("document").ready(function () {
    $("#add-new-dependent-button").on("click", function (e) {
        e.preventDefault();

        // get the current depedents count
        var dependentsCount = $("#dependents-count").data().value;
        console.log(dependentsCount);
        if (dependentsCount == 0) {
            $("#no-dependents").remove();
        }

        // create a new dependent for adding
        var newDependent = $("#dependent-template").clone();
        var removeButton = newDependent.find(".dependent-remove");
        removeButton.on("click", function (e) {
            e.preventDefault();

            var dependent = $(this).parent().parent();
            dependent.find("#Action").attr("value", "Remove");
            dependent.hide();
        });
        newDependent.insertBefore("#dependent-template");

        // change the data on the template
        newDependent.attr("id", "");
        newDependent.find("#FirstName").attr("name", "Dependents[" + dependentsCount + "].FirstName");
        newDependent.find("#LastName").attr("name", "Dependents[" + dependentsCount + "].LastName");
        newDependent.find("#Action").attr("name", "Dependents[" + dependentsCount + "].Action");

        // show the dependent
        newDependent.show();

        // update the dependents count
        dependentsCount++;
        $("#dependents-count").data("value", dependentsCount);
    });

    $(".dependent-remove").on("click", function (e) {
        e.preventDefault();

        var dependent = $(this).parent().parent();
        dependent.find("#Action").attr("value", "Remove");
        dependent.hide();
    });
})