var modal = $('#bootstrapModal');
var url = modal.data('url');

function showModalDefault() {
    $.get(url,
        { title: "DEFAULT", bodyText: "This is the Default Modal, sucker!" },
        function (data) {
            $('#modalContainer').html(data);

            $('#bootstrapModal').modal('show');
        }
    );
}

function showModalCustom(title, bodyText, showVideo) {
    $.get(url,
        { title: title, bodyText: bodyText, showVideo: showVideo },
        function (data) {
            $('#modalContainer').html(data);

            $('#bootstrapModal').modal('show');
        }
    );
}

function hideModal() {
    var video = $("#bigBillHell").attr("src");
    $("#bigBillHell").attr("src", "");
    $("#bigBillHell").attr("src", video);
    $('#bootstrapModal').modal('hide');
}