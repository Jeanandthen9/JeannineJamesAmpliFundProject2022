var createCarSection = document.getElementById("createCarSection");
var detailsCarSection = document.getElementById("detailsCarSection");
var editCarSection = document.getElementById("editCarSection");
var deleteCarSection = document.getElementById("deleteCarSection");
var oldId = 0;

/*HIDE/SHOW SECTIONS TOGGLE*/
function showCreateCarSection() {
    if (createCarSection.style.display === "none") {
        createCarAjaxCall();

        createCarSection.style.display = "block";
        editCarSection.style.display = "none";
        detailsCarSection.style.display = "none"
        deleteCarSection.style.display = "none";
    } else {
        createCarSection.style.display = "none";
    }
}

function showEditCarSection(id) {
    if ((editCarSection.style.display === "none") || (editCarSection.style.display === "block" && oldId !== id)) {
        editCarAjaxCall(id);

        oldId = id;

        createCarSection.style.display = "none";
        editCarSection.style.display = "block";
        detailsCarSection.style.display = "none"
        deleteCarSection.style.display = "none";

    }
    else {
        editCarSection.style.display = "none";
    }
}

function showDetailsCarSection(id) {
    if (detailsCarSection.style.display === "none" || (detailsCarSection.style.display === "block" && oldId !== id)) {
        carDetailsAjaxCall(id);

        oldId = id;

        createCarSection.style.display = "none";
        editCarSection.style.display = "none";
        detailsCarSection.style.display = "block"
        deleteCarSection.style.display = "none";
    } else {
        detailsCarSection.style.display = "none";
    }
}

function showDeleteCarSection(id) {
    if (deleteCarSection.style.display === "none" || (deleteCarSection.style.display === "block" && oldId !== id)) {
        deleteCarAjaxCall(id);

        oldId = id;

        createCarSection.style.display = "none";
        editCarSection.style.display = "none";
        detailsCarSection.style.display = "none"
        deleteCarSection.style.display = "block";
    } else {
        deleteCarSection.style.display = "none";
    }
}

/*AJAX CALLS*/
function createCarAjaxCall() {
    var section = $('#createCarSection');
    var url = section.data('url');
    $.get(url,
        function (data) {
            $('#createCarContainer').html(data);
        }
    );
}

function carDetailsAjaxCall(id) {
    var section = $('#detailsCarSection');
    var url = section.data('url');
    $.get(url,
        { carId: id },
        function (data) {
            $('#detailsCarContainer').html(data);
        }
    );
}

function editCarAjaxCall(id) {
    var section = $('#editCarSection');
    var url = section.data('url');
    $.get(url,
        { carId: id },
        function (data) {
            $('#editCarContainer').html(data);
        }
    );
}

function deleteCarAjaxCall(id) {
    var section = $('#deleteCarSection');
    var url = section.data('url');
    $.get(url,
        { carId: id },
        function (data) {
            $('#deleteCarContainer').html(data);
        }
    );
}

/* DELETE CAR FUNCTIONS */
function submitDeleteCar(id) {
    var url = $('#confirmRemoveCar').data('url');
    $.post(url, { carId: id }, function (data) {
        location.reload();
    });
}

