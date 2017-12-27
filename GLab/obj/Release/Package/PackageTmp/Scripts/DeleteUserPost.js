$(document).ready(function () {
    var firstTr;
    var Id;

    //$('#tbl tr').click(function () {

    //});

    $('.command-remove').on('click', function () {

        firstTr = $(this).closest('tr');
        Id = firstTr.find('td:first').html();
        

        $('#confirmdelete').on('click', function () {
            //alert(Id);
            //alert("daechira");
            $.ajax({
                url: '/Admin/DeleteUserPost',
                method: 'POST',
                data: { 'Id': Id },
                success: function (response) {
                    if (response == "DeleteSucceeded") {
                       
                        $('.PostedData').trigger('click');
                        window.location.href = "/Admin/AddPost";
                    }
                }

            });
        });
    });

});