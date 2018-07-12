$document.ready(function () {

    $('#spanFileFormat').click(function () {
        var id = $(this).attr('data-id');

        //get file name and fields
        $.get("/suppSource/getFileInfo?id="+id, function (data, status) {
            alert("Data: " + data + "\nStatus: " + status);
        });

    });

});