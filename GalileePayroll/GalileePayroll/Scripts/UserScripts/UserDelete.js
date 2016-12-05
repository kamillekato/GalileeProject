
function DeleteUser(username) {
    var data = { username: username };
    $.ajax({
        url: deleteUserUrl,
        data: data,
        type: 'GET',
        success: function (data) {
            if (data.deleteStatus == false) {
                alert('failed');
            } else {
                //close delete mdoal
            }


        }
    });
}

function GetNameOfUser(username) {
    var data = { username: username };
    $.ajax({
        url: getNameOfUserUrl,
        data: data,
        type: 'GET',
        success: function (data) {
            $("#currentDeleteUsername").text(username);
            $("#currentDeleteName").text(data.Name);
        }
    });
}

function CheckUsername(userName) {
    $.ajax({
        url: checkUsernameUrl,
        data: { userName: userName },
        type: 'GET',
        success: function (data) {
            if (data == false) {
                $("#deleteUsernameError").text("Username does not exist");
            } else {
                $("#deleteStepOne").hide();
                $("#deleteStepTwo").show();
                $("#deleteModalButton").show();
                $("#doneDeleteModalButton").hide();
                GetNameOfUser(userName);
            }
        }

    });
}

function BackToStepOne() {
    $("#deleteStepOne").show();
    $("#deleteStepTwo").hide();
    $("#deleteUsernameError").text("");
    $("#deleteUsername").val("");
    $("#deleteModalButton").hide();
    $("#doneDeleteModalButton").show();

}

