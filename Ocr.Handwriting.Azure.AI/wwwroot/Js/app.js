<script type="text/javascript">

    $(function(){
        $("input[type='submit']").click(function () {
            var $fileUpload = $("input[type='file']");
            if (parseInt($fileUpload.get(0).files.length) > 1) {
                alert("You can only upload a maximum of 1 file");
            }
        });    
    });​

</script>