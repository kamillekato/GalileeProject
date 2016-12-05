

function CheckUsernameInUpdate(userName) {
    $.ajax({
        url: checkUsernameUrl,
        data: { userName: userName },
        type: 'GET',
        success: function (data) {
            if (data == false) {
                $("#updateUsernameError").text("Username does not exist");
            } else {
                $("#updateForm").submit();

            }
        }

    });
}
