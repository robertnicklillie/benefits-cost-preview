// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
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
        newDependent.on("click", function (e) {
            e.preventDefault();

            var dependent = $(this);
            console.log(dependent);
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
        console.log(dependent);
        dependent.find("#Action").attr("value", "Remove");
        dependent.hide();
    });
})