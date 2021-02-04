function AddEmployee() {
    var data = {
        "EmpName": $('#employee_name').val(),
        "EmailID": $('#email_id').val(),
        "MobileNumber": $('#mobile_number').val(),
        "Address": $('#address').val(),
        "Password": $('#password').val()
    }
    console.log("Register data = ", JSON.stringify(data));
    $.ajax(
        {
            type: 'POST',
            url: 'https://localhost:44332/api/Employee',
            data: JSON.stringify(data),
            contentType: 'application/json',
            success: function () {
                alert('Employee added successfully');
            },
            error: function () {
                console.log("error");
            }

        })
}

$.ajax(
    {
        type: 'GET',
        url: 'https://localhost:44332/api/Employee',
        contentType: 'application/json',
        success: function (data) {
            console.log(data.data);
            $.each(data.data, function (key, value) {
                var EmpName = value.empName;
                var EmailID = value.emailID;
                var MobileNumber = value.mobileNumber;
                $('<tr><td>' + EmpName + '<td>' + EmailID + '<td>' + MobileNumber +
                    '<td><form action="/html/EditPage.html" ><button id=' + value.empID + ' onClick="UpdateEmployee(id)"  class="Edit-Button"><img src="/Images/edit.png" style="width:20px; height:20px;"/> ' +
                    '<td><form ><button id=' + value.empID + ' onClick="DeleteEmployee(id)"  class="Delete-Button"><img src="/Images/delete.png" style="width:20px;height:20px;"/>')
                    .appendTo("#allEmployeeTable");

            })
           
        },
        error: function () {
            console.log("error");
        }

    })

function DeleteEmployee(id) {
    console.log(id);
    $.ajax(
        {
            type: 'DELETE',
            url: 'https://localhost:44332/api/Employee?EmpId=' + id,
            contentType: 'application/json',
            success: function () {

                alert('Employee Deleted successfully');
                location.reload();
            },
            error: function () {
                console.log("error");
            }

        })
}
function UpdateEmployee(id) {
    localStorage.setItem("UpdateEmployeeID", id);
    console.log("UpdateEmployeeID ", id);

}
function EditEmployee() {
    var data = {
        "EmpID": localStorage.getItem("UpdateEmployeeID"),
        "EmpName": $('#employee_name').val(),
        "EmailId": $('#email_id').val(),
        "MobileNumber": $('#mobile_number').val(),
        "Address": $('#address').val(),
        "Password": $('#password').val()
    }
    console.log("Updated Data : ", JSON.stringify(data));
    console.log("ID: ", data.EmpID);
    $.ajax(
        {
            type: 'PUT',
            url: 'https://localhost:44332/api/Employee',
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function () {

                alert('Employee Updated successfully');
                window.location.href = "DisplayEmployee.html";
            },
            error: function () {
                console.log("error");
            }

        })

}
