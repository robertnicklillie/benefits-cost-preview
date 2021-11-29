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
                $('#preview-message').slideUp();
                $('#preview-gross').text(data.employeeGrossPerPayPeriod.toFixed(2));
                $('#preview-deduction').text(data.employeeCostPerPayPeriod.toFixed(2));
                $('#preview-net').text(data.employeeNetPerPayPeriod.toFixed(2));
            } else {
                $('#preview-message').slideDown();
                $('#preview-gross').text('---');
                $('#preview-deduction').text('---');
                $('#preview-net').text('---');
            }
        },
        error: function (request, error) {
            alert("Request: " + JSON.stringify(request));
        }
    });

    $('#preview-progress').hide();
}

function ActivatePreview() {
    $('#preview-progress').show();
    window.PreviewTimer = setTimeout(Preview, 3000);
}

function CancelPreview() {
    if (window.PreviewTimer !== undefined) {
        clearTimeout(window.PreviewTimer);
    }
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

            CancelPreview();
            ActivatePreview();
        });
        newDependent.on("keydown", () => { CancelPreview(); ActivatePreview(); });
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

    $(".input-preview").on("keydown", () => { CancelPreview(); ActivatePreview(); })
    $(".button-preview").on("click", () => { CancelPreview(); ActivatePreview(); })
})