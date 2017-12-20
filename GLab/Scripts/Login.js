//$(document).ready(function () {
//    $('.loginBtn').click(function () {

//        var UsrEmail = $('#UsrEmail').val();
//        var UsrPassword = $('#UsrPassword').val();

//        if (UsrEmail == '' || UsrPassword == '') {
//            $('#ErrorMsg').html('ჩაწერეთ ელ.ფოსტა და პაროლი').css('color', 'red');
//        }
//        else {
//            $.ajax({
//                url: '/Account/Login',
//                method: 'POST',
//                data: { 'UsrEmail': UsrEmail, 'UsrPassword': UsrPassword },
//                success: function (response) {
//                    if (response == "LoginFailed") {
//                        $('#ErrorMsg').html('ელ.ფოსტა ან პაროლი არასწორია').css('color', 'red');
//                    }
//                    //else {
//                    //    window.location.href = "/Admin/AddPost";
//                    //}
//                }
//            });
//        }

//    });

//});