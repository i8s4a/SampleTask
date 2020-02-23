$(document).ready(function() {
    loadData();
});

function loadData() {
    $.ajax({
        url: "/Home/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.Id + '</td>';
                html += '<td>' + item.TCNO + '</td>';
                html += '<td>' + item.Name + '</td>';
                html += '<td>' + item.Password + '</td>';
                html += '<td>' + item.ConfirmPassword + '</td>';
                html += '<td>' + item.Price + '</td>';
                html += '<td>' + item.ForeignCurrency + '</td>';
                html += '<td>' + item.CalculateValue + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.Id + ')">Düzelt</a> | <a href="#" onclick="Delete(' + item.Id + ')">Sil</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function AddProduct() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var product = {
        Id: $('#Id').val(),
        TCNO: $('#TCNO').val(),
        Name: $('#Name').val(),
        Password: $('#Password').val(),
        ConfirmPassword: $('#ConfirmPassword').val(),
        ForeignCurrency: $('#ForeignCurrency').val(),
        Price: $('#Price').val(),
        CalculateValue: $('#CalculateValue').val()
    };
    $.ajax({
        url: "/Home/CreateProduct",
        data: JSON.stringify(product),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function getbyID(Id) {
    $('#TCNO').css('border-color', 'lightgrey');
    $('#Name').css('border-color', 'lightgrey');
    $('#Password').css('border-color', 'lightgrey');
    $('#ConfirmPassword').css('border-color', 'lightgrey');
    $('#Price').css('border-color', 'lightgrey');
    $('#ForeignCurrency').css('border-color', 'lightgrey');
    $('#CalculateValue').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Home/GetById/" + Id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#Id').val(result.Id);
            $('#TCNO').val(result.Name);
            $('#Name').val(result.Name);
            $('#Password').val(result.Age);
            $('#ConfirmPassword').val(result.State);
            $('#Price').val(result.Country);
            $('#ForeignCurrency').val(result.Name);
            $('#CalculateValue').val(result.Name);
            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

function EditProduct() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var product = {
        Id: $('#Id').val(),
        TCNO: $('#T').val(),
        Name: $('#Name').val(),
        Password: $('#Password').val(),
        ConfirmPassword: $('#ConfirmPassword').val(),
        ForeignCurrency: $('#ForeignCurrency').val(),
        Price: $('#Price').val(),
        CalculateValue: $('#CalculateValue').val()
    };
    $.ajax({
        url: "/Home/EditProduct",
        data: JSON.stringify(product),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#Id').val("");
            $('#TCNO').val("");
            $('#Name').val("");
            $('#Password').val("");
            $('#ConfirmPassword').val("");
            $('#ForeignCurrency').val("");
            $('#Price').val("");
            $('#CalculateValue').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Delete(Id) {
    var ans = confirm("Bu kaydı silmek istediğinize emin misiniz?");
    if (ans) {
        $.ajax({
            url: "/Home/DeleteProduct/" + Id,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

function clearTextBox() {
    $('#Id').val("");
    $('#TCNO').val("");
    $('#Name').val("");
    $('#Password').val("");
    $('#ConfirmPassword').val("");
    $('#ForeignCurrency').val("");
    $('#Price').val("");
    $('#CalculateValue').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Name').css('border-color', 'lightgrey');
    $('#Age').css('border-color', 'lightgrey');
    $('#State').css('border-color', 'lightgrey');
    $('#Country').css('border-color', 'lightgrey');
}
function validate() {
    var isValid = true;
    if ($('#TCNO').val().trim() == "") {
        $('#TCNO').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#TCNO').css('border-color', 'lightgrey');
    }
    if ($('#Name').val().trim() == "") {
        $('#Name').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Name').css('border-color', 'lightgrey');
    }
    if ($('#Password').val().trim() == "") {
        $('#Password').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Password').css('border-color', 'lightgrey');
    }
    if ($('#ConfirmPassword').val().trim() == "") {
        $('#ConfirmPassword').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ConfirmPassword').css('border-color', 'lightgrey');
    }
    if ($('#ForeignCurrency').val().trim() == "") {
        $('#ForeignCurrency').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ForeignCurrency').css('border-color', 'lightgrey');
    }
    if ($('#Price').val().trim() == "") {
        $('#Price').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Price').css('border-color', 'lightgrey');
    }
    if ($('#CalculateValue').val().trim() == "") {
        $('#CalculateValue').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#CalculateValue').css('border-color', 'lightgrey');
    }
    return isValid;
}