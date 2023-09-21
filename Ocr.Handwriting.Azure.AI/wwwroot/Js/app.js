$(function () {
    $("input[type='submit']").change(function () {
        var $fileUpload = $("input[type='file']");
        if (parseInt($fileUpload.get(0).files.length) > 1) {
            alert("You can only upload a maximum of 1 file");
        }
        else {
            console.log('okay files');
        }
    })
})