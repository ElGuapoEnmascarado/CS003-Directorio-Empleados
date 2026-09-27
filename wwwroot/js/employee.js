function saveEmployee() {

    const employee = {
        name: $("#name").val(),
        position: $("#position").val(),
        salary: parseFloat($("#salary").val()),
        department: $("#department").val()
    };

    $("#btnSaveEmployee").prop("disabled", true);

    $.ajax({
        url: "/Employee/Create",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(employee),

        success: function (response) {

            if (response.success) {

                location.reload();

            } else {

                showMessage(response.message, "danger");

                $("#btnSaveEmployee").prop("disabled", false);
            }
        },

        error: function () {

            showMessage(
                "Ocurrió un error al registrar el empleado.",
                "danger"
            );

            $("#btnSaveEmployee").prop("disabled", false);
        }
    });
}


function showMessage(message, type) {

    $("#messageContainer").html(`
        <div class="alert alert-${type}" role="alert">
            ${message}
        </div>
    `);
}