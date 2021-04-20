$(document).ready(function () {
    $(".custom-file-input").on("change",
        function () {
            var filename = $(this).val().split('\\').pop();
            $(this).next('.custom-file-label').html(filename);
        });
});