function CheckUsernameInViewDetails(userName) {
    $.ajax({
        url: checkUsernameUrl,
        data: { userName: userName },
        type: 'GET',
        success: function (data) {
            if (data == false) {
                $("#viewUsernameError").text("Username does not exist");
            } else {
                $("#viewForm").submit();
            }
        }
    })
}