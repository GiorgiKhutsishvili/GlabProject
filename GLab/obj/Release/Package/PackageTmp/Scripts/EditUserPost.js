$(document).ready(function () {
    var ID;
    var thisTr;

    $('.command-edit').on('click', function () {
        thisTr = $(this).closest('tr');
        ID = thisTr.find('td:first').html();
        $.ajax({
            url: "/Admin/GetCurrentPost",
            type: 'GET',
            data: {
                'ID': ID
            },
            success: function (result) {
                if (result.Result == "error" || result == "error") {
                    alert('error');
                }
                else {
                    //send data to modal
                    $("#EditModal #NewsTitle").val(result.NewsTitle);
                    $("#EditModal #AuthorName").val(result.AuthorName);
                    $("#EditModal #AuthorSurname").val(result.AuthorSurname);
                    $("#EditModal #NewsText").val(result.NewsText);

                    $("#start-edit-modal").click();

                    //edit UserPost
                    $("#updateUserpost").on("click", function () {
                        var NewsTitle = $("#EditModal #NewsTitle").val();
                        var AuthorName = $("#EditModal #AuthorName").val();
                        var AuthorSurname = $("#EditModal #AuthorSurname").val();
                        var NewsText = $("#EditModal #NewsText").val();

                        if (NewsTitle == "" || AuthorName == "" || AuthorSurname == "" || NewsText == "") {
                            alert("შეავსეთ ყველა ველი");
                        }
                        else {
                            $.ajax({
                                url: "/Admin/EditPost",
                                type: 'POST',
                                data: {
                                    'ID': ID, 'NewsTitle': NewsTitle, 'AuthorName': AuthorName, 'AuthorSurname': AuthorSurname, 'NewsText': NewsText
                                },
                                success: function (result) {
                                    if (result.Result == "error" || result == "error") {

                                    }
                                    else {
                                        window.location.href = "/Admin/AddPost";
                                    }
                                }
                            });
                        }
                    });
                }
            }
        });
    });



});